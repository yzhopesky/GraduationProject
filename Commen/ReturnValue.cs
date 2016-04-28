using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commen
{
    [Serializable]
    public class ReturnValue
    {

        public int Success { get; set; }//状态码

        public string Message { get; set; } //返回信息

        public object Value { get; set; }//具体数据

        public ReturnValue(int success, string message, object value)
        {
            this.Success = success;
            this.Message = message;
            this.Value = value;
        }
        public ReturnValue() { }
    }
}
