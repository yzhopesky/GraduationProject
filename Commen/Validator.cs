using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Commen
{
    /// <summary>
    /// 验证类
    /// </summary>
    public class Validator
    {

        //private const string REG_DATE   = @"^(\d{2}|\d{4})[\-\/]((0?[1-9])|(1[0-2]))[\-\/]((0?[1-9])|((1|2)[0-9])|30|31)$"; 
        private const string REG_DATE = @"^(\d{2}|\d{4})((0[1-9])|(1[0-2]))((0[1-9])|((1|2)[0-9])|30|31)$";
        private const string REG_PHONE = @"^((0[0-9]{2,3}){0,1}([0-9]{7,8}))$";
        private const string REG_EMAIL = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        //private const string REG_MOBILE = @"(^0{0,1}13[0-9]{9}$)";
        private const string REG_MOBILE = @"(^(13[0-9]|15[0-9]|17[0-9]|18[0-9])[0-9]{8}$)";
        private const string REG_IDCARD = @"^([0-9]{14}|[0-9]{17})(x|[0-9]){1}$";
        private const string REG_TIME = @"^((([0-1]?[0-9])|(2[0-3]))([\:])([0-5][0-9]))$";


        /// <summary>
        /// 判断对象是否为Int32类型的数字
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static bool IsNumeric(object expression)
        {
            if (expression != null)
                return IsNumeric(expression.ToString());

            return false;

        }

        /// <summary>
        /// 判断对象是否为Int32类型的数字
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static bool IsNumeric(string expression)
        {
            if (expression != null)
            {
                string str = expression;
                if (str.Length > 0 && str.Length <= 11 && Regex.IsMatch(str, @"^[-]?[0-9]*[.]?[0-9]*$"))
                {
                    if ((str.Length < 10) || (str.Length == 10 && str[0] == '1') || (str.Length == 11 && str[0] == '-' && str[1] == '1'))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否为Double类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsDouble(object expression)
        {
            if (expression != null)
                return Regex.IsMatch(expression.ToString(), @"^([0-9])[0-9]*(\.\w*)?$");

            return false;
        }

        /// <summary>
        /// 判断给定的字符串数组(strNumber)中的数据是不是都为数值型
        /// </summary>
        /// <param name="strNumber">要确认的字符串数组</param>
        /// <returns>是则返加true 不是则返回 false</returns>
        public static bool IsNumericArray(string[] strNumber)
        {
            if (strNumber == null)
                return false;

            if (strNumber.Length < 1)
                return false;

            foreach (string id in strNumber)
            {
                if (!IsNumeric(id))
                    return false;
            }
            return true;
        }



        #region 半角验证
        /// <summary>
        /// 半角验证
        /// </summary>
        /// <param name="str">验证的字符串</param>
        /// <returns></returns>
        public static bool IsDBC(string str)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            int byteCount = encoding.GetByteCount(str);
            int strLen = str.Length;

            if (strLen == byteCount)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 全角验证
        /// <summary>
        /// 全角验证
        /// </summary>
        /// <param name="str">验证的字符串</param>
        /// <returns></returns>
        public static bool IsSBC(string str)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            int byteCount = encoding.GetByteCount(str);
            int strLen = str.Length;

            if (byteCount == strLen * 3)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 日期字符串有效性验证
        /// <summary>
        /// 日期字符串有效性验证
        /// </summary>
        /// <param name="date">日期字符串</param>
        /// <returns>有效:true,否则:false</returns>
        public static bool IsValidDate(string date)
        {
            return Regex.IsMatch(date, REG_DATE);
        }
        #endregion

        #region Email有效性验证
        /// <summary>
        /// Email有效性验证
        /// </summary>
        /// <param name="email">Email字符串</param>
        /// <returns>有效:true,否则:false</returns>
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, REG_EMAIL);
        }
        #endregion



        #region 电话号码有效性验证
        /// <summary>
        /// 电话号码有效性验证
        /// </summary>
        /// <param name="phone">电话号码字符串</param>
        /// <returns>有效:true,否则:false</returns>
        public static bool IsVaildPhone(string phone)
        {
            return Regex.IsMatch(phone, REG_PHONE);
        }
        #endregion

        #region 手机号码有效性验证
        /// <summary>
        /// 手机号码有效性验证
        /// </summary>
        /// <param name="mobile">手机号码字符串</param>
        /// <returns>有效:true,否则:false</returns>
        public static bool IsValidMobile(string mobile)
        {
            return Regex.IsMatch(mobile, REG_MOBILE);
        }
        #endregion

        #region 身份证号有效性验证
        /// <summary>
        /// 身份证号有效性验证
        /// </summary>
        /// <param name="idCard">身份证号字符串</param>
        /// <returns>有效:true,否则:false</returns>
        public static bool IsValidIdCard(string idCard)
        {
            return Regex.IsMatch(idCard, REG_IDCARD);
        }
        #endregion

        #region 日期字符串转换成日期对象
        /// <summary>
        /// 日期字符串转换成日期对象
        /// </summary>
        /// <param name="date">日期字符串</param>
        /// <returns>日期对象</returns>
        public static DateTime CastDateTime(string date)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(date.Substring(0, 4));
            builder.Append("-");
            builder.Append(date.Substring(4, 2));
            builder.Append("-");
            builder.Append(date.Substring(6, 2));

            return Convert.ToDateTime(builder.ToString());
        }
        #endregion

        #region 日期对象转化成日期字符串
        /// <summary>
        /// 日期对象转化成日期字符串
        /// </summary>
        /// <param name="date">日期对象</param>
        /// <returns>日期字符串</returns>
        public static string CastDateTime(DateTime date)
        {
            string strDate = date.ToString("yyyy-MM-dd");
            strDate = strDate.Replace("-", "");
            return strDate;
        }
        #endregion

        #region 时间格式验证
        /// <summary>
        /// 时间格式验证
        /// </summary>
        /// <param name="time">时间字符串</param>
        /// <returns>正确:true,错误:false</returns>
        public static bool IsValidTime(string time)
        {
            return Regex.IsMatch(time, REG_TIME);
        }
        #endregion

        #region Sql注入检测
         
        /// <summary>
        /// 是否含通过SQL注入检测（检测不通过 返回false,通过 返回true）
        /// </summary>
        /// <param name="str">传入用户提交数据</param>
        /// <returns>返回是否含有SQL注入式攻击代码</returns>
        /// ksf 2015年9月10日18:08:21
        public static bool IsCheckSqlStr(string str) 
        {
            const string sqlStr = "'|and|exec|insert|select|delete|update|count|*|chr|mid|master|truncate|char|declare";
            var returnValue = true;
            if (String.IsNullOrWhiteSpace(str))
            {
                return returnValue;
            }

	        try
	        { 
	            if (str != "")
	            {
	                var anySqlStr = sqlStr.Split('|');
	                foreach (var ss in anySqlStr) 
	                { 
	                    if (str.IndexOf(ss, StringComparison.OrdinalIgnoreCase)>=0)
	                    { 
	                        returnValue = false; 
	                    } 
	                } 
	             } 
	        } 
	        catch
	        { 
	             returnValue = false; 
	        } 
	        return returnValue; 
  
        } 
        
        #endregion


    }
}
