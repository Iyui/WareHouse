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
namespace WareHouse.Main
{

    public partial class GoodsInStore : Form
    {
        public GoodsInStore()
        {
            InitializeComponent();
            dateTime.CustomFormat = "yyyy-MM-dd";
        }

        #region 变量及属性
        private string connStr = Connection.ConnStr;
        Connection ct = new Connection();

        #endregion

        //输入物资编号自动查询物资类别
        private void cbWuzibianhao_TextChanged(object sender, EventArgs e)
        {
            cbPinming.Items.Clear();
            cbGuige.Items.Clear();
            cbPinming.Text = "";
            cbGuige.Text = "";
            tbJiliangdanwei.Clear();
            SqlDataReader reader = null;
            //string connStr = Connection.ConnStr;// windwos 身份验证方式
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sqlStr = string.Format("select * from storehouse where  物资编号='" + cbWuzibianhao.Text.Trim() + "'");//此处可以注入式攻击,以后再改
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = sqlStr;
                    conn.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var s = reader.GetString(1).Trim();
                        if (!cbPinming.Items.Contains(s))
                        {
                            cbPinming.Items.Add(s);
                            cbPinming.SelectedIndex = 0;
                        }
                        s = reader.GetString(2).Trim();
                        if (!cbGuige.Items.Contains(s))
                        {
                            cbGuige.Items.Add(s);
                            cbGuige.SelectedIndex = 0;
                        }
                        tbJiliangdanwei.Text = reader.GetString(3).Trim();
                        //tbDanjia.Text = reader.GetString(4).Trim();
                    }
                }
            }
        }

        private void tbUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(tbUnitPrice.Text, out float unitprice) &&
            float.TryParse(tbQuantity.Text, out float quantity))
            {

                tbPrices.Text = (unitprice * quantity).ToString();
            }
            else
            {
                tbPrices.Text = "";
            }
        }

        //单价仅允许输入数字及小数点
        private void tbUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 46)
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        //数量仅允许输入数字
        private void tbQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        //计算总价=单价*数量
        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(tbUnitPrice.Text, out float unitprice) &&
            int.TryParse(tbQuantity.Text, out int quantity))
            {
                tbPrices.Text = (unitprice * quantity).ToString();
            }
            else
            {
                tbPrices.Text = "";
            }
        }

        private void bt_PutIn_Click(object sender, EventArgs e)
        {
            var goodcode = cbWuzibianhao.Text.Trim();//物资编号
            var goodname = cbPinming.Text.Trim();//品名
            var guige = cbGuige.Text.Trim();//规格
            var danwei = tbJiliangdanwei.Text.Trim();//计量单位
            if (String.IsNullOrEmpty(goodcode)
                && String.IsNullOrEmpty(goodname)
                && String.IsNullOrEmpty(guige)
                && String.IsNullOrEmpty(danwei)
                && String.IsNullOrEmpty(tbUnitPrice.Text.Trim())
                && String.IsNullOrEmpty(tbQuantity.Text.Trim()))
            {
                MessageBox.Show("星号标记的栏目不能为空");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    Get_goods_paras(out SqlParameter[] In_goods_paras, out SqlParameter[] storehouse_paras);
                    //isMeetConditions();
                    string ingoodsSql = "INSERT INTO in_goods (" +
                        "物资编号,品名,规格,计量单位," +
                        "缴库单价,数量,金额,结存数量,结存金额," +
                        "缴库日期,供货单位,制造厂家,缴库部门," +
                        "缴库人,入库单编号,发票编号,备注) " +
                        "VALUES(" +
                        "@物资编号,@品名,@规格,@计量单位," +
                        "@缴库单价,@数量,@金额,@结存数量,@结存金额," +
                        "@缴库日期,@供货单位,@制造厂家,@缴库部门," +
                        "@缴库人,@入库单编号,@发票编号,@备注)";

                    string goodstoreSql = $"update storehouse set 数量 = @数量, 库存单价 = @库存单价, 金额 = @金额 WHERE 物资编号 = '{ cbWuzibianhao.Text.Trim()}' ";
                    var isIngoodSucceed = ct.AddData(conn, tran, ingoodsSql, In_goods_paras);
                    var isStorehouseSucceed = ct.UpdateData(conn, tran, goodstoreSql, storehouse_paras);
                    if (isIngoodSucceed && isStorehouseSucceed)
                    {
                        tran.Commit();
                        MessageBox.Show("入库成功");
                        Clear();
                    }
                    else
                    {
                        tran.Rollback();
                        string reason = "";
                        if (!isIngoodSucceed)
                            reason += "入库表无写入";
                        if (!isStorehouseSucceed)
                            reason += "货物表无写入";
                        MessageBox.Show($"入库失败:{reason}");
                    }
                }
                catch(Exception ex)
                {
                    tran.Rollback(); //有错就回滚
                    MessageBox.Show($"入库失败:{ex}");
                }
                finally { conn.Close(); }
            }
        }

        private void Get_goods_paras(out SqlParameter[] In_goods_paras, out SqlParameter[] storehouse_paras)
        {
            var goodcode = cbWuzibianhao.Text.Trim();//物资编号
            var goodname = cbPinming.Text.Trim();//品名
            var guige = cbGuige.Text.Trim();//规格
            var danwei = tbJiliangdanwei.Text.Trim();//计量单位
            
            decimal shuliang = decimal.Parse(tbQuantity.Text.Trim());//数量
            decimal danjia = decimal.Parse(tbUnitPrice.Text.Trim());//单价
            decimal jine = decimal.Parse(tbPrices.Text.Trim());//金额
            var bumen = cbbumen.Text.Trim();//缴库部门
            var rukudan = tbRukudan.Text.Trim();//入库单编号
            var jiaokuren = cbjiaokuren.Text.Trim();//缴库人
            var fapiao = tbfapiaobianhao.Text.Trim();//发票编号
            var gonghuo = tbgonghuodanwei.Text.Trim();//供货单位
            var zhizao = tbzhizaochangjia.Text.Trim();//制造厂家
            var beizhu = tbbeizhu.Text.Trim();//备注
            DateTime time = dateTime.Value;//缴库日期
            SetStorehouse(out string storejine, out string storedanjia, out string storeshuliang, out string jiecunjine, out string jiecunshuliang);
            decimal djiecunjine = decimal.Parse(jiecunjine);
            decimal djiecunshuliang = decimal.Parse(jiecunshuliang);
            decimal dstorejine = decimal.Parse(storejine);
            decimal dstoredanjia = decimal.Parse(storedanjia);
            decimal dstoreshuliang = decimal.Parse(storeshuliang);
            storehouse_paras = new SqlParameter[]
            {
                //不声明变量类型 直接进行复制
                
                new SqlParameter("@库存单价",dstoredanjia),
                new SqlParameter("@数量",dstoreshuliang),
                new SqlParameter("@金额",dstorejine),
            };
            In_goods_paras = new SqlParameter[]
            {
                //不声明变量类型 直接进行复制
                new SqlParameter("@物资编号",goodcode),new SqlParameter("@品名",goodname),
                new SqlParameter("@规格",guige),new SqlParameter("@计量单位",danwei),
                new SqlParameter("@缴库单价",danjia),new SqlParameter("@数量",shuliang),
                new SqlParameter("@金额",jine),new SqlParameter("@结存数量",djiecunshuliang),
                new SqlParameter("@结存金额",djiecunjine),new SqlParameter("@缴库日期",time),
                new SqlParameter("@供货单位",gonghuo),new SqlParameter("@制造厂家",zhizao),
                new SqlParameter("@缴库部门",bumen),new SqlParameter("@缴库人",jiaokuren),
                new SqlParameter("@入库单编号",rukudan),new SqlParameter("@发票编号",fapiao),
                new SqlParameter("@备注",beizhu),
            };
        }

        private bool SetStorehouse(out string storejine, out string storedanjia, out string storeshuliang, out string jiecunjine, out string jiecunshuliang)
        {
            jiecunjine = "0";
            jiecunshuliang = "0";
            storejine = "0";
            storedanjia = "0";
            storeshuliang = "0";
            SqlDataReader reader1 = null;
            var goodcode = cbWuzibianhao.Text.Trim();//物资编号
            var goodname = cbPinming.Text.Trim();//品名
            var guige = cbGuige.Text.Trim();//规格
            var danwei = tbJiliangdanwei.Text.Trim();//计量单位
            var shuliang = tbQuantity.Text.Trim();//数量
            var danjia = tbUnitPrice.Text.Trim();//单价
            var jine = tbPrices.Text.Trim();//金额
            var bumen = cbbumen.Text.Trim();//缴库部门
            var rukudan = tbRukudan.Text.Trim();//入库单编号
            var jiaokuren = cbjiaokuren.Text.Trim();//缴库人
            var fapiao = tbfapiaobianhao.Text.Trim();//发票编号
            var gonghuo = tbgonghuodanwei.Text.Trim();//供货单位
            var zhizao = tbzhizaochangjia.Text.Trim();//制造厂家
            var beizhu = tbbeizhu.Text.Trim();//备注
            var time = dateTime.Value.ToString();//缴库日期
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string store = string.Format("select * from storehouse where 物资编号='" + goodcode + "'");
                string goods = string.Format("select * from goods where 物资编号='" + goodcode + "'");

                SqlCommand storers = conn.CreateCommand();
                SqlCommand goodsrs = conn.CreateCommand();
                //inrs.CommandText = inr;
                storers.CommandText = store;
                goodsrs.CommandText = goods;
                conn.Open();

                using (reader1 = storers.ExecuteReader())
                {
                    if (reader1.Read())
                    {
                        if (reader1["品名"].ToString().Trim() != goodname)
                        {
                            MessageBox.Show("输入的品名与已知的品名不相符！");
                            cbPinming.Text = reader1["品名"].ToString().Trim();

                            reader1.Close();
                            return false;
                        }
                        if (reader1["规格"].ToString().Trim() != guige)
                        {
                            MessageBox.Show("输入的规格与已知的规格不相符！");
                            cbGuige.Text = reader1["规格"].ToString().Trim();

                            reader1.Close();
                            return false;
                        }
                        if (reader1["计量单位"].ToString().Trim() != danwei)
                        {
                            MessageBox.Show("输入的计量单位与已知的计量单位不相符！");
                            tbJiliangdanwei.Text = reader1["计量单位"].ToString().Trim();

                            reader1.Close();
                            return false;
                        }
                    }
                }

                using (reader1 = storers.ExecuteReader())
                {
                    if (reader1.Read())
                        if (danjia != "")
                        {
                            if (reader1["库存单价"].ToString().Trim() != "")
                            {
                                if (float.Parse(danjia) > 0 && float.Parse(reader1["库存单价"].ToString()) > 0)
                                {
                                    var x = Convert.ToSingle(reader1["库存单价"]);
                                    storejine = (Convert.ToSingle(reader1["库存单价"]) * Convert.ToSingle(reader1["数量"]) + float.Parse(danjia) * float.Parse(shuliang)).ToString("#0.000000");
                                    storedanjia = ((Convert.ToSingle(reader1["库存单价"]) * Convert.ToSingle(reader1["数量"]) + float.Parse(danjia) * float.Parse(shuliang))
                                        / (Convert.ToSingle(reader1["数量"]) + float.Parse(shuliang))).ToString("#0.000000");
                                }
                                else
                                {
                                    if (float.Parse(danjia) > 0)
                                    {
                                        storejine = (Convert.ToSingle(reader1["数量"]) + float.Parse(danjia) * float.Parse(shuliang)).ToString("#0.000000");
                                        storedanjia = string.Format(danjia, "#0.000000");
                                    }
                                    else
                                        storejine = ((Convert.ToSingle(reader1["数量"]) + float.Parse(shuliang)) * float.Parse(danjia)).ToString("#0.000000");
                                }
                            }
                            else
                            {
                                if (float.Parse(danjia) > 0)
                                {
                                    storejine = (Convert.ToSingle(reader1["数量"]) + float.Parse(danjia) * float.Parse(shuliang)).ToString("#0.000000");
                                    storedanjia = string.Format(danjia,"#0.000000");
                                }
                            }
                        }
                        else
                        {
                            if (reader1["库存单价"].ToString().Trim() != "")
                            {
                                if (Convert.ToSingle(reader1["库存单价"]) > 0)
                                    storejine = (Convert.ToSingle(reader1["库存单价"]) * Convert.ToSingle(reader1["数量"]) + float.Parse(shuliang)).ToString("#0.000000");
                            }

                        }
                    storeshuliang = (Convert.ToSingle(reader1["数量"]) + float.Parse(shuliang)).ToString("#0.000000");
                    jiecunshuliang = (Convert.ToSingle(reader1["数量"])).ToString("#0.000000");
                    jiecunjine = (Convert.ToSingle(reader1["金额"])).ToString("#0.000000");
                    return true;
                }
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            cbWuzibianhao.Text = "";//物资编号
            cbPinming.Text = "";//品名
            cbGuige.Text = "";//规格
            tbJiliangdanwei.Text = "";//计量单位
            tbQuantity.Text = "";//数量
            tbUnitPrice.Text = "";//单价
            tbPrices.Text = "";//金额
            cbbumen.Text = "";//缴库部门
            tbRukudan.Text = "";//入库单编号
            cbjiaokuren.Text = "";//缴库人
            tbfapiaobianhao.Text = "";//发票编号
            tbgonghuodanwei.Text = "";//供货单位
            tbzhizaochangjia.Text = "";//制造厂家
            tbbeizhu.Text = "";//备注
        }
    }
}
