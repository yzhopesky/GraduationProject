using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.DAL;

namespace T.BLL
{
    public class Stu_ClassSqureBLL
    {
        private T.DAL.Stu_ClassSqureDAL dal = new Stu_ClassSqureDAL();

        /// <summary>
        ///  插入留言
        /// </summary>
        /// <param name="account"></param>
        /// <param name="accountRemark"></param>
        /// <returns></returns>
        public bool WriteRemark(string account, string accountRemark)
        {
            return dal.WriteRemark(account, accountRemark);
        }
        /// <summary>
        /// 获得留言表中的所有数据
        /// </summary>
        /// <returns></returns>
        public List<T.Models.Stu_ClassSqure> GetLeaveWord(int pageIndex, int pageSize, string keyWord, ref int totalCount, ref int pageCount)
        {

            return dal.GetLeaveWord(pageIndex, pageSize, keyWord, ref totalCount, ref pageCount);
        }
    }
}
