using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.DAL;
namespace T.BLL
{
    public class Stu_AdminBLL
    {
        //引用Dal层
        public T.DAL.Stu_AdminDAL _stuAdmin = new Stu_AdminDAL();

        /// <summary>
        /// 判断账号是否存在
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public bool Exist(string account, string password, int typeId,ref int id )
        {
            return _stuAdmin.Exist(account, password, typeId,ref id);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AlterPassWord(string account, string password)
        {
            return _stuAdmin.AlterPassWord(account, password);
        }


        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fullName"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool AddAdmin(string fullName, string password, int roleId)
        {

            int id = 0;
            id = _stuAdmin.GetMaxID();
            return _stuAdmin.AddAdmin(id, fullName, password, roleId);
        }


     
    }
}
