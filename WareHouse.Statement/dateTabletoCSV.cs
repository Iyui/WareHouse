using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using WareHouse.ConnStr;
using System.Windows.Forms;
namespace WareHouse.Statement
{
    class dateTabletoCSV
    {
        static string connStr = Connection.ConnStr;
        public static void dataTableToCsv(DataTable table, string file)
        {
            FileInfo fi = new FileInfo(file);
            string path = fi.DirectoryName;
            string name = fi.Name;
            //\/:*?"<>|
            //把文件名和路径分别取出来处理
            name = name.Replace(@"\", "＼");
            name = name.Replace(@"/", "／");
            name = name.Replace(@":", "：");
            name = name.Replace(@"*", "＊");
            name = name.Replace(@"?", "？");
            name = name.Replace(@"<", "＜");
            name = name.Replace(@">", "＞");
            name = name.Replace(@"|", "｜");
            string title = "";

            FileStream fs = new FileStream(path + "\\" + name, FileMode.Create);
            StreamWriter sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.Default);

            for (int i = 0; i < table.Columns.Count; i++)
            {
                title += table.Columns[i].ColumnName + ",";
            }
            title = title.Substring(0, title.Length - 1) + "\n";
            sw.Write(title);

            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                string line = "";
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    line += row[i].ToString().Replace(",", "") + ",";
                }
                line = line.Substring(0, line.Length - 1) + "\n";

                sw.Write(line);
            }
            sw.Close();
            fs.Close();
        }

        public static void ClickOpenLocation(string location)
        {
            System.Diagnostics.Process.Start("Explorer", "/select," + @location);
        }

        public static void ConditionQuery(DataGridView dgv,string strSqlQuery)
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
    }
}
