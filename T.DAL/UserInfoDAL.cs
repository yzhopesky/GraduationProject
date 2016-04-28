using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.Models;
using System.Data;
using System.Data.SqlClient;
using Commen;

namespace T.DAL
{
    public class UserInfoDAL
    {
        ////获取所有的数据
        //public List<UserInfo> GetAllData()
        //{
        //    string sql = "";//sql语言！
        //    DataTable dt = SqlHelp.ExecuteTable(sql, CommandType.Text);
        //    return DDToList(dt);
        //}
        ////执行增加
        //public int Add(UserInfo u)
        //{
        //    string sql = "insert into XX()  values(@XX)";//sql @XX
        //    SqlParameter[] param = { 
        //                           new SqlParameter("@XX",u.Name){Value=u.Name},
        //                           };
        //    return SqlHelp.ExecuteNonQuery(sql, CommandType.Text, param);
        //}
        ////执行删除
        //public int Delete(int id)
        //{
        //    string sql = "delete from XX where Id=" + id;
        //    return SqlHelp.ExecuteNonQuery(sql, CommandType.Text);
        //}
        ////执行修改
        //public int Update(UserInfo u)
        //{
        //    string sql = "update XX set Name=@name";
        //    SqlParameter[] param = {
        //                           new SqlParameter("@name",){Value=u.Name},
        //                           };
        //    return SqlHelp.ExecuteNonQuery(sql,CommandType.Text,param);
        //}
        ////关系转对象。
        //public List<UserInfo> DDToList(DataTable dt)
        //{
        //    List<UserInfo> list = new List<UserInfo>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        UserInfo u = new UserInfo();
        //        u.Name = dr[""].ToString();
        //        u.Age = Convert.ToInt32(dr[""]);
        //        list.Add(u);
        //    }
        //    return list;
        //}
    }
}
