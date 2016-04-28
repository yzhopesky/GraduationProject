using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Commen;
using T.Models;
namespace T.DAL
{
    public class Stu_TeacherDAL
    {

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="teacher">教师实体</param>
        /// <returns></returns>
        /// 2015年12月3日17:56:50
        public bool TeacherAdd(Stu_Teacher teacher)
        {
            if (teacher == null)
            {
                teacher = new Stu_Teacher();
                return false;
            }
            StringBuilder str = new StringBuilder();
            str.Append(" insert into Stu_Teacher ");
            str.Append(" (teacherID, teacherName, teacherGender, teacherPhone, teacherAdress, teacherReamrk, teacherIsDelete, teacherBeiYong,teacherDate) ");
            str.Append("  values ");
            str.Append(" ( @teacherID,@teacherName,@teacherGender,@teacherPhone,@teacherAdress,@teacherReamrk, @teacherIsDelete, @teacherBeiYong,@teacherDate ) ");
            SqlParameter[] param = {
                                   new SqlParameter("@teacherID",SqlDbType.Int),
                                   new SqlParameter("@teacherName",SqlDbType.NVarChar),
                                   new SqlParameter("@teacherGender",SqlDbType.NVarChar),
                                   new SqlParameter("@teacherPhone",SqlDbType.NVarChar),
                                   new SqlParameter("@teacherAdress",SqlDbType.NVarChar),
                                   new SqlParameter("@teacherReamrk",SqlDbType.NVarChar),
                                    new SqlParameter("@teacherIsDelete",SqlDbType.Bit),
                                     new SqlParameter("@teacherBeiYong",SqlDbType.NVarChar),
                                     new SqlParameter("@teacherDate",SqlDbType.DateTime)
                                   };
            param[0].Value = teacher.teacherID;
            param[1].Value = teacher.teacherName;
            param[2].Value = teacher.teacherGender;
            param[3].Value = teacher.teacherPhone;
            param[4].Value = teacher.teacherAdress;
            param[5].Value = teacher.teacherReamrk;
            param[6].Value = teacher.teacherIsDelete;
            param[7].Value = teacher.teacherBeiYong;
            param[8].Value = DateTime.Now;

            var row = SqlHelp.ExecuteNonQuery(str.ToString(), CommandType.Text, param);
            if (row > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">要删除的ID</param>
        /// <returns></returns>
        public bool TeacherDelete(int id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update  Stu_Teacher set teacherIsDelete=1  ");
            str.Append(" where teacherID=" + id + " ");
            int row = SqlHelp.ExecuteNonQuery(str.ToString(), CommandType.Text);
            if (row > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teacherName"></param>
        /// <param name="teacherGender"></param>
        /// <param name="teacherPhone"></param>
        /// <param name="teacherAdress"></param>
        /// <returns></returns>
        public bool UpdateTeacher(int id, string teacherName, string teacherGender, string teacherPhone, string teacherAdress)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update Stu_Teacher set ");
            str.Append(" teacherName=@teacherName, teacherGender=@teacherGender, teacherPhone=@teacherPhone, teacherAdress=@teacherAdress ");
            str.Append(" where teacherID=@teacherID ");
            SqlParameter[] param = { 
                                   new SqlParameter("@teacherName",SqlDbType.NVarChar),
                                   new SqlParameter("@teacherGender",SqlDbType.NVarChar),
                                   new SqlParameter("@teacherPhone",SqlDbType.NVarChar),
                                   new SqlParameter("@teacherAdress",SqlDbType.NVarChar),
                                   new SqlParameter("@teacherID",SqlDbType.NVarChar)
                                                                     
                                   };
            param[0].Value = teacherName;
            param[1].Value = teacherGender;
            param[2].Value = teacherPhone;
            param[3].Value = teacherAdress;
            param[4].Value = id;
            var row = SqlHelp.ExecuteNonQuery(str.ToString(), CommandType.Text, param);
            if (row > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 教师查询
        /// </summary>
        /// <param name="pageIndex">查看页数</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="totalCount">总条数</param>
        /// <param name="pageCount">总页数数</param>
        /// <returns></returns>
        public List<Stu_Teacher> AllTeacher(int pageIndex, int pageSize, string keyWord, ref int totalCount, ref int pageCount)
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
            DataTable dt = SqlHelp.ExecuteTable("webpage", CommandType.StoredProcedure, param);
            //接收输出参数
            totalCount = Convert.ToInt32(param[2].Value);
            pageCount = Convert.ToInt32(param[3].Value);
            return Commen.DbTranslate.Translate<Stu_Teacher>(dt);
        }




        /// <summary>
        ///  获得最大的ID值
        /// </summary>
        public int GetMaxID()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select isnull(max(teacherID),0)+1 from Stu_Teacher ");
            int maxID = SqlHelp.GetMaxID(str.ToString());
            return maxID;
        }

        /// <summary>
        /// 获得成绩的数据
        /// </summary>
        /// <param name="StudentName"></param>
        /// <returns></returns>             
        public List<T.Models.Stu_Score> GetList(double stuNum, string StudentName)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select chinese,math,english,history,[geography],political,physics,chemistry,biology from Stu_Score ");
            str.Append("  where stuNum=@stuNum or stuName=@stuName ");
            SqlParameter[] param = { 
                            new SqlParameter("@stuNum",SqlDbType.BigInt),       
                            new SqlParameter("@stuName",SqlDbType.VarChar)
                                   };
            param[0].Value = stuNum;
            param[1].Value = StudentName;
            //获得数据的表
            DataTable dt = SqlHelp.ExecuteTable(str.ToString(), CommandType.Text, param);
            //直接把数据表转为model
            return Commen.DbTranslate.Translate<T.Models.Stu_Score>(dt);
        }

        /// <summary>
        /// 判断是否存在此用户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public bool GetTrueOrFalse(string userName, string userNum)
        {
            if (String.IsNullOrWhiteSpace(userName))
            {
                userName = "%";
            }
            if (String.IsNullOrWhiteSpace(userNum))
            {
                userNum = "";
            }

            StringBuilder str = new StringBuilder();
            str.Append(" select COUNT(*) num from Stu_Score  ");
            str.Append(" where stuName like @userName  or stuNum=@userNum ");
            SqlParameter[] param = { 
                          new  SqlParameter("@userName",SqlDbType.VarChar),
                          new  SqlParameter("@userNum",SqlDbType.VarChar)         
                                   
                                   };
            param[0].Value = userName;
            param[1].Value = userNum;
            var getNum = SqlHelp.ExecuteScalar(str.ToString(), CommandType.Text, param);
            if (Convert.ToInt32(getNum) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
