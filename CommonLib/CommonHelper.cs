using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace CommonLib
{
    public static class CommonHelper
    {
        #region GetDecimal 获取decimal        

        public static decimal GetDecimal(object key, decimal defaultVal = 0m)
        {
            if (key == null)
            {
                return defaultVal;
            }
            decimal value;
            return (decimal.TryParse(key.ToString(), out value)) ? value : defaultVal;
        }
        #endregion

        #region GetInt32 获取int

        public static int GetInt32(object key, int defaultVal = 0)
        {
            if (key == null)
            {
                return defaultVal;
            }
            int value;
            return (int.TryParse(key.ToString(), out value)) ? value : defaultVal;
        }
        #endregion

        #region GetTimeStamp 获取时间戳
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion

        #region ip
        /// <summary>
        /// 获取客户端IP地址（无视代理）
        /// </summary>
        /// <returns>若失败则返回回送地址</returns>
        public static string GetHostAddress()
        {
            var userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(userHostAddress))
            {
                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                    userHostAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
            }
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.UserHostAddress;
            }

            //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIp(userHostAddress))
            {
                return userHostAddress;
            }
            return "127.0.0.1";
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private static bool IsIp(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        #endregion ip

        #region sql防注入
        /// <summary>
        /// 判断字符串中是否有SQL攻击代码(true-安全；false-有注入攻击现有；)
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static bool ProcessSqlStr(string inputString)
        {
            var sqlStr = @"and|or|exec|execute|insert|select|delete|update|alter|create|drop|count|\*|chr|char|asc|mid|substring|master|truncate|declare|xp_cmdshell|restore|backup|net +user|net +localgroup +administrators";
            try
            {
                if (!string.IsNullOrEmpty(inputString))
                {
                    var strRegex = @"\b(" + sqlStr + @")\b";

                    var regex = new Regex(strRegex, RegexOptions.IgnoreCase);
                    if (regex.IsMatch(inputString))
                        return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
