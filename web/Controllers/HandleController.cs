using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Source;

namespace web.Controllers
{
    public class HandleController : Controller
    {


        public T.BLL.Stu_AdminBLL _stuBLL = new T.BLL.Stu_AdminBLL();
        public T.BLL.Stu_ScoreBLL _scoBLL = new T.BLL.Stu_ScoreBLL();
        #region 视图
        //
        // GET: /Handle/
        /// <summary>
        /// 总的操作页面
        /// </summary>
        /// <returns></returns>
        [IsLoginOrFalse]
        public ActionResult Operate()
        {
            return View();
        }
        /// <summary>
        /// 教师操作页面
        /// </summary>
        /// <returns></returns>
        [IsLoginOrFalse]
        public ActionResult TeacherOperate()
        {
            return View();
        }
        /// <summary>
        /// 学生的操作页面
        /// </summary>
        /// <returns></returns>
        [IsLoginOrFalse]
        public ActionResult StudentOperate()
        {
            return View();
        }
        /// <summary>
        /// 增加用户信息
        /// </summary>
        /// <returns></returns>
        [IsLoginOrFalse]
        public ActionResult AddUserInfoAdmin()
        {
            return View();
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <returns></returns>
        [IsLoginOrFalse]
        public ActionResult PutExcel()
        {
            return View();
        }
        #endregion

        #region 增加用户
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddAdmin(string UserName, string UserPassWord, string typeID)
        {
            Commen.ReturnValue returnValue = new Commen.ReturnValue(0, "增加成功,请关闭页面避免重复添加！", "");
            int roleID = Convert.ToInt32(typeID);
            var getReasult = _stuBLL.AddAdmin(UserName, UserPassWord, roleID);
            if (getReasult)
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

       
        #region  导出

        public EmptyResult ExportExcle()
        {
            HSSFCellStyle style;
            HSSFFont font;
            var count = Request["count"];

            var getDataList = _scoBLL.GetStudentScore(Convert.ToInt32(count));
           
            
            string url = Server.MapPath(@"\Content\File\Score.xls");
            string sheetName = "MySheet";
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            FileStream filecreate = new FileStream(url, FileMode.Create, FileAccess.ReadWrite);
            //创建工作表
            HSSFSheet sheet = hssfworkbook.CreateSheet(sheetName) as HSSFSheet;
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("学生学号");
            row.CreateCell(1).SetCellValue("学生姓名");
            row.CreateCell(2).SetCellValue("第几次考试");
            row.CreateCell(3).SetCellValue("语文");
            row.CreateCell(4).SetCellValue("数学");
            row.CreateCell(5).SetCellValue("英语");
            row.CreateCell(6).SetCellValue("历史");
            row.CreateCell(7).SetCellValue("地理");
            row.CreateCell(8).SetCellValue("政治");
            row.CreateCell(9).SetCellValue("物理");
            row.CreateCell(10).SetCellValue("化学");
            row.CreateCell(11).SetCellValue("生物");
            row.CreateCell(12).SetCellValue("添加时间");
            //行高
            row.HeightInPoints = 20;
            //给表头单元格设置样式(对齐方式、边框、字体、背景颜色)
            List<ICell> cell = row.Cells;
            style = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
            font = hssfworkbook.CreateFont() as HSSFFont;
            font.IsItalic = true;//加粗
            font.FontName = "宋体";
            font.Color = HSSFColor.RED.index;//字体颜色
            style.SetFont(font);
            this.CellStyle(style, sheet);
            style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.GREEN.index;
            style.FillPattern = FillPatternType.SOLID_FOREGROUND;
            cell.ForEach(delegate(ICell c)
            {
                c.CellStyle = style;
            });

            //加载内容
            if (getDataList.Any())
            {
                style = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                // this.CellStyle(style, sheet);
                for (int i = 0; i < getDataList.Count; i++)
                {
                    row = sheet.CreateRow(i + 1);
                    row.HeightInPoints = 20;
                    row.CreateCell(0).SetCellValue(getDataList[i].stuNum.ToString());
                    row.CreateCell(1).SetCellValue(getDataList[i].stuName.ToString());
                    row.CreateCell(2).SetCellValue(getDataList[i].stuTime.ToString());
                    row.CreateCell(3).SetCellValue(getDataList[i].chinese.ToString());
                    row.CreateCell(4).SetCellValue(getDataList[i].math.ToString());
                    row.CreateCell(5).SetCellValue(getDataList[i].english.ToString());
                    row.CreateCell(6).SetCellValue(getDataList[i].history.ToString());
                    row.CreateCell(7).SetCellValue(getDataList[i].geography.ToString());
                    row.CreateCell(8).SetCellValue(getDataList[i].political.ToString());
                    row.CreateCell(9).SetCellValue(getDataList[i].physics.ToString());
                    row.CreateCell(10).SetCellValue(getDataList[i].chemistry.ToString());
                    row.CreateCell(11).SetCellValue(getDataList[i].biology.ToString());
                    row.CreateCell(12).SetCellValue(Commen.Utils.GetStandardDateTime(getDataList[i].createTime.ToString()));
                    cell = row.Cells;
                    cell.ForEach(p => p.CellStyle = style);
                }
            }
            //将流写入excel文件
            hssfworkbook.Write(filecreate);
            filecreate.Close();

            #region 下载文件
            FileStream fileopen = new FileStream(url, FileMode.Open);
            byte[] bytes = new byte[(int)fileopen.Length];
            fileopen.Read(bytes, 0, bytes.Length);
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode("Score.xls", System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            fileopen.Close();
            Response.Flush();
            Response.End();
            return new EmptyResult();
            #endregion
        }


        /// <summary>
        /// 样式
        /// </summary>
        /// <param name="style"></param>
        /// <param name="sheet"></param>
        private void CellStyle(HSSFCellStyle style, HSSFSheet sheet)
        {
            //自动换行
            style.WrapText = true;
            //边框
            style.BorderBottom = BorderStyle.THIN;
            style.BorderLeft = BorderStyle.THIN;
            style.BorderRight = BorderStyle.THIN;
            style.BorderTop = BorderStyle.THIN;
            //对齐方式
            style.Alignment = HorizontalAlignment.CENTER;
            style.VerticalAlignment = VerticalAlignment.CENTER;
            //设置第四列、第五列的宽度
            sheet.SetColumnWidth(0, 15 * 256);
            sheet.SetColumnWidth(2, 15 * 256);
            sheet.SetColumnWidth(12, 30 * 256);
        }



        #endregion




    }
}
