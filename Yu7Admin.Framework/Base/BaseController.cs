/********************************************************************************  
 * NameSpace:    Yu7Admin.Framework.Base
 * FileName:     BaseController 
 * Create By:    Yu7.work
 * Email:        hws_1230@126.com
 * Create Time:  2020/1/2 0:52:31
 
 * Description:
 * 
 
 ********************************************************************************/
using log4net;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Yu7Admin.Core.Enums;

namespace Yu7Admin.Framework.Base
{
    public class BaseController: Controller
    {
        protected readonly ILog Log = null;

        public BaseController()
        {
            Log = LogManager.GetLogger(GetType());
        }

        public void urlRedirect(string url)
        {
            Response.Redirect(url);
        }
        /// <summary>
        /// 显示信息
        /// </summary>
        public void bindMsg() { 
            ViewBag.MsgStatus = Request.Query["MsgStatus"].ToString() == "" ? "danger" : Request.Query["MsgStatus"].ToString();
            ViewBag.Msg = Request.Query["Msg"].ToString();
        }
        /// <summary>
        /// url 重定向并且显示信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        public void urlMsgRedirect(string url, string title)
        {
            urlMsgRedirect(url, title, MsgStatus.error);
        }
        /// <summary>
        /// url 重定向并且显示信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        public void urlMsgRedirect(string url, string title,MsgStatus status)
        {
            string strStatus = status.ToString() == "error" ? "danger" : status.ToString();
            if (url.IndexOf('?') >= 0)
                urlRedirect(url + "&MsgStatus="+ strStatus + "&Msg=" + System.Web.HttpUtility.UrlEncode(title));
            else
                urlRedirect(url + "?MsgStatus=" + strStatus + "&Msg=" + System.Web.HttpUtility.UrlEncode(title));
        }
    }
}
