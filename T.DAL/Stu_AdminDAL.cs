using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commen;
namespace T.DAL
{
    public class Stu_AdminDAL
    {
        /// <summary>
        /// 判断是否存在此用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <param name="typeID">类型</param>
        /// <returns></returns>
        public bool Exist(string account, string password, int typeID,ref int id)
        {
            int ex=0;
            //StringBuilder str = new StringBuilder();
            //str.Append(" select COUNT(1) from Stu_AdminUser ");
            //str.Append(" WHERE fullName=@fullName and password=@password and roleId=@roleId ");
            SqlParameter[] param = { 
                                   new SqlParameter("@userName",SqlDbType.VarChar),
                                   new SqlParameter("@userpassword",SqlDbType.VarChar),
                                   new  SqlParameter("@typeId",SqlDbType.VarChar),
                                   new  SqlParameter("@exist", SqlDbType.Int),
                                   new  SqlParameter("@id", SqlDbType.Int)
                                   
                                                                      };
            param[0].Value = account;
            param[1].Value = password;
            param[2].Value = typeID.ToString();
            param[3].Direction = ParameterDirection.InputOutput;
            param[4].Direction = ParameterDirection.InputOutput;
            DataTable dt = SqlHelp.ExecuteTable("LoginAdminUser", CommandType.StoredProcedure, param);
            ex = Convert.ToInt32(param[3].Value);
            id = Convert.ToInt32(param[4].Value);
            if (ex>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AlterPassWord(string account, string password)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update Stu_AdminUser  ");
            str.Append("   set   [password] =@password , updateTime=GETDATE()  ");
            str.Append(" where fullName=@fullName  ");
            SqlParameter[] param = { 
                                   new SqlParameter("@password",SqlDbType.VarChar),
                                   new SqlParameter("@fullName",SqlDbType.VarChar)
                                                 };
            param[0].Value = password;
            param[1].Value = account;

            int row = SqlHelp.ExecuteNonQuery(str.ToString(), CommandType.Text, param);
            if (row > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fullName"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool AddAdmin(int id, string fullName, string password, int roleId)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into Stu_AdminUser ");
            str.Append(" (id,fullName,[password],roleId,isDelete,createTime,updateTime) ");
            str.Append(" values ");
            str.Append(" (@id,@fullName,@pass,@roleId,@isDelete,@createTime,@updateTime) ");
            SqlParameter[] param = {
                         new  SqlParameter("@id",SqlDbType.Int),          
                          new  SqlParameter("@fullName",SqlDbType.NVarChar),
                          new  SqlParameter("@pass",SqlDbType.NVarChar),
                          new  SqlParameter("@roleId",SqlDbType.Int),
                          new  SqlParameter("@isDelete",SqlDbType.Bit),
                          new  SqlParameter("@createTime",SqlDbType.DateTime),
                          new  SqlParameter("@updateTime",SqlDbType.DateTime),
                                   };
            param[0].Value = id;
            param[1].Value = fullName;
            param[2].Value = password;
            param[3].Value = roleId;
            param[4].Value = false;
            param[5].Value = DateTime.Now;
            param[6].Value = DateTime.Now;
            int row = SqlHelp.ExecuteNonQuery(str.ToString(), CommandType.Text, param);
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        ///  获得最大的ID值
        /// </summary>
        public int GetMaxID()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select isnull(max(id),0)+1 from Stu_AdminUser ");
            int maxID = SqlHelp.GetMaxID(str.ToString());
            return maxID;
        }

    }
}
