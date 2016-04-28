using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.DAL;

namespace T.BLL
{


    public class Stu_StudentBLL
    {
        public T.DAL.Stu_StudentDAL dal = new Stu_StudentDAL();

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
            return dal.GetStudentList(pageIndex, pageSize, keyWord, ref totalCount, ref pageCount);
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
            return dal.GetStuInformation(pageIndex, pageSize, keyWord, ref totalCount, ref pageCount);
        }
        /// <summary>
        /// 增加信息
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public bool AddStudentInfo(T.Models.Stu_StuInformation stu)
        {
            int keyID = dal.GetMaxID();
            string studentID = stu.studentID;
            string studentName = stu.studentName;
            string stuGender = stu.stuGender;
            DateTime stuBirthdate = stu.stuBirthdate;
            string stuNation = stu.stuNation;
            string stuAdress = stu.stuAdress;
            string stuHealth = stu.stuHealth;
            string stuClass = stu.stuClass;
            string stuSchoolSystem = stu.stuSchoolSystem;
            string stuDorm = stu.stuDorm;
            string stuEmail = stu.stuEmail;
            string stuPhone = stu.stuPhone;
            int stuPostCode = (int)stu.stuPostCode;
            string stuIDNumber = stu.stuIDNumber;
            string stuRemark = stu.stuRemark;
            return dal.AddStudent(keyID, studentID, studentName, stuGender, stuBirthdate, stuNation, stuAdress, stuHealth, stuClass, stuSchoolSystem, stuDorm, stuEmail,
                stuPhone, stuPostCode, stuIDNumber, stuRemark);
        }


        /// <summary>
        /// 根据学生的ID获得学生的学籍信息
        /// </summary>
        /// <param name="stuID"></param>
        /// <returns></returns>
        public List<T.Models.Stu_StuInformation> GetInfomationByStuID(string stuID)
        {
            return dal.GetInfomationByStuID(stuID);

        }

        /// <summary>
        /// 增加信息
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public bool ChangeStudent(T.Models.Stu_StuInformation stu)
        {
            //int keyID = stu.keyID;
            string studentID = stu.studentID;
            string studentName = stu.studentName;
            string stuGender = stu.stuGender;
            DateTime stuBirthdate = stu.stuBirthdate;
            string stuNation = stu.stuNation;
            string stuAdress = stu.stuAdress;
            string stuHealth = stu.stuHealth;
            string stuClass = stu.stuClass;
            string stuSchoolSystem = stu.stuSchoolSystem;
            string stuDorm = stu.stuDorm;
            string stuEmail = stu.stuEmail;
            string stuPhone = stu.stuPhone;
            int stuPostCode = (int)stu.stuPostCode;
            string stuIDNumber = stu.stuIDNumber;
            string stuRemark = stu.stuRemark;
            return dal.ChangeStudent( studentID, studentName, stuGender, stuBirthdate, stuNation, stuAdress, stuHealth, stuClass, stuSchoolSystem, stuDorm, stuEmail,
                    stuPhone, stuPostCode, stuIDNumber, stuRemark);
        }
    }
}
