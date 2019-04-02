using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using WareHouse.ConnStr;
using System.Windows.Forms;

namespace WareHouse.Main
{
    public partial class GoodsOutStore : Form
    {
        public GoodsOutStore()
        {
            InitializeComponent();
            dateTime.CustomFormat = "yyyy-MM-dd";

        }
        private string connStr = Connection.ConnStr;

        private void tbwuzibianhao_TextChanged(object sender, EventArgs e)
        {
            cbPinming.Clear();
            cbGuige.Clear();
            tbUnitPrice.Clear();
            tbJiliangdanwei.Clear();
            tbKucunliang.Clear();
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
                        cbPinming.Text = reader.GetString(1).Trim();
                        cbGuige.Text = reader.GetString(2).Trim();
                        tbJiliangdanwei.Text = reader.GetString(3).Trim();
                        tbUnitPrice.Text = Convert.ToString(reader.GetDecimal(5)).Trim();
                        //tbDanjia.Text = reader.GetString(4).Trim();
                    }
                }
            }
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sqlStr = string.Format("select 数量 from storehouse where 物资编号='" + cbWuzibianhao.Text.Trim() + "'");//此处可以注入式攻击,以后再改
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = sqlStr;
                    conn.Open();
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        tbKucunliang.Text = Convert.ToString(reader.GetDecimal(0)).Trim();
                    }
                }
            }
        }

        private void GoodsOutStore_Load(object sender, EventArgs e)
        {
            cbXiangmu_load();
            listCombobox = new List<string>(getComboboxItems(cblingliaoren));
        }

        public int ItemsCount
        {
            get;set;
        }

        private void cbXiangmu_load()
        {
            SqlDataReader reader = null;
            //string connStr = Connection.ConnStr;// windwos 身份验证方式
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sqlStr = string.Format("select * from item_information order by 项目编号");//此处可以注入式攻击,以后再改
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = sqlStr;
                    conn.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string items = "";
                        var read = reader[0];
                        if (read != null && !String.IsNullOrEmpty(read.ToString()))
                            items += read.ToString().Trim();
                        read = reader[1];
                        if (read != null && !String.IsNullOrEmpty(read.ToString()))
                            items += "/" + read.ToString().Trim();
                        read = reader[2];
                        if (read != null && !String.IsNullOrEmpty(read.ToString()))
                            items += "/" + read.ToString().Trim();
                        read = reader[3];
                        if (read != null && !String.IsNullOrEmpty(read.ToString()))
                            items += "/" + read.ToString().Trim();
                        if (!String.IsNullOrEmpty(items))
                            cbXiangmu.Items.Add(items);
                        items = "";
                    }
                }
            }
            cbXiangmu.SelectedIndex = 0;
        }

        private void bt_OutStore_Click(object sender, EventArgs e)
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
           // Connection ct = new Connection();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    if(!Get_goods_paras(out SqlParameter[] Out_goods_paras, out SqlParameter[] storehouse_paras))
                    {
                        tran.Rollback(); //有错就回滚
                        return;
                    }
                    //isMeetConditions();
                    string ingoodsSql = "INSERT INTO out_goods (" +
                        "物资编号,品名,规格,计量单位," +
                        "库存单价,数量,金额,结存数量,结存金额," +
                        "领料部门,领料人,领料日期,项目编号," +
                        "出库单编号,备注) " +
                        "VALUES(" +
                         "@物资编号,@品名,@规格,@计量单位," +
                        "@库存单价,@数量,@金额,@结存数量,@结存金额," +
                        "@领料部门,@领料人,@领料日期,@项目编号," +
                        "@出库单编号,@备注)";

                    string goodstoreSql = $"update storehouse set 数量 = @数量, 库存单价 = @库存单价, 金额 = @金额 WHERE 物资编号 = '{ cbWuzibianhao.Text.Trim()}' ";
                    var isoutgoodSucceed = ct.AddData(conn, tran, ingoodsSql, Out_goods_paras);
                    var isStorehouseSucceed = ct.UpdateData(conn, tran, goodstoreSql, storehouse_paras);
                    if (isoutgoodSucceed && isStorehouseSucceed)
                    {
                        tran.Commit();
                        MessageBox.Show("出库成功");
                        //Clear();
                    }
                    else
                    {
                        tran.Rollback();
                        string reason = "";
                        if (!isoutgoodSucceed)
                            reason += "出库表无写入";
                        if (!isStorehouseSucceed)
                            reason += "货物表无写入";
                        MessageBox.Show($"出库失败:{reason}");
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback(); //有错就回滚
                    MessageBox.Show($"出库失败:{ex}");
                }
                finally { conn.Close(); }
            }
        }

        private bool SetStorehouse(out decimal GoodsQuantity, out decimal storedanjia, out decimal storejine, out string jiecunjine, out string jiecunshuliang)
        {
            storejine = 0;
            jiecunjine = "0";
            jiecunshuliang = "0";
            GoodsQuantity = 0;
            storedanjia = 0;
            var goodcode = cbWuzibianhao.Text.Trim();//物资编号
            var goodname = cbPinming.Text.Trim();//品名
            var guige = cbGuige.Text.Trim();//规格
            //var danwei = tbJiliangdanwei.Text.Trim();//计量单位
            var shuliang = tbQuantity.Text.Trim();//数量
            var danjia = tbUnitPrice.Text.Trim();//单价
            //var jine = tbPrices.Text.Trim();//金额
            var bumen = cbbumen.Text.Trim();//使用部门
            var rukudan = tbChukudan.Text.Trim();//出库单编号
            var jiaokuren = cblingliaoren.Text.Trim();//缴库人
                                                      //var fapiao = tbfapiaobianhao.Text.Trim();//发票编号
                                                      // var gonghuo = tbgonghuodanwei.Text.Trim();//供货单位
                                                      //var zhizao = tbzhizaochangjia.Text.Trim();//制造厂家
            var beizhu = tbbeizhu.Text.Trim();//备注
            var time = dateTime.Value.ToString();//领料日期
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string store = string.Format("select * from storehouse where 物资编号='" + goodcode + "'");

                SqlDataReader reader = null;
                SqlCommand storers = conn.CreateCommand();
                storers.CommandText = store;
                conn.Open();

                using (reader = storers.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        GoodsQuantity = (decimal)reader["数量"] - Convert.ToDecimal(shuliang);
                        if (GoodsQuantity < 0)
                        {
                            MessageBox.Show($"出库物资的数量比库存数量还多！请核对出库数量！库存数量为[{reader["数量"].ToString()}]{reader["计量单位"].ToString()}");
                            reader.Close();
                            tbQuantity.Focus();
                            return false;
                        }

                        if (!String.IsNullOrEmpty(reader["库存单价"].ToString()))
                        {
                            storedanjia = (decimal)reader["库存单价"];
                        }

                        if (!String.IsNullOrEmpty(reader["金额"].ToString()))
                        {
                            storejine = (decimal)reader["库存单价"] * GoodsQuantity;
                        }
                        else
                        {
                            storejine = 0;
                        }
                        jiecunshuliang = GoodsQuantity.ToString("#0.000000");
                        jiecunjine = storejine.ToString("#0.000000");
                    }
                    else
                    {
                        MessageBox.Show($"此物品在库中不存在,请核对编号是否有误？或先将该物品入库！");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool Get_goods_paras(out SqlParameter[] Out_goods_paras, out SqlParameter[] storehouse_paras)
        {
            var goodcode = cbWuzibianhao.Text.Trim();//物资编号
            var goodname = cbPinming.Text.Trim();//品名
            var guige = cbGuige.Text.Trim();//规格
            var danwei = tbJiliangdanwei.Text.Trim();//计量单位

            decimal shuliang = decimal.Parse(tbQuantity.Text.Trim());//数量
            //decimal danjia = decimal.Parse(tbUnitPrice.Text.Trim());//单价
            //decimal jine = decimal.Parse(tbPrices.Text.Trim());//金额
            var bumen = cbbumen.Text.Trim();//领取部门
            var chukudan = tbChukudan.Text.Trim();//入库单编号
            var lingliaoren = cblingliaoren.Text.Trim();//领料人
            var projectcode = cbXiangmu.Text.Substring(0, 4);
            var beizhu = tbbeizhu.Text.Trim();//备注
            DateTime time = dateTime.Value;//缴库日期
            storehouse_paras = new SqlParameter[] { };
            Out_goods_paras = new SqlParameter[] { };
            if (SetStorehouse(out decimal GoodsQuantity, out decimal storedanjia, out decimal storejine, out string jiecunjine, out string jiecunshuliang))
            {
                decimal djiecunjine = decimal.Parse(jiecunjine);
                decimal djiecunshuliang = decimal.Parse(jiecunshuliang);
                storehouse_paras = new SqlParameter[]
                {
                //不声明变量类型 直接进行复制
                
                new SqlParameter("@库存单价",storedanjia),
                new SqlParameter("@数量",GoodsQuantity),
                new SqlParameter("@金额",storejine),
                };

                Out_goods_paras = new SqlParameter[]
                {
                //不声明变量类型 直接进行复制
                new SqlParameter("@物资编号",goodcode),new SqlParameter("@品名",goodname),
                new SqlParameter("@规格",guige),new SqlParameter("@计量单位",danwei),
                new SqlParameter("@库存单价",storedanjia),new SqlParameter("@数量",shuliang),
                new SqlParameter("@金额",storedanjia*Convert.ToDecimal(shuliang)),
                new SqlParameter("@结存数量",djiecunshuliang),
                new SqlParameter("@结存金额",djiecunjine),
                new SqlParameter("@领料部门",bumen),new SqlParameter("@领料人",lingliaoren),
                new SqlParameter("@领料日期",time),new SqlParameter("@项目编号",projectcode),
                new SqlParameter("@出库单编号",chukudan), new SqlParameter("@备注",beizhu),
                };
                return true;
            }
            else
                return false;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                hasItems();
            }
        }

        private bool hasItems()
        {
            var itemtype = tbItemType.Text.Trim();
            var itemnum = tbItemNum.Text.Trim();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //SqlDataReader reader = null;
                string sqlStr = "";
                if (String.IsNullOrEmpty(itemnum))
                    sqlStr = string.Format("select * from item_information where  项目型号='" + itemtype + "'" + "AND 项目批号 IS null ");//此处可以注入式攻击,以后再改
                else
                    sqlStr = string.Format("select * from item_information where  项目型号='" + itemtype + "'" + "AND 项目批号 = '" + itemnum + "'");//此处可以注入式攻击,以后再改
                                                                                                                                             //   using (SqlCommand command = conn.CreateCommand())
                                                                                                                                             //  {

                //command.CommandText = sqlStr;
                conn.Open();
                var reader = ct.QueryData(conn, sqlStr, new SqlParameter[] { });
                //reader = command.ExecuteReader();
                if (reader.Rows.Count != 0)
                {
                    string items = "";
                    var read = reader.Rows[0][0];
                    if (read != null && !String.IsNullOrEmpty(read.ToString()))
                        items += read.ToString().Trim();
                    read = reader.Rows[0][1];
                    if (read != null && !String.IsNullOrEmpty(read.ToString()))
                        items += "/" + read.ToString().Trim();
                    read = reader.Rows[0][2];
                    if (read != null && !String.IsNullOrEmpty(read.ToString()))
                        items += "/" + read.ToString().Trim();
                    read = reader.Rows[0][3];
                    if (read != null && !String.IsNullOrEmpty(read.ToString()))
                        items += "/" + read.ToString().Trim();
                    if (!String.IsNullOrEmpty(items))
                        cbXiangmu.Text = items;
                    return true;
                }
                //  }
                SqlTransaction tran = conn.BeginTransaction();
                if (MessageBox.Show("此项目不存在！如果确定项目型号和批号输入无误的话，请按 [是] 加入此项目；否则按 [否] 退出重新输入！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string itemSql = $"INSERT INTO item_information(项目编号,项目型号 ,项目批号,已完成) VALUES(@项目编号,@项目型号 ,@项目批号,@已完成) ";
                    ItemsCount = cbXiangmu.Items.Count;
                    var isInsertItemSucceed = ct.AddData(conn, tran, itemSql, Item_para(ItemsCount, out string item));
                    if (isInsertItemSucceed)
                        tran.Commit();
                    else
                    {
                        tran.Rollback();
                        return false;
                    }
                    cbXiangmu.Items.Add(item);
                    cbXiangmu.Text = item;
                }
                else
                    return false;


            }
            return true;

        }
        Connection ct = new Connection();
        private SqlParameter[] Item_para(int itemNum,out string item)
        {
            var item_para = new SqlParameter[]
                {
                //不声明变量类型 直接进行复制
                
                new SqlParameter("@项目编号",(itemNum+1).ToString("0000")),
                new SqlParameter("@项目型号",tbItemType.Text.Trim()),
                new SqlParameter("@项目批号",tbItemNum.Text.Trim()),
                new SqlParameter("@已完成",false),

                };
            item = $"{(itemNum + 1).ToString("0000")}/{tbItemType.Text.Trim()}/{tbItemNum.Text.Trim()}";
            return item_para;
        }

        #region 设置Combobox的方法
        //得到Combobox的数据，返回一个List
        public List<string> getComboboxItems(ComboBox cb)
        {
            //初始化绑定默认关键词
            List<string> listOnit = new List<string>();
            //将数据项添加到listOnit中
            for (int i = 0; i < cb.Items.Count; i++)
            {
                listOnit.Add(cb.Items[i].ToString());
            }
            return listOnit;
        }
        //模糊查询Combobox
        public void selectCombobox(ComboBox cb, List<string> listOnit)
        {
            //输入key之后返回的关键词
            List<string> listNew = new List<string>();
            //清空combobox
            cb.Items.Clear();
            //清空listNew
            listNew.Clear();
            //遍历全部备查数据
            foreach (var item in listOnit)
            {
                if (item.Contains(cb.Text))
                {
                    //符合，插入ListNew
                    listNew.Add(item);
                }
            }
            //combobox添加已经查询到的关键字
            cb.Items.AddRange(listNew.ToArray());
            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            cb.SelectionStart = cb.Text.Length;
            //保持鼠标指针原来状态，有时鼠标指针会被下拉框覆盖，所以要进行一次设置
            Cursor = Cursors.Default;
            //自动弹出下拉框
            cb.DroppedDown = true;
        }
        #endregion
        private List<string> listCombobox;//Combobox的最初Item项
        private void cblingliaoren_TextUpdate(object sender, EventArgs e)
        {
            selectCombobox(cblingliaoren, listCombobox);
        }
    }
}



