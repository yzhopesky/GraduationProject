using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Commen
{
    public class SqlHelp
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        /// <summary>
        /// 使用数据集合的方式执行查询 返回datable
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ct"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string text, CommandType ct, params SqlParameter[] param)
        {
            foreach (SqlParameter parameter in param)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                }
            }
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(text, conn))
                {
                    sda.SelectCommand.CommandType = ct;
                    sda.SelectCommand.Parameters.AddRange(param);
                    sda.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ct"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string text, CommandType ct, params SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand com = new SqlCommand(text, conn))
                {
                    com.CommandType = ct;
                    com.Parameters.AddRange(param);
                    conn.Open();
                    return com.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 执行查询返回首行首列
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ct"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string text, CommandType ct, params SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand com = new SqlCommand(text, conn))
                {
                    com.CommandType = ct;
                    com.Parameters.AddRange(param);
                    conn.Open();
                    return com.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 使用sqldatereader进行查询
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ct"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string text, CommandType ct, params SqlParameter[] param)
        {
            SqlConnection con = new SqlConnection(connStr);
            using (SqlCommand com = new SqlCommand(text, con))
            {
                com.CommandType = ct;
                com.Parameters.AddRange(param);
                con.Open();
                return com.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }


        /// <summary>
        /// 获得最大值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <param name="EnterpriseAccount"></param>
        /// <returns></returns>
        public static int GetMaxID(string strsql)
        {
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
    }

}
