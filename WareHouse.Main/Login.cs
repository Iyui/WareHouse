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
namespace Shgarden.WareHouse
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“storemanageDataSet.purview”中。您可以根据需要移动或删除它。
            this.purviewTableAdapter.Fill(this.storemanageDataSet.purview);

        }

        private void bt_Login_Click(object sender, EventArgs e)
        {
            string connStr = Connection.ConnStr;// windwos 身份验证方式
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sqlStr = string.Format("select count(*) from purview where 操作员姓名='{0}'and 密码='{1}'", cbUserName.Text, tbPassword.Text);//内部使用,用户名及密码不使用hash加密
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    conn.Open();
                    int n = Convert.ToInt32(cmd.ExecuteScalar());
                    if (n > 0)
                    {
                        HomePage hp = new HomePage();
                        hp.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("登陆失败");
                }
            }
        }
    }
}
