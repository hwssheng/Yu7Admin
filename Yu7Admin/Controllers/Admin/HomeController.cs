using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using CacheManager.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Yu7Admin.Core;
using Yu7Admin.Core.Models;
using Yu7Admin.Core.Utility;
using Yu7Admin.Domain.IRepository;
using Yu7Admin.Domain.IRepository.Repository.Yu7;
using Yu7Admin.Domain.IRepository.ViewModels;
using Yu7Admin.Framework.Base; 
namespace Yu7Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IY7AdminRepository IY7AdminRepository { get; set; }
        public Yu7Admin.Framework.Cache.ICache ICacheManager { get; set; }
        

        public HomeController(IY7AdminRepository _IY7AdminRepository, Yu7Admin.Framework.Cache.ICache _ICacheManager)
        {
            IY7AdminRepository = _IY7AdminRepository;
            ICacheManager = _ICacheManager;
        }
        public void SubmitLogin() {
            bool isLogin = false;
            string msg = "";
            if (Request.Form["token"] == HttpContext.Session.GetString("VerifyCode")) {
                string pwd = Md5Utility.MD5Hash(Request.Form["password"]);
                string mobile = Request.Form["mobile"];
                Y7Admin admin = IY7AdminRepository.Get((a => a.Password == pwd && a.Mobile == mobile));
                if (admin != null)
                {
                    isLogin = true;
                    admin.AuthKey = VeryfyCodeUtility.CreatePass(32);
                    admin.ExpireTime = DateTimeUtility.GetTimeStamp(7);
                    IY7AdminRepository.Update(admin);

                    ICacheManager.Set("user", admin,100000);
                }
                else
                    msg = "密码错误或账号不存在";
            }
            else
                msg = "登录异常";
            if (isLogin)
            {
                urlRedirect("/home/index"); 
            }
            else
                urlMsgRedirect("/home/login",msg,Core.Enums.MsgStatus.error);
        }
        public IActionResult Login()
        {
            string VerifyCode = VeryfyCodeUtility.CreatePass(8);
            HttpContext.Session.SetString("VerifyCode", VerifyCode);
            ViewBag.VerifyCode = VerifyCode;
            bindMsg();
            return View();
        }
        public IActionResult Index()
        {
            bindMsg();
            Y7Admin admin =  ICacheManager.Get< Y7Admin>("user");
            ViewBag.admin = admin;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
