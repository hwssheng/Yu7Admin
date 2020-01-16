/********************************************************************************  
 * NameSpace:    Yu7Admin.Domain.Repository
 * FileName:     Repository 
 * Create By:    Yu7.work
 * Email:        hws_1230@126.com
 * Create Time:  2020/1/4 2:10:33
 
 * Description:
 * 
 
 ********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Yu7Admin.Core.Models;
using Yu7Admin.Domain.IRepository;

namespace Yu7Admin.Domain.IRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public bool Delete(T obj, Db db = null)
        {
            if(db==null)
                db = new Db(); 
            db.Remove(obj); 
            return db.SaveChanges()>0;
        }

        public void Dispose()
        {

        }

        public T Get(Expression<Func<T, bool>> whereLambda)
        {
            Db db = new Db(); 
            return db.Set<T>().Where(whereLambda).FirstOrDefault();
        }
        public List<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            Db db = new Db();
            return db.Set<T>().Where(whereLambda).ToList();
        }

        public List<T> GetAll()
        {
            Db db = new Db();
            return db.Set<T>().ToList();
        }

        public int Insert(T obj, Db db = null)
        {
            if (db == null)
                db = new Db();
            db.Set<T>().Add(obj); 
            return db.SaveChanges();
        }
         
        public bool Update(T obj, Db db = null)
        {
            if (db == null)
                db = new Db();
            db.Set<T>().Update(obj);
            return db.SaveChanges()>=1;
        }
    }
}
