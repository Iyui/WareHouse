using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace WareHouse.ConnStr
{
    public class Connection
    {
        public static string ConnStr { get; } = @"server=.;database=storemanage;Integrated Security = True";

        /// <summary>
        /// 数据库添加数据
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool AddData(SqlConnection conn, SqlTransaction tran, string sqlStr, params SqlParameter[] parameter)
        {
            try
            {
                //conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddRange(parameter);
                cmd.Transaction = tran;
                var row = cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("添加数据异常" + ex.Message);
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sqlStr">查询语句</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        public DataTable QueryData(SqlConnection conn, string sqlStr, params SqlParameter[] parameter)
        {
            try
            {

                //conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                DataSet dt = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.Parameters.AddRange(parameter);
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                //conn.Close();
                return dt.Tables[0];

            }
            catch (Exception ex)
            {
                throw new ApplicationException("查询数据异常" + ex.Message);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sqlStr">删除语句</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        public static bool DeleteData(SqlTransaction tran, string sqlStr, params SqlParameter[] parameter)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    cmd.Parameters.AddRange(parameter);
                    var row = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (row > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("删除数据异常" + ex.Message);
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sqlStr">更新语句</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        public bool UpdateData(SqlConnection conn, SqlTransaction tran, string sqlStr, params SqlParameter[] parameter)
        {
            try
            {
                // conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddRange(parameter);
                cmd.Transaction = tran;
                var row = cmd.ExecuteNonQuery();

                //conn.Close();
                if (row > 0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("更新数据异常" + ex.Message);
            }
        }


    }
}
