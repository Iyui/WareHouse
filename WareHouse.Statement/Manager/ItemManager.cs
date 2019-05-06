using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using WareHouse.ConnStr;
namespace WareHouse.Statement.Manager
{
    public partial class ItemManager : Form
    {
        public ItemManager()
        {
            InitializeComponent();
        }
        private string connStr = Connection.ConnStr;

        private void ItemManager_Load(object sender, EventArgs e)
        {
            string strsql = "SELECT * FROM item_information item_information order by 项目编号";
            dateTabletoCSV.ConditionQuery(dataGridView1, strsql);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string str1 = this.dataGridView1.CurrentRow.Cells["项目编号"].Value.ToString().Trim();
            string str2 = this.dataGridView1.CurrentRow.Cells["项目型号"].Value.ToString().Trim();
            string str3 = this.dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString().Trim();
            string str4 = this.dataGridView1.CurrentRow.Cells["项目批号"].Value.ToString().Trim();
            string str5 = this.dataGridView1.CurrentRow.Cells["项目说明"].Value.ToString().Trim();
            string str6 = this.dataGridView1.CurrentRow.Cells["已完成"].Value.ToString().Trim();
            string str7 = this.dataGridView1.CurrentRow.Cells["备注"].Value.ToString().Trim();
            tbItemSerialNum.Text = str1;
            tbItemType.Text = str2;
            tbItemBatchNum.Text = str4;
            tbItemName.Text = str3;
            tbItemDescription.Text = str5;
            tbRemark.Text = str7;
            if (str6 == "true")
                cbIsCompleted.Text = "是";
            else
                cbIsCompleted.Text = "否";

        }

        private void isItemExist()
        {
            
            string str1 = this.dataGridView1.CurrentRow.Cells["项目编号"].Value.ToString().Trim();
            string strsql = $"SELECT count(项目编号) FROM item_information where 项目编号 = '{str1}'";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(strsql, conn))
                {
                    conn.Open();
                    int n = Convert.ToInt32(cmd.ExecuteScalar());
                    
                        if (n > 0)
                        {
                            string strsql2 = $"SELECT count(项目编号) FROM item_information where 项目编号 = '{tbItemSerialNum.Text.Trim()}'";
                            using (SqlCommand cmd2 = new SqlCommand(strsql2, conn))
                            {
                                int m = Convert.ToInt32(cmd2.ExecuteScalar());
                                if (m > 0 && tbItemSerialNum.Text.Trim() != str1.Trim())
                                {
                                    MessageBox.Show($"无法修改项目编号为[{tbItemSerialNum.Text.Trim()}],该项目编号[{tbItemSerialNum.Text.Trim()}]已存在");
                                    return;
                                }
                            }
                        SqlTransaction tran = conn.BeginTransaction();
                        try
                        {
                            if (MessageBox.Show($"确定要对项目编号:[{str1}]进行修改?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                modifyItem(str1, int.Parse(tbItemSerialNum.Text), conn, tran);
                            }
                            else
                            {
                                if (MessageBox.Show("项目中没有此项目,是否要添加?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    AddItem(int.Parse(str1), conn, tran);
                                }
                            }
                        }
                        catch
                        {
                            tran.Rollback();
                        }
                    }

                }
            }
        }
        Connection ct = new Connection();
        private void AddItem(int ItemsCount,SqlConnection conn,SqlTransaction tran)
        {
            string itemSql = $"INSERT INTO item_information(项目编号,项目型号 ,项目批号,备注,项目名称,项目说明,已完成) " +
                $"VALUES(@项目编号,@项目型号 ,@项目批号,@备注,@项目名称,@项目说明,@已完成) ";
            var isInsertItemSucceed = ct.AddData(conn, tran, itemSql, Item_para(ItemsCount));
            if (isInsertItemSucceed)
            {
                tran.Commit();
                MessageBox.Show("添加成功");
                string strsql = "SELECT * FROM item_information item_information order by 项目编号";
                dateTabletoCSV.ConditionQuery(dataGridView1, strsql);
            }
            else
            {
                tran.Rollback();
                MessageBox.Show("添加失败");
            }
        }

        private SqlParameter[] Item_para(int itemNum)
        {
            bool iscomplete = false;
            if (cbIsCompleted.Text == "是")
                iscomplete = true;
            else
                iscomplete = false;
            var item_para = new SqlParameter[]
                {
                //不声明变量类型 直接进行复制
                new SqlParameter("@项目编号",itemNum.ToString("0000")),
                new SqlParameter("@项目型号",tbItemType.Text.Trim()),
                new SqlParameter("@项目批号",tbItemBatchNum.Text.Trim()),
                new SqlParameter("@备注",tbRemark.Text.Trim()),
                new SqlParameter("@项目名称",tbItemName.Text.Trim()),
                new SqlParameter("@项目说明",tbItemDescription.Text.Trim()),
                new SqlParameter("@已完成",iscomplete),

                };
            return item_para;
        }

        private void modifyItem(string str,int ItemsCount, SqlConnection conn, SqlTransaction tran)
        {
            string UpdateSqlStr = $"UPDATE item_information SET 项目编号 = @项目编号,项目型号 = @项目型号,项目批号=@项目批号,备注= @备注" +
                $",项目名称=@项目名称,项目说明= @项目说明,已完成 = @已完成 WHERE 项目编号 = {str}";
            var isUpdateSucceed = ct.UpdateData(conn, tran, UpdateSqlStr, Item_para(ItemsCount));
            if (isUpdateSucceed)
            {
                tran.Commit();
                MessageBox.Show("修改成功");
            }
            else
            {
                tran.Rollback();
                MessageBox.Show("修改失败");
            }
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            string str1 = tbItemSerialNum.Text.Trim();
            string strsql = $"SELECT count(项目编号) FROM item_information where 项目编号 = '{str1}'";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(strsql, conn))
                {
                    conn.Open();
                    int n = Convert.ToInt32(cmd.ExecuteScalar());
                    SqlTransaction tran = conn.BeginTransaction();
                    if (n > 0)
                    {
                        MessageBox.Show($"项目编号:[{str1}]已存在,无法添加");
                    }
                    else
                    {
                        if (MessageBox.Show($"确定要添加项目编号:[{str1}]?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            AddItem(int.Parse(str1), conn, tran);
                        }
                    }
                }
            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            string str1 = this.dataGridView1.CurrentRow.Cells["项目编号"].Value.ToString().Trim();
            string strsql = $"SELECT count(项目编号) FROM item_information where 项目编号 = '{str1}'";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(strsql, conn))
                {
                    conn.Open();
                    
                    int n = Convert.ToInt32(cmd.ExecuteScalar());
                    SqlTransaction tran = conn.BeginTransaction();
                    if (n > 0)
                    {
                        var Purview_paras = new SqlParameter[]
                    {

                    };
                        var DeleteSqlStr = $"DELETE FROM item_information WHERE 项目编号 = '{str1}'";
                        var isUpdateSucceed = ct.DeleteData(conn, tran, DeleteSqlStr, Purview_paras);
                        if (isUpdateSucceed)
                        {
                            tran.Commit();
                            MessageBox.Show("删除记录成功");
                            ItemManager_Load(sender, e);
                            //Close();
                        }
                        else
                        {
                            tran.Rollback();
                        }
                    }

                }
            }
        }

        private void bt_Amend_Click(object sender, EventArgs e)
        {
            isItemExist();
        }
    }
}
