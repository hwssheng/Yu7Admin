using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web; 

namespace Yu7Admin.Core.Utility
{
    public class StringUtility
    {
        public static long[] ConvertToBigIntArray(string value, char seperator)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new long[] {0};
            }

            var strArr = value.Split(seperator);
            var longArr = new long[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                longArr[i] = ConvertToBigInt(strArr[i]);
            }
            return longArr;
        }

        public static int[] ConvertToInt32Array(string value, char seperator)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            var strArr = value.Split(seperator);
            var intArr = new int[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                intArr[i] = ConvertToInt(strArr[i]);
            }
            return intArr;
        }

        public static int ConvertToInt(string value, int def = 0)
        {
            int result = 0;
            return int.TryParse(value, out result) ? result : def;
        }

        public static long ConvertToBigInt(string value, long def = 0)
        {
            long result = 0;
            return long.TryParse(value,out result) ? result : def;
        }

        public static decimal ConvertToDecimal(string value, decimal def = 0)
        {
            decimal result = 0;
            return decimal.TryParse(value, out result) ? result : def;
        }

        public static DateTime ConvertToDateTime(string value)
        {
            var result = DateTime.MinValue;
            DateTime.TryParse(value, out result);
            return result;
        }

        public static bool ConvertToBool(string value)
        {
            var result = false;
            bool.TryParse(value, out result);
            return result;
        }

        public static string NewGuidHashCode()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode()).ToString();
        }

        /// <summary>
        /// 返回图片地址
        /// </summary>
        /// <param name="content">提取的内容</param>
        /// <returns></returns>
        public static List<string> GetImgUrl(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return null;
            }
            var regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);  
            var matches = regImg.Matches(content);
            if (matches.Count < 1)
            {
                return null;
            }
            var i = 0;
            var list = new string[matches.Count]; 
            foreach (Match match in matches)
            {
                list[i++] = match.Groups["imgUrl"].Value;
            }
            return list.Where(d => !string.IsNullOrEmpty(d)).ToList();
        }
         
        public static string LineFeed(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return input.Replace("\r\n", "<br/>")
                .Replace("\n","<br/>")
                .Replace("\r","<br/>");
        }
    }
}