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
namespace WareHouse.Statement
{
    public partial class StatementQuery : Form
    {
        public StatementQuery()
        {
            InitializeComponent();
            IndateTime1.CustomFormat = "yyyy-MM-dd";
            IndateTime2.CustomFormat = "yyyy-MM-dd";
        }

        public string strSqlQuery
        {
            set; get;
        }
        public string strSqlCount
        {
            set; get;
        }
        public string datetime1
        {
            set; get;
        }
        public string datetime2
        {
            set; get;

        }

        private void StatementManage_Load(object sender, EventArgs e)
        {
            IndateTime1.CustomFormat = "yyyy-MM-dd";
            IndateTime2.CustomFormat = "yyyy-MM-dd";
        }

        private void SetTabControlItemsSize()
        {

        }

        private void StatementManage_Resize(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void btQuery_Click(object sender, EventArgs e)
        {
            if (tabcQuery.SelectedTab == tp_In_Information)
            {
                var isCondition1Checked = InCondition1.Checked;
                var isCondition2Checked = InCondition2.Checked;

                var isExpretion1Empty = String.IsNullOrEmpty(cbExpression1.Text.Trim());
                var isExpretion2Empty = String.IsNullOrEmpty(cbExpression2.Text.Trim());

                var condition1 = cbcondition1.Text;
                var condition2 = cbcondition2.Text;

                var expression1 = cbExpression1.Text.Trim();
                var expression2 = cbExpression2.Text.Trim();
                datetime1 = IndateTime1.Value.ToString();
                datetime2 = IndateTime2.Value.ToString();
                strSqlQuery = "select * from in_goods order by 缴库日期,物资编号";
                strSqlCount = "select count(*)as 记录数,sum(数量)as 缴库总数量,sum(金额)as 总金额 from in_goods ";
                if (isCondition1Checked && !isCondition2Checked)//只有条件1
                {
                    if (!isExpretion1Empty && isExpretion2Empty)
                    {
                        strSqlQuery = "select * from in_goods where (in_goods." + condition1 + " like '%" + expression1 + "%') order by 物资编号";
                        strSqlCount = "select count(*)as 记录数,sum(数量)as 缴库总数量,sum(金额)as 总金额 from in_goods where  (in_goods." + condition1 + " like '%" + expression1 + "%')";

                    }
                    else if (isExpretion1Empty && !isExpretion2Empty)
                    {
                        strSqlQuery = "select * from in_goods where  (in_goods." + condition2 + " like '% " + expression2 + "%') order by 物资编号";
                        strSqlCount = "select count(*)as 记录数,sum(数量)as 缴库总数量,sum(金额)as 总金额 from in_goods where  (in_goods." + condition2 + " like '% " + expression2 + "%')";

                    }
                    else if (!isExpretion1Empty && !isExpretion2Empty)
                    {
                        strSqlQuery = "select * from in_goods where (in_goods." + condition1 + " like '%" + expression1 + "%' AND (in_goods." + condition2 + " like + '%" + expression2 + "%') order by 物资编号";
                        strSqlCount = "select count(*)as 记录数,sum(数量)as 缴库总数量,sum(金额)as 总金额 from in_goods where (in_goods." + condition1 + " like '%" + expression1 + "%' AND (in_goods." + condition2 + " like + '%" + expression2 + "%')";

                    }
                }
                else if (!isCondition1Checked && isCondition2Checked)//只有条件2时间
                {
                    strSqlQuery = "select * from in_goods where in_goods.缴库日期 between '" + datetime1 + "'AND '" + datetime2 + "' order by 缴库日期,物资编号 ";
                    strSqlCount = "select count(*)as 记录数,sum(数量)as 缴库总数量,sum(金额)as 总金额 from in_goods where in_goods.缴库日期 between '" + datetime1 + "'AND '" + datetime2 + "'";
                }
                else if (isCondition1Checked && isCondition2Checked)//都有
                {
                    if (!isExpretion1Empty && !isExpretion2Empty)
                    {
                        strSqlQuery = "select * from in_goods " +
                            "where in_goods." + condition1 + " like '%" + expression1 + "%' " +
               "AND (in_goods." + condition2 + " " + " like '%" + expression2 + "%') " +
                "AND in_goods.缴库日期 between '" + datetime1 + "'AND '" + datetime2 + "' order by 缴库日期,物资编号 ";
                        strSqlCount = "select count(*)as 记录数,sum(数量)as 缴库总数量,sum(金额)as 总金额 from in_goods " +
                            "where in_goods." + condition1 + " like '%" + expression1 + "%' " +
               "AND (in_goods." + condition2 + " " + " like '%" + expression2 + "%') " +
                "AND in_goods.缴库日期 between '" + datetime1 + "'AND '" + datetime2 + "'";

                    }
                    else if (!isExpretion1Empty && isExpretion2Empty)
                    {
                        strSqlQuery = "select * from in_goods " +
                            "where in_goods." + condition1 + " like  '%" + expression1 + "%' " +
               "AND in_goods.缴库日期 between '" + datetime1 + "'AND '" + datetime2 + "' order by 缴库日期,物资编号 ";
                        strSqlCount = "select count(*)as 记录数,sum(数量)as 缴库总数量,sum(金额)as 总金额 from in_goods " +
                            "where in_goods." + condition1 + " like  '%" + expression1 + "%' " +
               "AND in_goods.缴库日期 between '" + datetime1 + "'AND '" + datetime2 + "'";

                    }
                    else if (isExpretion1Empty && !isExpretion2Empty)
                    {
                        strSqlQuery = "select * from in_goods where in_goods." + condition2 + " like '%" + expression2 + "%' " +
               "AND in_goods.缴库日期 between '" + datetime1 + "'AND '" + datetime2 + "' order by 缴库日期,物资编号 ";
                        strSqlCount = "select count(*)as 记录数,sum(数量)as 缴库总数量,sum(金额)as 总金额 from in_goods where in_goods." + condition2 + " like '%" + expression2 + "%' " +
               "AND in_goods.缴库日期 between '" + datetime1 + "'AND '" + datetime2 + "'";
                    }
                }
                ConditionQuery(dataGridView1);
                ConditionCount(label2, label3, label5);
            }
            else if (tabcQuery.SelectedTab == tp_Out_Information)
            {

                var isCondition1Checked = OutCondition1.Checked;
                var isCondition2Checked = OutCondition2.Checked;

                var isExpretion1Empty = String.IsNullOrEmpty(comboBox6.Text.Trim());
                var isExpretion2Empty = String.IsNullOrEmpty(comboBox5.Text.Trim());

                var condition1 = comboBox8.Text;
                var condition2 = comboBox7.Text;

                var expression1 = comboBox6.Text.Trim();
                var expression2 = comboBox5.Text.Trim();
                datetime1 = OutdateTime1.Value.ToString();
                datetime2 = OutdateTime2.Value.ToString();
                strSqlQuery = "select * from out_goods order by 物资编号";
                strSqlCount = "select count(*)as 记录数,sum(数量)as 领料总数量,sum(金额)as 总金额 from out_goods ";
                if (isCondition1Checked && !isCondition2Checked)
                {
                    if (!isExpretion1Empty && isExpretion2Empty)
                    {
                        strSqlQuery = "select * from out_goods where  (out_goods." + condition1 + " like '%" + expression1 + "%') order by 物资编号";
                        strSqlCount = "select count(*)as 记录数,sum(数量)as 领料总数量,sum(金额)as 总金额 from out_goods where  (out_goods." + condition1 + " like '%" + expression1 + "%')";
                    }
                    else if (isExpretion1Empty && !isExpretion2Empty)
                    {
                        strSqlQuery = "select * from out_goods where  (out_goods." + condition2 + " like '% " + expression2 + "%') order by 物资编号";
                        strSqlCount = "select count(*)as 记录数,sum(数量)as 领料总数量,sum(金额)as 总金额 from out_goods where  (out_goods." + condition2 + " like '% " + expression2 + "%')";

                    }
                    else if (!isExpretion1Empty && !isExpretion2Empty)
                    {
                        strSqlQuery = "select * from out_goods where (out_goods." + condition1 + " like '%" + expression1 + "%' AND (out_goods." + condition2 + " like '%" + cbExpression2.Text.Trim() + "%') order by 物资编号";
                        strSqlCount = "select count(*)as 记录数,sum(数量)as 领料总数量,sum(金额)as 总金额 from out_goods where (out_goods." + condition1 + " like '%" + expression1 + "%' AND (out_goods." + condition2 + " like '%" + cbExpression2.Text.Trim() + "%')";

                    }
                }
                else if (!isCondition1Checked && isCondition2Checked)
                {
                    strSqlQuery = "select * from out_goods where out_goods.领料日期 between '" + datetime1 + "'AND '" + datetime2 + "' order by 领料日期,物资编号 ";
                    strSqlCount = "select count(*)as 记录数,sum(数量)as 领料总数量,sum(金额)as 总金额 from out_goods where out_goods.领料日期 between '" + datetime1 + "'AND '" + datetime2 + "'";

                }
                else if (isCondition1Checked && isCondition2Checked)
                {
                    if (!isExpretion1Empty && !isExpretion2Empty)
                    {
                        strSqlQuery = "select * from out_goods where out_goods." + condition1 + " like '%" + expression1 + "%' " +
               "AND (out_goods." + condition2 + " " + " like '%" + expression2 + "%') " +
                "AND out_goods.领料日期 between '" + datetime1 + "'AND '" + datetime2 + "' order by 领料日期,物资编号 ";
                        strSqlCount = "select count(*)as 记录数,sum(数量)as 领料总数量,sum(金额)as 总金额 from out_goods where out_goods." + condition1 + " like '%" + expression1 + "%' " +
               "AND (out_goods." + condition2 + " " + " like '%" + expression2 + "%') " +
                "AND out_goods.领料日期 between '" + datetime1 + "'AND '" + datetime2 + "'";

                    }
                    else if (!isExpretion1Empty && isExpretion2Empty)
                    {
                        strSqlQuery = "select * from out_goods where out_goods." + condition1 + " like  '%" + expression1 + "%' " +
               "AND out_goods.领料日期 between '" + datetime1 + "'AND '" + datetime2 + "' order by 领料日期,物资编号 ";
                        strSqlCount = "select count(*)as 记录数,sum(数量)as 领料总数量,sum(金额)as 总金额 from out_goods where out_goods." + condition1 + " like  '%" + expression1 + "%' " +
               "AND out_goods.领料日期 between '" + datetime1 + "'AND '" + datetime2 + "'";

                    }
                    else if (isExpretion1Empty && !isExpretion2Empty)
                    {
                        strSqlQuery = "select * from out_goods where out_goods." + condition2 + " like '%" + expression2 + "%' " +
               "AND out_goods.领料日期 between '" + datetime1 + "'AND '" + datetime2 + "' order by 领料日期,物资编号 ";
                        strSqlCount = "select count(*)as 记录数,sum(数量)as 领料总数量,sum(金额)as 总金额 from out_goods where out_goods." + condition2 + " like '%" + expression2 + "%' " +
               "AND out_goods.领料日期 between '" + datetime1 + "'AND '" + datetime2 + "'";
                    }
                }
                ConditionQuery(dataGridView2);
                ConditionCount(label11, label9, label7);
            }
            else if (tabcQuery.SelectedTab == tp_Goods_Information)
            {
                var str = "";
                strSqlQuery = "select * from storehouse ";
                strSqlCount = "select count(*)as 记录数,sum(数量)as 库存总数量,sum(金额)as 总金额 from storehouse ";
                var expression1 = cbExpression20.Text.Trim();
                var expression2 = cbExpression21.Text.Trim();
                var expression3 = cbExpression22.Text.Trim();
                var isExpretion1Empty = String.IsNullOrEmpty(expression1);
                var isExpretion2Empty = String.IsNullOrEmpty(expression2);
                var isExpretion3Empty = String.IsNullOrEmpty(expression3);
                if (!isExpretion1Empty)
                {
                    str = "where storehouse.物资编号 like '%" + expression1 + "%' ";
                    strSqlQuery += str;
                    strSqlCount += str;
                }
                if (!isExpretion2Empty)
                {
                    if (!isExpretion1Empty)
                    {
                        str = "And (storehouse.品名  like  '%" + expression2 + "%') ";
                    }
                    else
                    {
                        str = "where (storehouse.品名 like '%" + expression2 + "%') ";
                    }
                    strSqlQuery += str;
                    strSqlCount += str;
                }
                if (!isExpretion3Empty)
                {
                    if (!isExpretion1Empty || !isExpretion2Empty)
                    {
                        str = "And (storehouse.规格 like '%" + expression3 + "%')";
                    }
                    else
                    {
                        str = "WHERE (storehouse.规格 like '%" + expression3 + "%')";
                    }
                    strSqlQuery += str;
                    strSqlCount += str;
                }
                strSqlQuery += "order by 物资编号 ";
                ConditionQuery(dataGridView3);
                ConditionCount(label17, label15, label13);
            }
            else if (tabcQuery.SelectedTab == tp_Items_Information)
            {
                if (!String.IsNullOrEmpty(comboBox12.Text.Trim()))
                {
                    strSqlCount = "select count(*)as 记录数 from item_information where (item_information." + comboBox13.Text + " like '%" + comboBox12.Text.Trim() + "%')";
                    strSqlQuery = "select * from item_information where  (item_information." + comboBox13.Text + " like '%" + comboBox12.Text.Trim() + "%')";
                    ConditionQuery(dataGridView4);
                    ConditionCount(label23);
                    strSqlCount = "select count(*)as 完成数 from item_information where  (item_information." + comboBox13.Text + " like '%" + comboBox12.Text.Trim() + "%') and 已完成 = 1";
                    ConditionCount(label20);
                }
                else
                {
                    strSqlCount = "select count(*)as 记录数 from item_information";
                    strSqlQuery = "select * from item_information";
                    ConditionQuery(dataGridView4);
                    ConditionCount(label23);
                    strSqlCount = "select count(*)as 完成数 from item_information where 已完成 = 1";
                    ConditionCount(label20);
                }
            }
        }
        private string connStr = Connection.ConnStr;
        Connection ct = new Connection();

        private void ConditionQuery(DataGridView dgv)
        {
            dgv.Rows.Clear();
            SqlDataReader reader = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand storers = conn.CreateCommand();
                storers.CommandText = strSqlQuery;
                conn.Open();
                using (reader = storers.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return;
                    }
                }
                using (reader = storers.ExecuteReader())
                {
                    BindingSource Bs = new BindingSource();
                    Bs.DataSource = reader;
                    dgv.DataSource = Bs;
                }
            }
        }

        private void ConditionCount(Label lb1, Label lb2, Label lb3)
        {
            SqlDataReader reader = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand storers = conn.CreateCommand();
                storers.CommandText = strSqlCount;
                conn.Open();
                using (reader = storers.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lb1.Text = reader[0].ToString().Trim();
                        lb2.Text = reader[1].ToString().Trim();
                        lb3.Text = reader[2].ToString().Trim();
                    }
                }
            }
        }

        private void ConditionCount(Label lb)
        {
            SqlDataReader reader = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand storers = conn.CreateCommand();
                storers.CommandText = strSqlCount;
                conn.Open();
                using (reader = storers.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lb.Text = reader[0].ToString().Trim();
                    }
                }
            }
        }


        DataTable dtSource = new DataTable();
        private void ExportCSV()
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "(逗号分隔值)*.csv|*.csv"
                };
                sfd.RestoreDirectory = true;
                if (DialogResult.OK == sfd.ShowDialog())
                {
                    dateTabletoCSV.dataTableToCsv(dtSource, sfd.FileName);
                    if (MessageBox.Show("导出成功,点击 [是] 后打开文件所在位置", "导出成功", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        dateTabletoCSV.ClickOpenLocation(sfd.FileName);
                }
            }
            catch { MessageBox.Show("导出失败"); };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtSource=GetDgvToTable(dataGridView1);
            ExportCSV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dtSource = GetDgvToTable(dataGridView2);
            ExportCSV();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dtSource = GetDgvToTable(dataGridView4);
            ExportCSV();
        }

        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtSource = GetDgvToTable(dataGridView3);
            ExportCSV();
        }

        private void DeleteInformation(DataGridView dgv,string cellname,string storename)
        {
            string str = dgv.CurrentRow.Cells[cellname].Value.ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    var Purview_paras = new SqlParameter[]
                    {

                    };
                    string DeleteSqlStr = $"DELETE FROM {storename} WHERE {cellname} = {str}";
                    if(cellname == "物资编号")
                        DeleteSqlStr = $"DELETE FROM {storename} WHERE {cellname} = '{str}'";
                    var isUpdateSucceed = ct.DeleteData(conn, tran, DeleteSqlStr, Purview_paras);
                    if (isUpdateSucceed)
                    {
                        tran.Commit();
                        MessageBox.Show("删除记录成功");
                        //Close();
                    }
                    else
                    {
                        tran.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show($"删除记录失败:{ex}");
                };
            }
        }

        private bool ConditionCount(string str)
        {
            SqlDataReader reader = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand storers = conn.CreateCommand();
                storers.CommandText = $"select 数量 FROM storehouse where 物资编号 ='{str}'";
                conn.Open();
                using (reader = storers.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal dl = (decimal)reader["数量"];
                        if (dl > 0)
                            return true;
                    }
                }
            }
            return false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string str = this.dataGridView1.CurrentRow.Cells["物资编号"].Value.ToString();
            if (ConditionCount(str))
            {
                MessageBox.Show("该物资还有库存！为了不影响其他操作，请等该物资无库存的时候再删除此记录！");
                return;
            }
            if (MessageBox.Show("该操作执行后无法恢复,是否继续?","提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                DeleteInformation(dataGridView1, "入库序号","in_goods");
            btQuery_Click(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string str = this.dataGridView2.CurrentRow.Cells["物资编号"].Value.ToString();
            if (ConditionCount(str))
            {
                MessageBox.Show("该物资还有库存！为了不影响其他操作，请等该物资无库存的时候再删除此记录！");
                return;
            }
            if (MessageBox.Show("该操作执行后无法恢复,是否继续?","提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                DeleteInformation(dataGridView2, "出库序号", "out_goods");
            btQuery_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string str = this.dataGridView3.CurrentRow.Cells["物资编号"].Value.ToString();
            if (ConditionCount(str))
            {
                MessageBox.Show("该物资还有库存！为了不影响其他操作，请等该物资无库存的时候再删除此记录！");
                return;
            }
            if (MessageBox.Show("该操作执行后无法恢复,是否继续?","提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                DeleteInformation(dataGridView3, "物资编号", "storehouse");
            btQuery_Click(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cb_Item_Query.Text.Trim())&& String.IsNullOrEmpty(cb_Item_Query2.Text.Trim()))
            {
                strSqlQuery = $"select out_goods.* from out_goods where out_goods.项目编号 in (select item_information.项目编号 from item_information where item_information.{cb_Item_Condition.Text} ='{cb_Item_Query.Text}')";
                ConditionQuery(dataGridView5);
                label36.Text = dataGridView5.Rows.Count.ToString();
            }
            else if (!String.IsNullOrEmpty(cb_Item_Query.Text.Trim()) && !String.IsNullOrEmpty(cb_Item_Query2.Text.Trim()))
            {
                if (cb_Item_Condition.Text != cb_Item_Condition2.Text)
                {
                    strSqlQuery = $"select out_goods.* from out_goods where out_goods.项目编号 in (select item_information.项目编号 from item_information where item_information.{cb_Item_Condition.Text} ='{cb_Item_Query.Text}' AND  item_information.{cb_Item_Condition2.Text} ='{cb_Item_Query2.Text}')";
                    ConditionQuery(dataGridView5);
                    label36.Text = dataGridView5.Rows.Count.ToString();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dtSource = GetDgvToTable(dataGridView5);
            ExportCSV();
        }
    }
}
