using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Commen;
namespace web.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        public T.BLL.Stu_TeacherBLL _stu = new T.BLL.Stu_TeacherBLL();//引用教师的BLL层


        //教师信息的视图
        public ActionResult Teacher()
        {
            return View();
        }
        //增加教师
        public ActionResult AddTeacher()
        {

            return View();
        }
        /// <summary>
        /// 成绩分析
        /// </summary>
        /// <returns></returns>
        public ActionResult ScoreAnalyze()
        {

            return View();
        }
        /// <summary>
        /// 某人的成绩分析
        /// </summary>
        /// <returns></returns>
        public ActionResult SomeScoreAnalysis()
        {
            return View();
        }

        /// <summary>
        /// 学生权限下的成绩分析
        /// </summary>
        /// <returns></returns>
        public ActionResult SingeStudentAnalysis()
        {
            return View();
        }


        /// <summary>
        /// 获得教师信息的列表
        /// </summary>
        /// <param name="keyword">模糊查询条件</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetTeacherList(string keyword)
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
            //获得数据
            var getTeacherList = _stu.AllTeacher(pageIndex, pageSize, keyword, ref totalCount, ref pageCount);

            return Json(new
            {
                rows = getTeacherList.ToArray(),
                total = totalCount
            }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 增加教师信息
        /// </summary>
        /// <param name="sUserAccount">姓名</param>
        /// <param name="sUserGender">性别</param>
        /// <param name="IDCard">身份证号</param>
        /// <param name="sPhone">手机号</param>
        /// <param name="adress">地址</param>
        /// <param name="course">课程</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddTeacherInfo(string sUserAccount, string sUserGender, string IDCard, string sPhone, string adress, string course)
        {
            Commen.ReturnValue returnValue = new ReturnValue(0, "增加成功！", "");
            var add = _stu.TeacherAdd(sUserAccount, sUserGender, IDCard, sPhone, adress, course);

            if (add)
            {
                return Json(returnValue);
            }
            else
            {
                returnValue.Success = 1;
                returnValue.Message = "增加失败！";
                return Json(returnValue);
            }

        }

        /// <summary>
        /// 获得数据库中个人的成绩数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetScore(string stuNum, string StudentName)
        {
            if (String.IsNullOrEmpty(StudentName))
            {
                StudentName = "杨忠";//取得cookie中的值
            }
            if (String.IsNullOrWhiteSpace(stuNum))
            {
                stuNum = "00";//如果为null的话就赋值
            }
            double stuNum1 = Convert.ToDouble(stuNum.ToString());
            var getScore = _stu.GetList(stuNum1, StudentName);


            return Json(getScore.ToArray());
        }

        /// <summary>
        /// 学生权限下的个人成绩信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetSingeStudentScore()
        {

            var StudentName = HttpUtility.UrlDecode(this.Request.Cookies["uName"].Value);
            if (String.IsNullOrEmpty(StudentName))
            {
                StudentName = "杨忠";//取得cookie中的值
            }
            var stuNum =String.Empty;
            if (String.IsNullOrWhiteSpace(stuNum))
            {
                stuNum = "00";//如果为null的话就赋值
            }
            double stuNum1 = Convert.ToDouble(stuNum.ToString());
            var getScore = _stu.GetList(stuNum1, StudentName);


            return Json(getScore.ToArray());
            
        }


        /// <summary>
        /// 判断是否存在此人成绩
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userNum"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetTrueOrFalse(string userName, string userNum)
        {
            ReturnValue returnValue = new ReturnValue(0, "存在此用户！", "");
            var getTrueOrFalse = _stu.GetTrueOrFalse(userName, userNum);
            if (getTrueOrFalse)
            {
                return Json(returnValue);
            }
            else
            {
                returnValue.Success = 1;
                returnValue.Message = "不存在此用户！";
                return Json(returnValue);
            }

        }



    }
}
