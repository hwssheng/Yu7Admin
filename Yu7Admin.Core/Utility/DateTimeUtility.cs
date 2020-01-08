using System;

namespace Yu7Admin.Core.Utility
{
    public class DateTimeUtility
    {
        /// <summary>
        /// 时间戳转换
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long GetTimeStamp(DateTime date)
        {
            TimeSpan ts = date - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }
        /// <summary>
        /// 时间戳转换
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            return GetTimeStamp(DateTime.Now);
        }
        /// <summary>
        /// 时间戳转换
        /// </summary>
        /// <param name="date"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static long GetTimeStamp(DateTime date,int day)
        { 
            return GetTimeStamp(date.AddDays(day));
        }
        /// <summary>
        /// 时间戳转换(当前事件加x天)
        /// </summary> 
        /// <param name="day"></param>
        /// <returns></returns>
        public static long GetTimeStamp(int day)
        {
            return GetTimeStamp(DateTime.Now.AddDays(day));
        }
    }
}