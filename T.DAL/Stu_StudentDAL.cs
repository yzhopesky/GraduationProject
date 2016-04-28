using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.Models;
using Commen;
using System.Data;
namespace T.DAL
{
    public class Stu_StudentDAL
    {


        /// <summary>
        /// 查询学生信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyWord"></param>
        /// <param name="totalCount"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public List<T.Models.Stu_Student> GetStudentList(int pageIndex, int pageSize, string keyWord, ref int totalCount, ref int pageCount)
        {

            if (String.IsNullOrWhiteSpace(keyWord))
            {
                keyWord = "%";
            }

            SqlParameter[] param = { 
                          new SqlParameter("@pageIndex",SqlDbType.Int),
               new SqlParameter("@pageSize",SqlDbType.Int),
               new SqlParameter("@keyWord",SqlDbType.VarChar),
               new  SqlParameter("@totalCount",SqlDbType.Int),
               new SqlParameter("@pageCount",SqlDbType.Int)
                        };
            param[0].Value = pageIndex;
            param[1].Value = pageSize;
            param[2].Value = keyWord;
            param[3].Direction = ParameterDirection.InputOutput;
            param[4].Direction = ParameterDirection.InputOutput;
            //连接数据库进行查询
            DataTable table = SqlHelp.ExecuteTable("Stuwebpage", CommandType.StoredProcedure, param);
            //接收传出参数
            totalCount = Convert.ToInt32(param[3].Value);
            pageCount = Convert.ToInt32(param[4].Value);
            //直接把table表转换为model实体
            return Commen.DbTranslate.Translate<Stu_Student>(table);

        }

        /// <summary>
        /// 查询学生的学籍信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyWord"></param>
        /// <param name="totalCount"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public List<T.Models.Stu_StuInformation> GetStuInformation(int pageIndex, int pageSize, string keyWord, ref int totalCount, ref int pageCount)
        {
            if (String.IsNullOrWhiteSpace(keyWord))
            {
                keyWord = "%";
            }

            SqlParameter[] param = { 
                          new SqlParameter("@pageIndex",SqlDbType.Int),
               new SqlParameter("@pageSize",SqlDbType.Int),
               new SqlParameter("@keyWord",SqlDbType.VarChar),
               new  SqlParameter("@totalCount",SqlDbType.Int),
               new SqlParameter("@pageCount",SqlDbType.Int)
                        };
            param[0].Value = pageIndex;
            param[1].Value = pageSize;
            param[2].Value = keyWord;
            param[3].Direction = ParameterDirection.InputOutput;
            param[4].Direction = ParameterDirection.InputOutput;
            //连接数据库进行查询
            DataTable table = SqlHelp.ExecuteTable("StuRollwebpage", CommandType.StoredProcedure, param);
            //接收传出参数
            totalCount = Convert.ToInt32(param[3].Value);
            pageCount = Convert.ToInt32(param[4].Value);
            //直接把table表转换为model实体
            return Commen.DbTranslate.Translate<T.Models.Stu_StuInformation>(table);

        }



        /// <summary>
        /// 增加内容
        /// </summary>
        /// <param name="keyID"></param>
        /// <param name="studentID"></param>
        /// <param name="studentName"></param>
        /// <param name="stuGender"></param>
        /// <param name="stuBirthdate"></param>
        /// <param name="stuNation"></param>
        /// <param name="stuAdress"></param>
        /// <param name="stuHealth"></param>
        /// <param name="stuClass"></param>
        /// <param name="stuSchoolSystem"></param>
        /// <param name="stuDorm"></param>
        /// <param name="stuEmail"></param>
        /// <param name="stuPhone"></param>
        /// <param name="stuPostCode"></param>
        /// <param name="stuIDNumber"></param>
        /// <param name="stuRemark"></param>
        /// <returns></returns>
        public bool AddStudent(int keyID, string studentID, string studentName, string stuGender, DateTime stuBirthdate, string stuNation, string stuAdress, string stuHealth,
            string stuClass, string stuSchoolSystem, string stuDorm, string stuEmail, string stuPhone, int stuPostCode, string stuIDNumber, string stuRemark)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into Stu_StuInformation ");
            str.Append(" (keyID, studentID, studentName, stuGender, stuBirthdate, stuNation, stuAdress,stuHealth, stuClass, stuSchoolSystem, stuDorm, stuEmail, stuPhone, stuPostCode, stuIDNumber, stuRemark, stuIsDelete) ");
            str.Append(" values( @keyID,@studentID,@studentName,@stuGender,@stuBirthdate,@stuNation,@stuAdress,@stuHealth,@stuClass,@stuSchoolSystem,@stuDorm,@stuEmail,@stuPhone,@stuPostCode,@stuIDNumber,@stuRemark,@stuIsDelete ) ");
            SqlParameter[] param = {
                                   new SqlParameter("@keyID",SqlDbType.Int),
                                   new SqlParameter("@studentID",SqlDbType.VarChar),
                                   new SqlParameter("@studentName",SqlDbType.VarChar),
                                   new SqlParameter("@stuGender",SqlDbType.VarChar),
                                   new SqlParameter("@stuBirthdate",SqlDbType.DateTime),
                                   new SqlParameter("@stuNation",SqlDbType.VarChar),
                                   new SqlParameter("@stuAdress",SqlDbType.VarChar),
                                   new SqlParameter("@stuHealth",SqlDbType.VarChar),
                                   new SqlParameter("@stuClass",SqlDbType.VarChar),
                                   new SqlParameter("@stuSchoolSystem",SqlDbType.VarChar),
                                   new SqlParameter("@stuDorm",SqlDbType.VarChar),
                                   new SqlParameter("@stuEmail",SqlDbType.VarChar),
                                   new SqlParameter("@stuPhone",SqlDbType.VarChar),
                                   new SqlParameter("@stuPostCode",SqlDbType.VarChar),
                                   new SqlParameter("@stuIDNumber",SqlDbType.VarChar),
                                   new SqlParameter("@stuRemark",SqlDbType.VarChar),
                                   new SqlParameter("@stuIsDelete",SqlDbType.Bit)
                                   };
            param[0].Value = keyID;
            param[1].Value = studentID;
            param[2].Value = studentName;
            param[3].Value = stuGender;
            param[4].Value = stuBirthdate;
            param[5].Value = stuNation;
            param[6].Value = stuAdress;
            param[7].Value = stuHealth;
            param[8].Value = stuClass;
            param[9].Value = stuSchoolSystem;
            param[10].Value = stuDorm;
            param[11].Value = stuEmail;
            param[12].Value = stuPhone;
            param[13].Value = stuPostCode;
            param[14].Value = stuIDNumber;
            param[15].Value = stuRemark;
            param[16].Value = false;
            var row = SqlHelp.ExecuteNonQuery(str.ToString(), CommandType.Text, param);
            if (row > 0)
            {
                return true;
            }

            return false;
        }



        /// <summary>
        ///  获得最大的ID值
        /// </summary>
        public int GetMaxID()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select isnull(max(keyID),0)+1 from Stu_StuInformation ");
            int maxID = SqlHelp.GetMaxID(str.ToString());
            return maxID;
        }

        /// <summary>
        /// 根据学生的ID获得学生的学籍信息
        /// </summary>
        /// <param name="stuID"></param>
        /// <returns></returns>
        public List<T.Models.Stu_StuInformation> GetInfomationByStuID(string stuID)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select *from Stu_StuInformation  where studentID=@studenID ");
            SqlParameter[] param = { 
                             new  SqlParameter("@studenID",SqlDbType.NVarChar)
                                        };
            param[0].Value = stuID;
            DataTable dt = SqlHelp.ExecuteTable(str.ToString(), CommandType.Text, param);

            return Commen.DbTranslate.Translate<T.Models.Stu_StuInformation>(dt);
        }

        /// <summary>
        /// 修改内容
        /// </summary>
        /// <param name="keyID"></param>
        /// <param name="studentID"></param>
        /// <param name="studentName"></param>
        /// <param name="stuGender"></param>
        /// <param name="stuBirthdate"></param>
        /// <param name="stuNation"></param>
        /// <param name="stuAdress"></param>
        /// <param name="stuHealth"></param>
        /// <param name="stuClass"></param>
        /// <param name="stuSchoolSystem"></param>
        /// <param name="stuDorm"></param>
        /// <param name="stuEmail"></param>
        /// <param name="stuPhone"></param>
        /// <param name="stuPostCode"></param>
        /// <param name="stuIDNumber"></param>
        /// <param name="stuRemark"></param>
        /// <returns></returns>
        public bool ChangeStudent( string studentID, string studentName, string stuGender, DateTime stuBirthdate, string stuNation, string stuAdress, string stuHealth,
            string stuClass, string stuSchoolSystem, string stuDorm, string stuEmail, string stuPhone, int stuPostCode, string stuIDNumber, string stuRemark)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update Stu_StuInformation  set ");
            str.Append("  studentName=@studentName, stuGender=@stuGender, stuBirthdate=@stuBirthdate,stuNation=@stuNation, stuAdress=@stuAdress,stuHealth=@stuHealth, stuClass=@stuClass,   ");
            str.Append(" stuSchoolSystem=@stuSchoolSystem, stuDorm=@stuDorm, stuEmail=@stuEmail, stuPhone=@stuPhone, stuPostCode=@stuPostCode, stuIDNumber=@stuIDNumber, stuRemark=@stuRemark, stuIsDelete=@stuIsDelete ");
            str.Append(" where studentID=@studentID ");
            SqlParameter[] param = {
                                  
                                   new SqlParameter("@studentID",SqlDbType.VarChar),
                                   new SqlParameter("@studentName",SqlDbType.VarChar),
                                   new SqlParameter("@stuGender",SqlDbType.VarChar),
                                   new SqlParameter("@stuBirthdate",SqlDbType.DateTime),
                                   new SqlParameter("@stuNation",SqlDbType.VarChar),
                                   new SqlParameter("@stuAdress",SqlDbType.VarChar),
                                   new SqlParameter("@stuHealth",SqlDbType.VarChar),
                                   new SqlParameter("@stuClass",SqlDbType.VarChar),
                                   new SqlParameter("@stuSchoolSystem",SqlDbType.VarChar),
                                   new SqlParameter("@stuDorm",SqlDbType.VarChar),
                                   new SqlParameter("@stuEmail",SqlDbType.VarChar),
                                   new SqlParameter("@stuPhone",SqlDbType.VarChar),
                                   new SqlParameter("@stuPostCode",SqlDbType.VarChar),
                                   new SqlParameter("@stuIDNumber",SqlDbType.VarChar),
                                   new SqlParameter("@stuRemark",SqlDbType.VarChar),
                                   new SqlParameter("@stuIsDelete",SqlDbType.Bit)
                                   };
            
            param[0].Value = studentID;
            param[1].Value = studentName;
            param[2].Value = stuGender;
            param[3].Value = stuBirthdate;
            param[4].Value = stuNation;
            param[5].Value = stuAdress;
            param[6].Value = stuHealth;
            param[7].Value = stuClass;
            param[8].Value = stuSchoolSystem;
            param[9].Value = stuDorm;
            param[10].Value = stuEmail;
            param[11].Value = stuPhone;
            param[12].Value = stuPostCode;
            param[13].Value = stuIDNumber;
            param[14].Value = stuRemark;
            param[15].Value = false;
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
    }
}
