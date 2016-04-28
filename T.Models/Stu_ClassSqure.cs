using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.Models
{
    public class Stu_ClassSqure
    {
        //姓名
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _remark;
        //留言
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private DateTime _createTime;
        //时间
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

    }
}
