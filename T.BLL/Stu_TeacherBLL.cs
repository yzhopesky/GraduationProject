using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.Models;

namespace T.BLL
{
    public class Stu_TeacherBLL
    {
        public T.DAL.Stu_TeacherDAL dal = new DAL.Stu_TeacherDAL();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="teacher">教师实体</param>
        /// <returns></returns>
        /// 2015年12月3日17:56:50
        public bool TeacherAdd(string sUserAccount, string sUserGender, string IDCard, string sPhone, string adress, string course)
        {

            T.Models.Stu_Teacher teacher = new Stu_Teacher();
            teacher.teacherID = dal.GetMaxID();
            teacher.teacherIDCard = IDCard;
            teacher.teacherGender = sUserGender;
            teacher.teacherAdress = adress;
            teacher.teacherBeiYong = course;
            teacher.teacherDate = DateTime.Now;
            teacher.teacherIsDelete = false;
            teacher.teacherName = sUserAccount;
            teacher.teacherPhone = sPhone;
            teacher.teacherReamrk = "1";
            return dal.TeacherAdd(teacher);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">要删除的ID</param>
        /// <returns></returns>
        ///  多个删除
        public bool TeacherDelete(string ids)
        {
            bool ach = true;
            string[] shuzu = ids.Split(',');
            foreach (var id in shuzu)
            {
                ach = dal.TeacherDelete(Convert.ToInt32(id));
            }
            if (ach)
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
            return dal.UpdateTeacher(id, teacherName, teacherGender, teacherPhone, teacherAdress);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public List<Stu_Teacher> AllTeacher(int pageIndex, int pageSize, string keyWord, ref int totalCount, ref int pageCount)
        {
            return dal.AllTeacher(pageIndex, pageSize, keyWord, ref totalCount, ref pageCount);
        }


        /// <summary>
        /// 获得成绩的数据
        /// </summary>
        /// <param name="StudentName"></param>
        /// <returns></returns>             
        public List<T.Models.Stu_Score> GetList(double stuNum, string StudentName)
        {
            return dal.GetList(stuNum, StudentName);
        }

        /// <summary>
        /// 判断是否存在此用户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public bool GetTrueOrFalse(string userName, string userNum)
        {
            return dal.GetTrueOrFalse(userName, userNum);
        }
    }
}
