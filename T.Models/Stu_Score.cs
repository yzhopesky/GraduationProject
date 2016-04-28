using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.Models
{
    public class Stu_Score
    {
        private decimal _id;
        private decimal _stunum;
        private string _stuname;
        private decimal _stutime;
        private decimal _chinese;
        private decimal _math;
        private decimal _english;
        private decimal _history;
        private decimal _geography;
        private decimal _political;
        private decimal _physics;
        private decimal _chemistry;
        private decimal _biology;
        private DateTime _createtime;
        /// <summary>
        /// 主键
        /// </summary>
        public decimal ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 学生学号
        /// </summary>
        public decimal stuNum
        {
            set { _stunum = value; }
            get { return _stunum; }
        }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string stuName
        {
            set { _stuname = value; }
            get { return _stuname; }
        }
        /// <summary>
        /// 次数
        /// </summary>
        public decimal stuTime
        {
            set { _stutime = value; }
            get { return _stutime; }
        }
        /// <summary>
        /// 语文
        /// </summary>
        public decimal chinese
        {
            set { _chinese = value; }
            get { return _chinese; }
        }
        /// <summary>
        /// 数学
        /// </summary>
        public decimal math
        {
            set { _math = value; }
            get { return _math; }
        }
        /// <summary>
        /// 英语
        /// </summary>
        public decimal english
        {
            set { _english = value; }
            get { return _english; }
        }
        /// <summary>
        /// 历史
        /// </summary>
        public decimal history
        {
            set { _history = value; }
            get { return _history; }
        }
        /// <summary>
        /// 地理
        /// </summary>
        public decimal geography
        {
            set { _geography = value; }
            get { return _geography; }
        }
        /// <summary>
        /// 政治
        /// </summary>
        public decimal political
        {
            set { _political = value; }
            get { return _political; }
        }
        /// <summary>
        /// 物理
        /// </summary>
        public decimal physics
        {
            set { _physics = value; }
            get { return _physics; }
        }
        /// <summary>
        /// 化学
        /// </summary>
        public decimal chemistry
        {
            set { _chemistry = value; }
            get { return _chemistry; }
        }
        /// <summary>
        /// 生物
        /// </summary>
        public decimal biology
        {
            set { _biology = value; }
            get { return _biology; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
    }
}
