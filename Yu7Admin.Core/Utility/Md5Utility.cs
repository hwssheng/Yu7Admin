/********************************************************************************  
 * NameSpace:    Yu7Admin.Core.Utility
 * FileName:     Md5Utility 
 * Create By:    Yu7.work
 * Email:        hws_1230@126.com
 * Create Time:  2020/1/3 21:09:25
 
 * Description:
 * 
 
 ********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Yu7Admin.Core.Utility
{
    public class Md5Utility
    {
        /// netcore下的实现MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }
    }
}
