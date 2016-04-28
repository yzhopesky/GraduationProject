using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.Models
{
    public class Stu_StuInformation
    {
        private int _keyid;
        private string _studentid;
        private string _studentname;
        private string _stugender;
        private DateTime _stubirthdate;
        private string _stunation;
        private string _stuadress;
        private string _stuhealth;
        private string _stuclass;
        private string _stuschoolsystem;
        private string _studorm;
        private string _stuemail;
        private string _stuphone;
        private int? _stupostcode;
        private string _stuidnumber;
        private string _sturemark;
        private bool _stuisdelete;
        /// <summary>
        /// 
        /// </summary>
        public int keyID
        {
            set { _keyid = value; }
            get { return _keyid; }
        }
        /// <summary>
        /// 学生学号
        /// </summary>
        public string studentID
        {
            set { _studentid = value; }
            get { return _studentid; }
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
        public string stuGender
        {
            set { _stugender = value; }
            get { return _stugender; }
        }
        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime stuBirthdate
        {
            set { _stubirthdate = value; }
            get { return _stubirthdate; }
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string stuNation
        {
            set { _stunation = value; }
            get { return _stunation; }
        }
        /// <summary>
        /// 家庭住址
        /// </summary>
        public string stuAdress
        {
            set { _stuadress = value; }
            get { return _stuadress; }
        }
        /// <summary>
        /// 健康状况
        /// </summary>
        public string stuHealth
        {
            set { _stuhealth = value; }
            get { return _stuhealth; }
        }
        /// <summary>
        /// 学生班级
        /// </summary>
        public string stuClass
        {
            set { _stuclass = value; }
            get { return _stuclass; }
        }
        /// <summary>
        /// 学生院系
        /// </summary>
        public string stuSchoolSystem
        {
            set { _stuschoolsystem = value; }
            get { return _stuschoolsystem; }
        }
        /// <summary>
        /// 宿舍
        /// </summary>
        public string stuDorm
        {
            set { _studorm = value; }
            get { return _studorm; }
        }
        /// <summary>
        /// 学生邮箱
        /// </summary>
        public string stuEmail
        {
            set { _stuemail = value; }
            get { return _stuemail; }
        }
        /// <summary>
        /// 学生电话
        /// </summary>
        public string stuPhone
        {
            set { _stuphone = value; }
            get { return _stuphone; }
        }
        /// <summary>
        /// 学生邮编
        /// </summary>
        public int? stuPostCode
        {
            set { _stupostcode = value; }
            get { return _stupostcode; }
        }
        /// <summary>
        /// 学生身份证
        /// </summary>
        public string stuIDNumber
        {
            set { _stuidnumber = value; }
            get { return _stuidnumber; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string stuRemark
        {
            set { _sturemark = value; }
            get { return _sturemark; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool stuIsDelete
        {
            set { _stuisdelete = value; }
            get { return _stuisdelete; }
        }
    }
}
