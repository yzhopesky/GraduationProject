using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.Models
{
    public class Stu_Teacher
    {
        private int _teacherid;
        private string _teachername;
        private string _teachergender;
        private string _teacherphone;
        private string _teacheradress;
        private string _teacherreamrk;
        private bool _teacherisdelete;
        private string _teacherBeiYong;
        private DateTime _teacherDate;
        private string _teacherIDCard;


        public string teacherIDCard
        {
            set { _teacherIDCard = value; }
            get { return _teacherIDCard; }
        }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime teacherDate
        {
            set { _teacherDate = value; }
            get { return _teacherDate; }
        }
        /// <summary>
        /// 备用字段
        /// </summary>
        public string teacherBeiYong
        {
            set { _teacherBeiYong = value; }
            get { return _teacherBeiYong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int teacherID
        {
            set { _teacherid = value; }
            get { return _teacherid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string teacherName
        {
            set { _teachername = value; }
            get { return _teachername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string teacherGender
        {
            set { _teachergender = value; }
            get { return _teachergender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string teacherPhone
        {
            set { _teacherphone = value; }
            get { return _teacherphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string teacherAdress
        {
            set { _teacheradress = value; }
            get { return _teacheradress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string teacherReamrk
        {
            set { _teacherreamrk = value; }
            get { return _teacherreamrk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool teacherIsDelete
        {
            set { _teacherisdelete = value; }
            get { return _teacherisdelete; }
        }
    }
}
