using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        public T.BLL.Stu_StudentBLL _stu = new T.BLL.Stu_StudentBLL();
        public T.BLL.Stu_ScoreBLL _sco = new T.BLL.Stu_ScoreBLL();

        #region 视图
        /// <summary>
        /// 学生用户列表展示  //暂时不用
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentInfo()
        {
            return View();
        }
        /// <summary>
        /// 学生学籍信息
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentRoll()
        {
            return View();
        }
        /// <summary>
        /// 学生的成绩信息
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentScore()
        {
            return View();
        }
        /// <summary>
        /// 学生权限下的成绩信息
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentScorePower()
        {
            return View();
        }

        /// <summary>
        /// 增加学生学籍信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddStudent()
        {
            return View();
        }
        /// <summary>
        /// 增加学生分数
        /// </summary>
        /// <returns></returns>
        public ActionResult AddStudentScore()
        {
            return View();
        }
        /// <summary>
        /// 课程图表
        /// </summary>
        /// <returns></returns>
        public ActionResult CoureseChart()
        {
            return View();
        }
        /// <summary>
        /// 学生信息修改页
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeStudent()
        {
            return View();
        }
        /// <summary>
        /// 学生成绩修改页
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeStudentScore()
        {
            return View();
        }
        /// <summary>
        /// 学生权限下的学籍信息列表
        /// </summary>
        /// <returns></returns>
        public ActionResult SingeStudentRoll()
        {
            return View();
        }
        /// <summary>
        /// 学生权限下的学籍详细信息页
        /// </summary>
        /// <returns></returns>
        public ActionResult SingeStudentDetailed()
        {
            return View();
        }

        #endregion

        #region 暂时不用
        /// <summary>
        /// 获得学生的数据的列表
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetStudentInfo(string keyWord)
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
            var getList = _stu.GetStudentList(pageIndex, pageSize, keyWord, ref totalCount, ref pageCount);
            return Json(new
            {
                rows = getList.ToArray(),
                total = totalCount
            });
        }
        #endregion

        #region 学籍
        /// <summary>
        /// 获得单独的学生学籍列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetSingeStudentRoll()
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
            var keyWord = HttpUtility.UrlDecode(this.Request.Cookies["uName"].Value);
            if (keyWord == null)
            {
                keyWord = "  ";
            }
            var getlistmodel = _stu.GetStuInformation(pageIndex, pageSize, keyWord, ref totalCount, ref pageCount);

            return Json(new
            {
                rows = getlistmodel.ToArray(),
                total = totalCount
            });

        }

        /// <summary>
        /// 获得学生学籍信息
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetStudentInformation(string keyWord)
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
            var getlistmodel = _stu.GetStuInformation(pageIndex, pageSize, keyWord, ref totalCount, ref pageCount);

            return Json(new
            {
                rows = getlistmodel.ToArray(),
                total = totalCount
            });
        }

        /// <summary>
        /// 增加学生信息
        /// </summary>
        /// <param name="studentInformation"></param>
        /// <returns></returns>
        public JsonResult AddStudentInformation(T.Models.Stu_StuInformation studentInformation)
        {
            Commen.ReturnValue returnValue = new Commen.ReturnValue(0, "增加成功！", "");
            var IsTrueOrFalse = _stu.AddStudentInfo(studentInformation);
            if (IsTrueOrFalse)
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
        /// 通过学生的ID获得信息
        /// </summary>
        /// <param name="stuID"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetInfomationBy(string stuID)
        {

            var getModel = _stu.GetInfomationByStuID(stuID);

            return Json(getModel.ToArray());
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="studentInformation"></param>
        /// <returns></returns>
        public JsonResult ChangeStudentInfomationByID(T.Models.Stu_StuInformation studentInformation)
        {
            Commen.ReturnValue returnValue = new Commen.ReturnValue(0, "修改成功！", "");
            var IsTrueOrFalse = _stu.ChangeStudent(studentInformation);
            if (IsTrueOrFalse)
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

        #endregion

        #region 成绩
        public JsonResult GetSingeStudentScore(string count)
        {
            //初始化分页数据
            float pageIndex = 1;
            float pageSize = 15;
            if (!(string.IsNullOrWhiteSpace(Request["rows"])) || !(string.IsNullOrWhiteSpace(Request["page"])))
            {
                pageIndex = Commen.Utils.StrToInt(Request["page"].ToString(), 1);
                pageSize = Commen.Utils.StrToInt(Request["rows"].ToString(), 15);
            }
            int pageCount = 0;
            int totalCount = 0;
            var keyWord = HttpUtility.UrlDecode(this.Request.Cookies["uName"].Value);
            var getScore = _sco.ScoreList(pageIndex, pageSize, keyWord, count, ref totalCount, ref pageCount);
            return Json(new
            {
                rows = getScore.ToArray(),
                total = totalCount
            });

        }

        /// <summary>
        /// 获得成绩表中的数据
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetStudentScore(string keyWord, string count)
        {
            //初始化分页数据
            float pageIndex = 1;
            float pageSize = 15;
            if (!(string.IsNullOrWhiteSpace(Request["rows"])) || !(string.IsNullOrWhiteSpace(Request["page"])))
            {
                pageIndex = Commen.Utils.StrToInt(Request["page"].ToString(), 1);
                pageSize = Commen.Utils.StrToInt(Request["rows"].ToString(), 15);
            }
            int pageCount = 0;
            int totalCount = 0;
            var getScore = _sco.ScoreList(pageIndex, pageSize, keyWord, count, ref totalCount, ref pageCount);
            return Json(new
            {
                rows = getScore.ToArray(),
                total = totalCount
            });
        }


        /// <summary>
        /// 增加学生成绩信息
        /// </summary>
        /// <param name="studentInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddStudentScoreInformation(T.Models.Stu_Score studentInfo)
        {
            Commen.ReturnValue returnValue = new Commen.ReturnValue(0, "增加成功！", "");

            var IsTrueOrFalse = _sco.AddStudent(studentInfo);
            if (IsTrueOrFalse)
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
        /// 删除信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteStudentScore(string ids)
        {

            Commen.ReturnValue returnValue = new Commen.ReturnValue(0, "删除成功！", "");
            var value = _sco.DeleteStudentScore(ids);
            if (value)
            {
                return Json(returnValue);
            }
            else
            {
                returnValue.Success = 1;
                returnValue.Message = "删除失败！";
                return Json(returnValue);
            }


        }
        /// <summary>
        /// 通过学生的学号 获得详细信息
        /// </summary>
        /// <param name="stuNum"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetStudentScoreByStudentID(string stuNum, string stuTime)
        {

            var getmodel = _sco.GetGetStudentScoreByStudentID(stuNum, stuTime);


            return Json(getmodel.ToArray());
        }

        /// <summary>
        /// 修改成绩信息
        /// </summary>
        /// <param name="studentInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ChangeStudentScore(T.Models.Stu_Score studentInfo)
        {
            Commen.ReturnValue returnval = new Commen.ReturnValue(0, "修改成功！", "");
            var change = _sco.ChangeStuScore(studentInfo);
            if (change)
            {
                return Json(returnval);
            }
            else
            {
                returnval.Success = 1;
                returnval.Message = "修改失败！";
                return Json(returnval);
            }

        }
        #endregion










    }
}
