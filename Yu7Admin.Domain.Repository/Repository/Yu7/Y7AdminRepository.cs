/********************************************************************************  
 * NameSpace:    Yu7Admin.Domain.Repository.Repository.Yu7
 * FileName:     Y7AdminRepository 
 * Create By:    Yu7.work
 * Email:        hws_1230@126.com
 * Create Time:  2020/1/4 3:12:10
 
 * Description:
 * 
 
 ********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yu7Admin.Core.Models;
using Yu7Admin.Domain.IRepository;
using Yu7Admin.Domain.IRepository.Repository.Yu7;

namespace Yu7Admin.Domain.Repository.Repository.Yu7
{
    public class Y7AdminRepository : Repository<Y7Admin>, IY7AdminRepository
    {
    }
}
