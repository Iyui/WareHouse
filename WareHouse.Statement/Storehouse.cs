using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using WareHouse.ConnStr;
using System.Data.SqlClient;

namespace WareHouse.Statement
{
    public partial class Storehouse : Form
    {
        public Storehouse()
        {
            InitializeComponent();
            ConditionCount(label17, label15, label13, label1);
        }

        private string connStr = Connection.ConnStr;
        public int pageSize = 30;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页
        DataTable dtSource = new DataTable();


        ///LoadPage方法
        /// <summary>
        /// loaddpage方法
        /// </summary>
        private void LoadPage()
        {
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            int beginRecord;
            int endRecord;
            DataTable dtTemp;
            dtTemp = dtSource.Clone();

            beginRecord = pageSize * (currentPage - 1);
            if (currentPage == 1) beginRecord = 0;
            endRecord = pageSize * currentPage;

            if (currentPage == pageCount) endRecord = recordCount;
            for (int i = beginRecord; i < endRecord; i++)
            {
                dtTemp.ImportRow(dtSource.Rows[i]);
            }
            dgv_Storehouse.DataSource = dtTemp;  
            cbPageNum.Text = currentPage.ToString();//当前页
            toolStripLabel2.Text = "/"+pageCount.ToString();//总页数
            toolStripLabel3.Text = "共 "+recordCount.ToString()+" 条记录";//总记录数//
            dgv_Storehouse.Focus();
            
        }

        /// <summary>
        /// 分页的方法
        /// </summary>
        /// <param name="str"></param>
        private void fenye(string str)    //str是sql语句
        {
            SqlDataAdapter sda = new SqlDataAdapter(str, connStr);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dtSource = ds.Tables[0];
            recordCount = dtSource.Rows.Count;
            pageCount = (recordCount / pageSize);
            if ((recordCount % pageSize) > 0)
            {
                pageCount++;
            }
            //默认第一页
            currentPage = 1;
            LoadPage();//调用加载数据的方法
        }

        private void Storehouse_Load(object sender, EventArgs e)
        {
            string str = "select * from storehouse"; //查询语句
            LoadPage(str);
        }

        private void tsb_LastPage_Click(object sender, EventArgs e)
        {
            currentPage--;
            LoadPage();
        }

        private void tsb_NextPage_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadPage();
        }

        private void cbPageNum_TextChanged(object sender, EventArgs e)
        {

            if (int.TryParse(cbPageNum.Text, out int pagenum))
            {
                currentPage = pagenum;
                LoadPage();
            }
            cbPageNum.SelectionStart = cbPageNum.Text.Length;
        }

        private void rbAllinventory_CheckedChanged(object sender, EventArgs e)
        {
            string str = "select * from storehouse"; //这里是你的查询语句
            LoadPage(str);
        }

        private void LoadPage(string str)
        {
            fenye(str);//分页
            LoadPage();//加载数据
            cbPageNum.Items.Clear();
            for (int i = 1; i <= pageCount; i++)
                cbPageNum.Items.Add(i);
        }

        private void rbinventory_CheckedChanged(object sender, EventArgs e)
        {
            string str = "select * from storehouse where 数量 > 0"; //这里是你的查询语句
            LoadPage(str);
        }

        private void rbNoinventory_CheckedChanged(object sender, EventArgs e)
        {
            string str = "select * from storehouse where 数量 = 0"; //这里是你的查询语句
          
            LoadPage(str);
        }


        public string strSqlCount
        {
            set; get;
        }

        private void tsb_Export_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "(逗号分隔值)*.csv|*.csv"
                };
                if (DialogResult.OK == sfd.ShowDialog())
                {
                    dateTabletoCSV.dataTableToCsv(dtSource, sfd.FileName);
                }
                MessageBox.Show("导出成功,点击确定后打开文件所在位置");
                dateTabletoCSV.ClickOpenLocation(sfd.FileName);
            }
            catch { MessageBox.Show("导出失败"); };
        }

        private void ConditionCount(Label lb1, Label lb2, Label lb3, Label lb4)
        {
            strSqlCount = "select count(*)as 记录数,sum(数量)as 库存总数量,sum(金额)as 总金额 from storehouse ";
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
                strSqlCount = "select count(*) as 未标价 from storehouse where 库存单价 is null or 库存单价 = 0 and 数量 > 0";
                //SELECT   count(DISTINCT 品名) as 未标价 FROM [storemanage].[dbo].[storehouse] where 库存单价 is null or 库存单价 = 0 and 数量 > 0
                //按品名去重
                storers.CommandText = strSqlCount;
                using (reader = storers.ExecuteReader())
                {
                    if (reader.Read())
                        lb4.Text = Convert.ToString(reader[0]).Trim();
                }
            }
        }
    }
}
