using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commen;
using T.Models;
using System.Data.SqlClient;
using System.Data;
namespace T.DAL
{
    public class Stu_ClassSqureDAL
    {

        /// <summary>
        /// 插入所留的语言
        /// </summary>
        /// <param name="account"></param>
        /// <param name="accountRemark"></param>
        /// <returns></returns>
        public bool WriteRemark(string account, string accountRemark)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert  into Stu_ClassSqure(name,remark,createTime)  ");
            str.Append(" values(@name,@remark,@dateTime )");
            SqlParameter[] param = { 
                                   new SqlParameter("@name",SqlDbType.NVarChar),
                                   new SqlParameter("@remark",SqlDbType.NVarChar),
                                   new SqlParameter("@dateTime",SqlDbType.DateTime)
                                   };
            param[0].Value = account;
            param[1].Value = accountRemark;
            param[2].Value = DateTime.Now;
            int row = SqlHelp.ExecuteNonQuery(str.ToString(), CommandType.Text, param);
            if (row > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获得留言表中的所有数据
        /// </summary>
        /// <returns></returns>
        public List<T.Models.Stu_ClassSqure>  GetLeaveWord(int pageIndex, int pageSize, string keyWord, ref int totalCount, ref int pageCount)
        {
            if (String.IsNullOrWhiteSpace(keyWord))
            {
                keyWord = "%";
            }
            SqlParameter[] param = {
                       new   SqlParameter("@pageIndex",SqlDbType.Int,4),
                       new  SqlParameter("@pageSize",SqlDbType.Int,4),
                       new  SqlParameter("@totalCount",SqlDbType.Int,4),
                       new   SqlParameter("@pageCount",SqlDbType.Int,4),
                       new   SqlParameter("@keyWord",SqlDbType.VarChar,5000)
                                     
                                   };
            param[0].Value = pageIndex;
            param[1].Value = pageSize;
            param[2].Direction = ParameterDirection.InputOutput;//输出参数
            param[3].Direction = ParameterDirection.InputOutput;//输出参数
            param[4].Value = keyWord.ToString();
            //执行存储过程
            DataTable dt = SqlHelp.ExecuteTable("LeaveWordwebpage", CommandType.StoredProcedure, param);
            //接收输出参数
            totalCount = Convert.ToInt32(param[2].Value);
            pageCount = Convert.ToInt32(param[3].Value);
            return Commen.DbTranslate.Translate<Stu_ClassSqure>(dt);
        }

    }
}
