using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using T.BLL;
using Commen;
using web.Source;

namespace web.Controllers
{

    public class ExChangeController : Controller
    {
        //
        // GET: /ExChange/

        public T.BLL.Stu_TeacherBLL _tea = new Stu_TeacherBLL();
        public T.BLL.Stu_StudentBLL _stu = new Stu_StudentBLL();
        public T.BLL.Stu_ClassSqureBLL _cla = new Stu_ClassSqureBLL();
        /// <summary>
        /// 交流天地
        /// </summary>
        /// <returns></returns>
        [IsLoginOrFalse]
        public ActionResult Square()
        {
            return View();
        }
        /// <summary>
        /// 教师留言
        /// </summary>
        /// <returns></returns>
        [IsLoginOrFalse]
        public ActionResult TeacherLeaveWord()
        {
            return View();
        }
        /// <summary>
        /// 学生留言
        /// </summary>
        /// <returns></returns>
       [IsLoginOrFalse]
        public ActionResult StudentLeaveWord()
        {
            return View();
        }
        /// <summary>
        /// 获得留言
        /// </summary>
        /// <returns></returns>
        /// 2015年12月8日16:12:58
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult TeacherTextWrite(string k_textarea)
        {
            //获得cookie中存储的值
            var GetName = this.Request.Cookies["uName"] == null ? "" : HttpUtility.UrlDecode(this.Request.Cookies["uName"].Value);

            string account = GetName;
            string accountRemark = k_textarea;
            //更新数据内容
            var IsTrueOrFalse = _cla.WriteRemark(account, accountRemark);
            if (IsTrueOrFalse)
            {
                return Content("留言成功！");
            }

            return Content("留言失败!");
        }

        /// <summary>
        /// 获得留言
        /// </summary>
        /// <returns></returns>
        /// 2015年12月8日16:13:06
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult StudentTextWrite(string k_textarea)
        {

            //获得cookie中存储的值
            var GetName = this.Request.Cookies["uName"] == null ? "" : HttpUtility.UrlDecode(this.Request.Cookies["uName"].Value);
            //要存入的内容
            string account = GetName;
            string accountRemark = k_textarea;
            //更新数据内容
            var IsTrueOrFalse = _cla.WriteRemark(account, accountRemark);
            if (IsTrueOrFalse)
            {
                return Content("留言成功！");
            }

            return Content("留言失败!");
        }

        /// <summary>
        /// 得到展示的数据
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public JsonResult GetPageList(string keyWord)
        {
            //初始化分页数据
            var pageIndex = 1;
            var pageSize = 15;
            if (!(string.IsNullOrWhiteSpace(Request["rows"])) || !(string.IsNullOrWhiteSpace(Request["page"])))
            {
                pageIndex = Commen.Utils.StrToInt(Request["page"].ToString(), 1);
                pageSize = Commen.Utils.StrToInt(Request["rows"].ToString(), 15);
            }
            var pageCount = 0;
            var totalCount = 0;
            var getList = _cla.GetLeaveWord(pageIndex, pageSize, keyWord, ref totalCount, ref pageCount);
            return Json(new
            {
                rows = getList.ToArray(),
                total = totalCount
            });

        }



    }
}
