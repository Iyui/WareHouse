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
                        modifyItem();
                    }
                    else
                    {
                        if (MessageBox.Show("项目中没有此项目,是否要添加?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            AddItem();
                        }
                    }
                }
            }
        }
        private void AddItem()
        {

        }

        private void modifyItem()
        {

        }
    }
}
