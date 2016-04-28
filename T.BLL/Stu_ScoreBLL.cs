using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.BLL
{
    public class Stu_ScoreBLL
    {

        public T.DAL.Stu_ScoreDAL dal = new DAL.Stu_ScoreDAL();
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

            return dal.ScoreList(pageIndex, pageSize, keyWord, count, ref totalCount, ref pageCount);
        }
        /// <summary>
        /// 增加学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool AddStudent(T.Models.Stu_Score student)
        {
            float ID = Convert.ToSingle(dal.GetMaxID());
            float stuNum = Convert.ToSingle(student.stuNum);
            string stuName = student.stuName;
            float stuTime = Convert.ToSingle(student.stuTime);
            float chinese = Convert.ToSingle(student.chinese);
            float math = Convert.ToSingle(student.math);
            float english = Convert.ToSingle(student.english);
            float history = Convert.ToSingle(student.history);
            float geography = Convert.ToSingle(student.geography);
            float political = Convert.ToSingle(student.political);
            float physics = Convert.ToSingle(student.physics);
            float chemistry = Convert.ToSingle(student.chemistry);
            float biology = Convert.ToSingle(student.biology);
            return dal.AddStudent(ID, stuNum, stuName, stuTime, chinese, math, english, history, geography, political, physics, chemistry, biology);
        }
        
        /// <summary>
        /// 删除成绩信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteStudentScore(string ids)
        {
            string[] id = ids.Split(',');
            bool retu = true;
            foreach (var item in id)
            {
                retu = dal.DeleteStudentScore(item);
                if (!retu)
                {
                    return false;
                }
            }
            return retu;
        }

        /// <summary>
        /// 通过学号和考试次数获得详细的学生信息
        /// </summary>
        /// <param name="stuNum"></param>
        /// <param name="stuTime"></param>
        /// <returns></returns>
        public List<T.Models.Stu_Score> GetGetStudentScoreByStudentID(string stuNum, string stuTime)
        {

            return dal.GetGetStudentScoreByStudentID(stuNum, stuTime);
        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool ChangeStuScore(T.Models.Stu_Score student)
        {
            
            string stuNum = student.stuNum.ToString();
            string stuName = student.stuName;
            float stuTime = Convert.ToSingle(student.stuTime);
            float chinese = Convert.ToSingle(student.chinese);
            float math = Convert.ToSingle(student.math);
            float english = Convert.ToSingle(student.english);
            float history = Convert.ToSingle(student.history);
            float geography = Convert.ToSingle(student.geography);
            float political = Convert.ToSingle(student.political);
            float physics = Convert.ToSingle(student.physics);
            float chemistry = Convert.ToSingle(student.chemistry);
            float biology = Convert.ToSingle(student.biology);
            return dal.ChangeStuScore(stuNum, stuName, stuTime, chinese, math, english, history, geography, political, physics, chemistry, biology);
        }

        /// <summary>
        /// 根据拿到的考试次数导出数据
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<T.Models.Stu_Score> GetStudentScore(int count)
        {
            return dal.GetStudentScore(count);
        }
    }
}
