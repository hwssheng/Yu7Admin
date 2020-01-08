/********************************************************************************  
 * NameSpace:    Yu7Admin.Domain.Repository
 * FileName:     IRepository 
 * Create By:    Yu7.work
 * Email:        hws_1230@126.com
 * Create Time:  2020/1/3 17:54:25
 
 * Description:
 * 
 
 ********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using Yu7Admin.Core.Models;

namespace Yu7Admin.Domain.IRepository
{

    public interface IRepository<T> : IDisposable where T : class 
    { 
        T Get(Expression<Func<T, bool>> whereLambda);

        List<T> GetAll();
        List<T> GetList(Expression<Func<T, bool>> whereLambda);

        int Insert(T obj, Db db = null);

        bool Delete(T obj, Db db = null); 

        bool Update(T obj, Db db = null);
         
    }
}
