/********************************************************************************  
 * NameSpace:    Yu7Admin.Domain.Repository.Yu7
 * FileName:     Y7AdminModule 
 * Create By:    Yu7.work
 * Email:        hws_1230@126.com
 * Create Time:  2020/1/4 2:01:53
 
 * Description:
 * 
 
 ********************************************************************************/
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yu7Admin.Core.Models;
using Yu7Admin.Core.Utility;
using Yu7Admin.Domain.IRepository.Repository.Yu7;

namespace Yu7Admin.Domain.Repository.Yu7
{
    public class Y7AdminModule
    { 
        public IY7AdminRepository IY7Admin { get; set; }
        public int InsertY7Admin()
        {
            int res = 0;
            Y7Admin obj = new Y7Admin() { Username = "admin", Password = Md5Utility.MD5Hash("123456") };
            res = IY7Admin.Insert(obj);
            return res;
        } 
    }
}
