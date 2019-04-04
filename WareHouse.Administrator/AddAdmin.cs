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
namespace WareHouse.Administrator
{
    public partial class AddAdmin : Form
    {
        public AddAdmin()
        {
            InitializeComponent();
        }

        public AddAdmin(HashSet<string> hs)
        {
            InitializeComponent();
            this.hs =new HashSet<string>(hs);
            rbSystemAdmin.Checked = true;
        }
        private string connStr = Connection.ConnStr;
        Connection ct = new Connection();
        HashSet<string> hs = new HashSet<string>();
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!hs.Add(comboBox1.Text))
            {
                MessageBox.Show("编号已存在");
                return;
            }
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("两次密码输入不同,请重新输入");
                Clear();
                return;
            }
            InsertAdmin();
        }

        private void InsertAdmin()
        {
            string admintype = "系统管理员";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                if (rbBasicAdmin.Checked)
                    admintype = "基本管理员";
                try
                {
                    var Purview_paras = new SqlParameter[]
                    {
                        new SqlParameter("@操作员编号",comboBox1.Text),
                        new SqlParameter("@操作员姓名",textBox3.Text),
                        new SqlParameter("@密码",textBox1.Text),
                        new SqlParameter("@仓库管理",checkBox1.Checked),
                        new SqlParameter("@查询",checkBox2.Checked),
                        new SqlParameter("@报表",checkBox3.Checked),
                        new SqlParameter("@系统维护",checkBox4.Checked),
                        new SqlParameter("@数据库管理",checkBox5.Checked),
                        new SqlParameter("@操作权限",admintype),
                    };
                    string DeleteSqlStr = "INSERT INTO purview (操作员编号,操作员姓名,密码,仓库管理,查询,报表,系统维护,数据库管理,操作权限)" +
                        "VALUES(" +
                        "@操作员编号, @操作员姓名, @密码, @仓库管理, @查询, @报表, @系统维护, @数据库管理, @操作权限)";
                    var isDeleteSucceed = ct.AddData(conn, tran, DeleteSqlStr, Purview_paras);
                    if (isDeleteSucceed)
                    {
                        tran.Commit();
                        MessageBox.Show("添加操作员成功");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("添加操作员失败");
                        tran.Rollback();
                        Clear();
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show($"添加操作员失败:{ex}");
                };
            }
        }

        private void Clear()
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void rbSystemAdmin_Click(object sender, EventArgs e)
        {
            if (rbSystemAdmin.Checked)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
            }
        }

        private void rbBasicAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBasicAdmin.Checked)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
            }
        }

    }
}
