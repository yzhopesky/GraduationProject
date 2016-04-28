using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.Models
{
    public class Stu_Student
    {
        private int _studentid;
        private int? _studentnumber;
        private string _studentname;
        private string _studentgender;
        private int? _studentage;
        private int? _studentclassid;
        private string _studentclass;
        private bool _studentisdelete;
        private string _studentremark;
        

      
        /// <summary>
        /// 学生ID
        /// </summary>
        public int studentID
        {
            set { _studentid = value; }
            get { return _studentid; }
        }
        /// <summary>
        /// 学号
        /// </summary>
        public int? studentNumber
        {
            set { _studentnumber = value; }
            get { return _studentnumber; }
        }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string studentName
        {
            set { _studentname = value; }
            get { return _studentname; }
        }
        /// <summary>
        /// 学生性别
        /// </summary>
        public string studentGender
        {
            set { _studentgender = value; }
            get { return _studentgender; }
        }
        /// <summary>
        /// 学生年龄
        /// </summary>
        public int? studentAge
        {
            set { _studentage = value; }
            get { return _studentage; }
        }
        /// <summary>
        /// 学生班级ID
        /// </summary>
        public int? studentClassID
        {
            set { _studentclassid = value; }
            get { return _studentclassid; }
        }
        /// <summary>
        /// 学生班级
        /// </summary>
        public string studentClass
        {
            set { _studentclass = value; }
            get { return _studentclass; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool studentIsDelete
        {
            set { _studentisdelete = value; }
            get { return _studentisdelete; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string studentRemark
        {
            set { _studentremark = value; }
            get { return _studentremark; }
        }

    }
}
