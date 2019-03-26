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

    public partial class GoodsInStore : Form
    {
        public GoodsInStore()
        {
            InitializeComponent();
            dateTime.CustomFormat = "yyyy-MM-dd";
        }

        #region 变量及属性
        private string connStr = Connection.ConnStr;


        #endregion

        //输入物资编号自动查询物资类别
        private void cbWuzibianhao_TextChanged(object sender, EventArgs e)
        {
            cbPinming.Items.Clear();
            cbGuige.Items.Clear();
            SqlDataReader reader = null;
            //string connStr = Connection.ConnStr;// windwos 身份验证方式
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sqlStr = string.Format("select * from storehouse where  物资编号='" + cbWuzibianhao.Text.Trim() + "'");
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
            if (!char.IsDigit(e.KeyChar)&&e.KeyChar !=46)
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

        //是否满足入库条件
        private bool isMeetConditions()
        {
            SqlDataReader reader = null;
            SqlDataReader reader1 = null;
            SqlDataReader reader2 = null;

            var goodcode = cbWuzibianhao.Text.Trim();//物资编号
            var goodname = cbPinming.Text.Trim();//品名
            var guige = cbGuige.Text.Trim();//规格
            var danwei = tbJiliangdanwei.Text.Trim();//计量单位
            var shuliang = tbQuantity.Text.Trim();//数量
            var danjia = tbUnitPrice.Text.Trim();//单价
            var jine = tbPrices.Text.Trim();//金额
            var bumen = cbbumen.Text.Trim();//缴库部门
            var rukudan = textBox1.Text.Trim();//入库单编号
            var jiaokuren = comboBox2.Text.Trim();//缴库人
            var fapiao = tbfapiaobianhao.Text.Trim();//发票编号
            var gonghuo = tbgonghuodanwei.Text.Trim();//供货单位
            var zhizao = tbzhizaochangjia.Text.Trim();//制造厂家
            var beizhu = tbbeizhu.Text.Trim();//备注
            var time = dateTime.Value.ToString();//缴库日期
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // string sqlStr = string.Format("select * from storehouse where  物资编号='" + cbWuzibianhao.Text.Trim() + "'");
                string inr = "select * from in_goods order by 缴库日期";
                string store = string.Format("select * from storehouse where 物资编号='" + goodcode + "'");
                string goods = string.Format("select * from goods where 物资编号='" + goodcode + "'");
                SqlCommand inrs = conn.CreateCommand();
                SqlCommand storers = conn.CreateCommand();
                SqlCommand goodsrs = conn.CreateCommand();
                inrs.CommandText = inr;
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
                using (reader = inrs.ExecuteReader())
                {
                    //while (reader.Read())
                    //{
                    //    string name = reader["列名2"].ToString();
                    //}
                    inrs.CommandType = CommandType.StoredProcedure;
                    inrs.Parameters.AddWithValue("@物资编号", goodcode);
                    inrs.Parameters.AddWithValue("@品名", goodname);
                    inrs.Parameters.AddWithValue("@规格", guige);
                    inrs.Parameters.AddWithValue("@计量单位", danwei);
                    inrs.Parameters.AddWithValue("@数量", shuliang);
                    inrs.Parameters.AddWithValue("@金额", jine);
                    inrs.Parameters.AddWithValue("@供货单位", gonghuo);
                    inrs.Parameters.AddWithValue("@制造厂家", zhizao);
                    inrs.Parameters.AddWithValue("@缴库日期", time);
                    inrs.Parameters.AddWithValue("@缴库人", jiaokuren);
                    inrs.Parameters.AddWithValue("@缴库部门", bumen);
                    inrs.Parameters.AddWithValue("@入库单编号", rukudan);
                    inrs.Parameters.AddWithValue("@发票编号", fapiao);
                    inrs.Parameters.AddWithValue("@备注", beizhu);
                    
                }
                SqlCommand cmd = new SqlCommand(inr, conn);
                cmd.Parameters.AddWithValue("@钱建华", jiaokuren);
                var z = cmd.ExecuteNonQuery();
                MessageBox.Show("入库成功" + z.ToString());
                using (reader1 = storers.ExecuteReader())
                {
                    if(reader1.Read())
                    if (danjia != "")
                    {
                        if (reader1["库存单价"].ToString().Trim() != "")
                        {
                            if (float.Parse(danjia) > 0 && float.Parse(reader1["库存单价"].ToString()) > 0)
                            {
                                    var x = Convert.ToSingle(reader1["库存单价"]);
                                storers.Parameters.AddWithValue("金额", Convert.ToSingle(reader1["库存单价"]) * Convert.ToSingle(reader1["数量"]) + float.Parse(danjia) * float.Parse(shuliang));
                                storers.Parameters.AddWithValue("库存单价", ((Convert.ToSingle(reader1["库存单价"]) * Convert.ToSingle(reader1["数量"]) + float.Parse(danjia) * float.Parse(shuliang))
                                    / (Convert.ToSingle(reader1["数量"]) + float.Parse(shuliang))).ToString("#0.000000"));
                            }
                            else
                            {
                                if (float.Parse(danjia) > 0)
                                {
                                    storers.Parameters.AddWithValue("金额", (Convert.ToSingle(reader1["数量"] )+ float.Parse(danjia) * float.Parse(shuliang)).ToString("#0.000000"));
                                    storers.Parameters.AddWithValue("库存单价", string.Format("#0.000000", danjia));
                                }
                                else
                                    storers.Parameters.AddWithValue("金额", ((Convert.ToSingle(reader1["数量"]) + float.Parse(shuliang)) * float.Parse(danjia)).ToString("#0.000000"));
                            }
                        }
                        else
                        {
                            if (float.Parse(danjia) > 0)
                            {
                                storers.Parameters.AddWithValue("金额", (Convert.ToSingle(reader1["数量"]) + float.Parse(danjia) * float.Parse(shuliang)).ToString("#0.000000"));
                                storers.Parameters.AddWithValue("库存单价", string.Format("#0.000000", danjia));
                            }
                        }
                    }
                    else
                    {
                        if (reader1["库存单价"].ToString().Trim() != "")
                        {
                            if (Convert.ToSingle(reader1["库存单价"]) > 0)
                                storers.Parameters.AddWithValue("金额", Convert.ToSingle(reader1["库存单价"]) * Convert.ToSingle(reader1["数量"] )+ float.Parse(shuliang));
                        }
                        storers.Parameters.AddWithValue("数量", (Convert.ToSingle(reader1["数量"]) + float.Parse(shuliang)).ToString("#0.000000"));
                    }
                    //inrs.Parameters.AddWithValue("结存数量", ((float)reader1["数量"]));
                    //inrs.Parameters.AddWithValue("结存金额", ((float)reader1["金额"]));
                   
                    //storers.Update();
                    
                }
                
                var y = storers.ExecuteNonQuery();
              
                /*
                 If Not (storers.EOF And storers.BOF) Then
            If txtInprice.Text <> "" Then
               If storers.Fields("库存单价") <> "" Then
                  If (Val(txtInprice.Text) > 0) And (Val(storers.Fields("库存单价")) > 0) Then
                     storers.Fields("金额") = Format(storers.Fields("库存单价") * storers.Fields("数量") + Val(txtInprice.Text) * Val(txtInnumber.Text), "#0.000000")
                     storers.Fields("库存单价") = Format((storers.Fields("库存单价") * storers.Fields("数量") + Val(txtInprice.Text) * Val(txtInnumber.Text)) / (Val(storers.Fields("数量")) + Val(txtInnumber.Text)), "#0.000000")
                  Else
                     If Val(txtInprice.Text) > 0 Then
                        storers.Fields("金额") = Format((storers.Fields("数量") + Val(txtInnumber.Text)) * Val(txtInprice.Text), "#0.000000")
                        storers.Fields("库存单价") = Format(Val(txtInprice.Text), "#0.000000")
                     Else
                        storers.Fields("金额") = Format(storers.Fields("库存单价") * (storers.Fields("数量") + Val(txtInnumber.Text)), "#0.000000")
                     End If
                  End If
               Else
                  If Val(txtInprice.Text) > 0 Then
                        storers.Fields("金额") = Format((storers.Fields("数量") + Val(txtInnumber.Text)) * Val(txtInprice.Text), "#0.000000")
                        storers.Fields("库存单价") = Format(Val(txtInprice.Text), "#0.000000")
                  End If
               End If
            Else
               If storers.Fields("库存单价") <> "" Then
                  If Val(storers.Fields("库存单价")) > 0 Then
                     storers.Fields("金额") = Format(storers.Fields("库存单价") * (storers.Fields("数量") + Val(txtInnumber.Text)), "#0.000000")
                  End If
               End If
               'storers.Fields("金额") = Format(storers.Fields("库存单价") * (storers.Fields("数量") + Val(txtInnumber.Text)), "#0.000000")
            End If
            storers.Fields("数量") = Format(storers.Fields("数量") + Val(txtInnumber.Text), "#0.0000")
         Else
           storers.AddNew
           storers.Fields("物资编号") = Trim(txtCode.Text)
           If cobName.Text <> "" Then storers.Fields("品名") = Trim(cobName.Text)
           If cobSpecification.Text <> "" Then storers.Fields("规格") = Trim(cobSpecification.Text)
           If cobUnits.Text <> "" Then storers.Fields("计量单位") = Trim(cobUnits.Text)
           If txtInprice.Text <> "" Then storers.Fields("库存单价") = Val(txtInprice.Text) Else storers.Fields("库存单价") = 0
           storers.Fields("数量") = Val(txtInnumber.Text)
           If txtRemark.Text <> "" Then storers.Fields("备注") = Trim(txtRemark.Text)
           If txtMoney.Text <> "" Then storers.Fields("金额") = Val(txtMoney.Text) Else storers.Fields("金额") = 0
        End If
        inrs.Fields("结存数量") = storers.Fields("数量")
        inrs.Fields("结存金额") = storers.Fields("金额")
        storers.Update
        inrs.Update
                  */
            }
           
            return false;
        }

        private void bt_PutIn_Click(object sender, EventArgs e)
        {
            isMeetConditions();
        }
    }
}
