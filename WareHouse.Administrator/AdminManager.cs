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
    public partial class AdminManager : Form
    {
        public AdminManager()
        {
            InitializeComponent();
        }
        private string connStr = Connection.ConnStr;
        Connection ct = new Connection();
        string strSqlQuery = "SELECT 操作员编号,操作员姓名,操作权限 FROM purview ORDER BY 操作员编号";
        string strSqlQueryAll = "SELECT * FROM purview ORDER BY 操作员编号";
        private void AdminManager_Load(object sender, EventArgs e)
        {
            ConditionQuery(dgvAdmin);
        }
        Dictionary<string, bool[]> AdminPurview = new Dictionary<string, bool[]>();
        Dictionary<string, string> AdminPurview2 = new Dictionary<string, string>();
        HashSet<string> AdminCode = new HashSet<string>();
        private void ConditionQuery(DataGridView dgv)
        {

            SqlDataReader reader = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand storers = conn.CreateCommand();
                storers.CommandText = strSqlQueryAll;
                conn.Open();
                using (reader = storers.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            string Admin = reader.GetString(0);//操作员编号,操作权限
                            bool[] purview = new bool[] { reader.GetBoolean(3), reader.GetBoolean(4), reader.GetBoolean(5), reader.GetBoolean(6), reader.GetBoolean(7) };
                            AdminPurview.Add(Admin, purview);
                            AdminPurview2.Add(Admin, reader.GetString(8));
                            AdminCode.Add(Admin.Trim());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                storers.CommandText = strSqlQuery;
                using (reader = storers.ExecuteReader())
                {
                    BindingSource Bs = new BindingSource();
                    Bs.DataSource = reader;
                    dgv.DataSource = Bs;
                }
            }
            dgvAdmin_Load();
        }

        private void dgvAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAdmin_Load();

        }

        private void dgvAdmin_Load()
        {
            string str = this.dgvAdmin.CurrentRow.Cells["操作员编号"].Value.ToString();
            if (AdminPurview2[str] == "系统管理员")
            {
                rbSystemAdmin.Checked = true;
            }
            else
            {
                rbBasicAdmin.Checked = true;
            }
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
                string str = this.dgvAdmin.CurrentRow.Cells["操作员编号"].Value.ToString();
                var pur = AdminPurview[str];
                checkBox1.Checked = pur[0];
                checkBox2.Checked = pur[1];
                checkBox3.Checked = pur[2];
                checkBox4.Checked = pur[3];
                checkBox5.Checked = pur[4];
            }
        }

        private void ModifyAdminPurview()
        {
            string str = this.dgvAdmin.CurrentRow.Cells["操作员编号"].Value.ToString();
            string pur = rbSystemAdmin.Text;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                if (rbBasicAdmin.Checked)
                    pur = rbBasicAdmin.Text;

                try
                {
                    var Purview_paras = new SqlParameter[]
                {
                    new SqlParameter("@仓库管理",checkBox1.Checked),
                    new SqlParameter("@查询",checkBox2.Checked),
                    new SqlParameter("@报表",checkBox3.Checked),
                    new SqlParameter("@系统维护",checkBox4.Checked),
                    new SqlParameter("@数据库管理",checkBox5.Checked),
                    new SqlParameter("@操作权限",pur),
                };
                    string UpdateSqlStr = $"UPDATE purview SET 仓库管理 = @仓库管理,查询 = @查询,报表=@报表,系统维护= @系统维护,数据库管理=@数据库管理,操作权限= @操作权限 WHERE 操作员编号 = {str}";
                    var isUpdateSucceed = ct.UpdateData(conn, tran, UpdateSqlStr, Purview_paras);
                    if (isUpdateSucceed)
                    {
                        tran.Commit();
                        MessageBox.Show("权限修改成功");
                        AdminPurview.Clear();
                        AdminPurview2.Clear();
                        ConditionQuery(dgvAdmin);
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
                    MessageBox.Show($"权限修改失败:{ex}");
                };
            }
        }

        private void btModify_Click(object sender, EventArgs e)
        {
            string str = dgvAdmin.CurrentRow.Cells["操作员编号"].Value.ToString().Trim();
            str +="["+dgvAdmin.CurrentRow.Cells["操作员姓名"].Value.ToString().Trim()+"]";
            if (MessageBox.Show($"确定要修改{str}的权限吗", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                ModifyAdminPurview();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            string str = dgvAdmin.CurrentRow.Cells["操作员编号"].Value.ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    var Purview_paras = new SqlParameter[]
                {
                    
                };
                    string DeleteSqlStr = $"DELETE FROM purview WHERE 操作员编号 = {str}";
                    var isUpdateSucceed = ct.DeleteData(conn, tran, DeleteSqlStr, Purview_paras);
                    if (isUpdateSucceed)
                    {
                        tran.Commit();
                        MessageBox.Show("删除操作员成功");
                        AdminCode.Clear();
                        AdminPurview.Clear();
                        AdminPurview2.Clear();
                        ConditionQuery(dgvAdmin);
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
                    MessageBox.Show($"删除操作员失败:{ex}");
                };
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            AddAdmin aa = new AddAdmin(AdminCode);
            aa.ShowDialog();
            AdminPurview.Clear();
            AdminCode.Clear();
            AdminPurview2.Clear();
            ConditionQuery(dgvAdmin);
        }
    }
}
