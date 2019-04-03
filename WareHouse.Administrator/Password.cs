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
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        public Password(string AdminName,string AdminSerial, string oldpassword)
        {
            InitializeComponent();
            this.AdminSerial = AdminSerial;
            this.oldpassword = oldpassword;
            tbAdmin.Text = AdminName;
        }

        private string connStr = Connection.ConnStr;
        Connection ct = new Connection();
        public string AdminSerial
        {
            get; set;
        }

        public string oldpassword
        {
            get;set;
        }
        private void btConfirm_Click(object sender, EventArgs e)
        {
            if(oldpassword != oldPassword.Text)
            {
                MessageBox.Show("原密码错误");
                return;
            }
            if(newpassword.Text!=confirmPassword.Text)
            {
                MessageBox.Show("确认密码与新密码输入不同,请重新输入");
                newpassword.Text = confirmPassword.Text = "";
                return;
            }
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    var password_paras = new SqlParameter[]
                {
                //不声明变量类型 直接进行赋值 
                    new SqlParameter("@密码",newpassword),
                };
                    string goodstoreSql = $"update purview set 密码 = @密码 WHERE 操作员编号 = '{AdminSerial}' ";
                    var isPasswordSucceed = ct.UpdateData(conn, tran, goodstoreSql, password_paras);
                    if (isPasswordSucceed)
                    {
                        tran.Commit();
                        MessageBox.Show("密码修改成功");
                        Close();
                    }
                    else
                    {
                        tran.Rollback();
                    }
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show($"密码修改失败:{ex}");
                };

            }
        }
    }
}
