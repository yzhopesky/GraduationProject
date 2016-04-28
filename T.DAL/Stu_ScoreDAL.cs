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
    public class Stu_ScoreDAL
    {

        /// <summary>
        /// 查询数据库中的数据
        /// </summary>
        /// <param name="pageIndex">当前页面</param>
        /// <param name="pageSize">页面数据大小</param>
        /// <param name="keyWord">查询条件</param>
        /// <param name="count">次数</param>
        /// <param name="totalCount">返回总条数</param>
        /// <param name="pageCount">总页数</param>
        /// <returns></returns>
        public List<T.Models.Stu_Score> ScoreList(float pageIndex, float pageSize, string keyWord, string count, ref int totalCount, ref int pageCount)
        {
            if (String.IsNullOrWhiteSpace(keyWord))
            {
                keyWord = "%";
            }
            if (String.IsNullOrWhiteSpace(count))
            {
                count = "1";
            }
            SqlParameter[] param = { 
                          new SqlParameter("@pageIndex",SqlDbType.Float),
               new SqlParameter("@pageSize",SqlDbType.Float),
               new SqlParameter("@keyWord",SqlDbType.VarChar),
               new SqlParameter("@count",SqlDbType.VarChar),
               new  SqlParameter("@totalCount",SqlDbType.Int),
               new SqlParameter("@pageCount",SqlDbType.Int)

                        };
            param[0].Value = pageIndex;
            param[1].Value = pageSize;
            param[2].Value = keyWord;
            param[3].Value = count;
            param[4].Direction = ParameterDirection.InputOutput;
            param[5].Direction = ParameterDirection.InputOutput;
            //连接数据库进行查询
            DataTable table = SqlHelp.ExecuteTable("StuScore", CommandType.StoredProcedure, param);
            //接收传出参数
            totalCount = Convert.ToInt32(param[4].Value);
            pageCount = Convert.ToInt32(param[5].Value);

            return Commen.DbTranslate.Translate<T.Models.Stu_Score>(table);
        }


        /// <summary>
        /// 增加学生信息
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="stuNum"></param>
        /// <param name="stuName"></param>
        /// <param name="stuTime"></param>
        /// <param name="chinese"></param>
        /// <param name="math"></param>
        /// <param name="english"></param>
        /// <param name="history"></param>
        /// <param name="geography"></param>
        /// <param name="political"></param>
        /// <param name="physics"></param>
        /// <param name="chemistry"></param>
        /// <param name="biology"></param>
        /// <returns></returns>
        public bool AddStudent(float ID, float stuNum, string stuName, float stuTime, float chinese, float math, float english, float history, float geography,
            float political, float physics, float chemistry, float biology)
        {

            StringBuilder str = new StringBuilder();
            str.Append(" insert into Stu_Score ");
            str.Append(" (ID, stuNum, stuName, stuTime, chinese, math, english, history, [geography], political, physics, chemistry, biology, createTime)   ");
            str.Append(" values (@ID, @stuNum, @stuName, @stuTime, @chinese, @math, @english, @history, @geography, @political, @physics, @chemistry, @biology, @createTime) ");
            SqlParameter[] param = { 
                                   new SqlParameter("@ID",SqlDbType.Float),
                                   new SqlParameter("@stuNum",SqlDbType.Float),
                                   new SqlParameter("@stuName",SqlDbType.VarChar),
                                   new SqlParameter("@stuTime",SqlDbType.Float),
                                   new SqlParameter("@chinese",SqlDbType.Float),
                                   new SqlParameter("@math",SqlDbType.Float),
                                   new SqlParameter("@english",SqlDbType.Float),
                                   new SqlParameter("@history",SqlDbType.Float),
                                   new SqlParameter("@geography",SqlDbType.Float),
                                   new SqlParameter("@political",SqlDbType.Float),
                                   new SqlParameter("@physics",SqlDbType.Float),
                                   new SqlParameter("@chemistry",SqlDbType.Float),
                                   new SqlParameter("@biology",SqlDbType.Float),
                                   new SqlParameter("@createTime",SqlDbType.DateTime),
                                    };
            param[0].Value = ID;
            param[1].Value = stuNum;
            param[2].Value = stuName;
            param[3].Value = stuTime;
            param[4].Value = chinese;
            param[5].Value = math;
            param[6].Value = english;
            param[7].Value = history;
            param[8].Value = geography;
            param[9].Value = political;
            param[10].Value = physics;
            param[11].Value = chemistry;
            param[12].Value = biology;
            param[13].Value = DateTime.Now;

            int row = SqlHelp.ExecuteNonQuery(str.ToString(), CommandType.Text, param);
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
            str.Append(" select isnull(max(ID),0)+1 from Stu_Score ");
            int maxID = SqlHelp.GetMaxID(str.ToString());
            return maxID;
        }

        /// <summary>
        /// 删除成绩信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteStudentScore(string id)
        {

            StringBuilder str = new StringBuilder();
            str.Append(" delete from Stu_Score where stuNum=@stuNum ");
            SqlParameter[] param = { 
                                   new SqlParameter("@stuNum",SqlDbType.VarChar)
                                                                      };
            param[0].Value = id;
            var row = SqlHelp.ExecuteNonQuery(str.ToString(), CommandType.Text, param);
            if (row > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 通过学号和考试次数获得详细的学生信息
        /// </summary>
        /// <param name="stuNum"></param>
        /// <param name="stuTime"></param>
        /// <returns></returns>
        public List<T.Models.Stu_Score> GetGetStudentScoreByStudentID(string stuNum, string stuTime)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select *from Stu_Score ");
            str.Append(" where stuNum=@stuNum and stuTime=@stuTime ");
            SqlParameter[] param = {
                                   new SqlParameter("@stuNum",SqlDbType.VarChar),
                                   new SqlParameter("@stuTime",SqlDbType.VarChar)
                                   
                                   };
            param[0].Value = stuNum;
            param[1].Value = stuTime;
            DataTable dt = SqlHelp.ExecuteTable(str.ToString(), CommandType.Text, param);
            return Commen.DbTranslate.Translate<T.Models.Stu_Score>(dt);
        }

        /// <summary>
        /// 修改数据库中的成绩信息
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="stuNum"></param>
        /// <param name="stuName"></param>
        /// <param name="stuTime"></param>
        /// <param name="chinese"></param>
        /// <param name="math"></param>
        /// <param name="english"></param>
        /// <param name="history"></param>
        /// <param name="geography"></param>
        /// <param name="political"></param>
        /// <param name="physics"></param>
        /// <param name="chemistry"></param>
        /// <param name="biology"></param>
        /// <returns></returns>
        public bool ChangeStuScore(string stuNum, string stuName, float stuTime, float chinese, float math, float english, float history, float geography,
            float political, float physics, float chemistry, float biology)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update Stu_Score set  ");
            str.Append("  stuName=@stuName,  chinese=@chinese, math=@math, english=@english, history=@history, [geography]=@geography, political=@political, physics=@physics, chemistry=@chemistry, biology=@biology   ");
            str.Append(" where stuNum=@stuNum  and stuTime=@stuTime ");
            SqlParameter[] param = { 
                                   
                                   new SqlParameter("@stuNum",SqlDbType.VarChar),
                                   new SqlParameter("@stuName",SqlDbType.VarChar),
                                   new SqlParameter("@stuTime",SqlDbType.Float),
                                   new SqlParameter("@chinese",SqlDbType.Float),
                                   new SqlParameter("@math",SqlDbType.Float),
                                   new SqlParameter("@english",SqlDbType.Float),
                                   new SqlParameter("@history",SqlDbType.Float),
                                   new SqlParameter("@geography",SqlDbType.Float),
                                   new SqlParameter("@political",SqlDbType.Float),
                                   new SqlParameter("@physics",SqlDbType.Float),
                                   new SqlParameter("@chemistry",SqlDbType.Float),
                                   new SqlParameter("@biology",SqlDbType.Float),
                                
                                    };

            param[0].Value = stuNum;
            param[1].Value = stuName;
            param[2].Value = stuTime;
            param[3].Value = chinese;
            param[4].Value = math;
            param[5].Value = english;
            param[6].Value = history;
            param[7].Value = geography;
            param[8].Value = political;
            param[9].Value = physics;
            param[10].Value = chemistry;
            param[11].Value = biology;
            var row = SqlHelp.ExecuteNonQuery(str.ToString(), CommandType.Text, param);
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }



        #region 导出方法
        /// <summary>
        /// 根据拿到的考试次数导出数据
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<T.Models.Stu_Score> GetStudentScore(int count)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" SELECT *from Stu_score  ");
            str.Append(" where stuTime=@stuTime ");
            SqlParameter[] param = { 
                                   new  SqlParameter("@stuTime",SqlDbType.Int)
                                   };
            param[0].Value = count;
            DataTable dt = SqlHelp.ExecuteTable(str.ToString(), CommandType.Text, param);
            return Commen.DbTranslate.Translate<T.Models.Stu_Score>(dt);
        }


        #endregion
    }
}
