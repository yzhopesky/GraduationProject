using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T.BLL;
using Commen;
using System.Web.Routing;
using web.Source;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public T.BLL.Stu_AdminBLL _admin = new Stu_AdminBLL();
        //主要界面
      
        public ActionResult Index()
        {
            return View();
        }
        //个人联系方式
        [IsLoginOrFalse]
        public ActionResult PerTouch()
        {
            return View();
        }
        //修改密码
        [IsLoginOrFalse]
        public ActionResult ChangeMM()
        {
            return View();
        }

        /// <summary>
        /// 登陆方法
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <param name="typeID">类型:1,是管理员。2，是教师。3，是学生。</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AdminUserLoginIn(string account, string password, int typeID)
        {
            int id = 0;
            Commen.ReturnValue tet = new ReturnValue(5, "兄弟你真倒霉，请联系管理员！", "");
            //循环过来的数值
            switch (typeID)
            {
                case 1:
                    tet = new ReturnValue(1, "登陆成功！", "");
                    break;
                case 2:
                    tet = new ReturnValue(2, "登陆成功！", "");
                    break;
                case 3:
                    tet = new ReturnValue(3, "登陆成功！", "");
                    break;
                default:
                    tet = new ReturnValue(4, "未知错误，请联系管理员！", "");
                    break;
            }
            var exist = _admin.Exist(account, password, typeID, ref id);
            if (exist)
            {

                HttpCookie GetUserName = new HttpCookie("uName", HttpUtility.UrlEncode(account));
                HttpCookie GetUserID = new HttpCookie("uID", id.ToString());
                HttpCookie typeId = new HttpCookie("typeIID",typeID.ToString());
                GetUserName.Expires = DateTime.Now.AddDays(7);
                GetUserID.Expires = DateTime.Now.AddDays(7);
                this.Response.Cookies.Add(GetUserName);
                this.Response.Cookies.Add(GetUserID);
                  
                return Json(tet, JsonRequestBehavior.AllowGet);
            }
            else
            {
                tet.Success = 0;
                tet.Message = "登陆失败，请检查账号或密码。";
                return Json(tet, JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AlterPassWord(string password)
        {
            Commen.ReturnValue returnVlue = new ReturnValue(0, "修改成功！", "");
            //从cookie中获得用户值
            var GetName = this.Request.Cookies["uName"] == null ? "" : HttpUtility.UrlDecode(this.Request.Cookies["uName"].Value);
            string account = GetName;
            var IsLog = _admin.AlterPassWord(account, password);
            if (IsLog)
            {
                return Json(returnVlue);
            }
            else
            {
                returnVlue.Message = "修改失败，请联系系统管理员！!";
                returnVlue.Success = 1;
                return Json(returnVlue);
            }

        }

        /// <summary>
        /// 退出操作
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LayOut()
        {
            //var GetName = HttpUtility.UrlDecode(this.Request.Cookies["uName"].Value == null ? null : this.Request.Cookies["uName"].Value);
            string GetName = string.Empty;
            if (this.Request.Cookies["uName"] != null)
            {
                GetName = HttpUtility.UrlDecode(this.Request.Cookies["uName"].Value);
            }
            var GetUserID = this.Request.Cookies["uID"];
            if (GetName == null || GetUserID == null)
            {

                return this.Content("ok");
            }
            else
            {
                HttpCookie cookieName = new HttpCookie("uName");
                cookieName.Values.Clear();
                cookieName.Expires = DateTime.Now.AddDays(-1);
                this.Response.Cookies.Add(cookieName);
                HttpCookie cookieID = new HttpCookie("uID");
                cookieID.Values.Clear();
                cookieID.Expires = DateTime.Now.AddDays(-1);
                this.Response.Cookies.Add(cookieID);
                HttpCookie cookietypeID = new HttpCookie("typeIID");
                cookieID.Values.Clear();
                cookieID.Expires = DateTime.Now.AddDays(-1);
                this.Response.Cookies.Add(cookieID);
                return this.Content("ok");
            }

        }

    }
}
