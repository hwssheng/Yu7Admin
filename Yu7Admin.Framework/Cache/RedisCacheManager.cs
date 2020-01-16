using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions; 

namespace Yu7Admin.Framework.Cache
{
    public class RedisCacheManager : ICache
    {
        private static CSRedis.CSRedisClient Csredis = null;

        public RedisCacheManager()
        {
            
        }

        static RedisCacheManager()
        {
            var configKey = ConfigurationManager.ConnectionStrings["RedisConfigKey"].ToString();
            var redisHost = ConfigurationManager.ConnectionStrings["RedisHost"].ToString();
            var redisPort = int.Parse(ConfigurationManager.ConnectionStrings["RedisPort"].ToString());

            //configKey = "redis";
            //redisHost = "localhost";
            //redisPort = 6379;
            string strCon = string.Format("{0}:{1},defaultDatabase=0,poolsize=10,ssl=false,writeBuffer=10240,prefix={2}", redisHost, redisPort, configKey);
            Csredis = new CSRedis.CSRedisClient(strCon) ; 
        }
        public T Get<T>(string key)
        {
            var obj = Csredis.Get<T>(key);
            if (obj is T)
            {
                return (T)obj;
            }
            return default(T); 
        } 

        public void Set(string key, object data, int cacheTime)
        {
            Csredis.Set(key, data, cacheTime);
        }
          
        public bool Contains(string key)
        {
            var value = Csredis.Get(key);
            return value != null;
        }
         

        public void Remove(string key)
        {
            Csredis.Del(key);
        }
   
        public void Clear()
        {
            RedisHelper.Initialization(Csredis); 
        }
         
    }
}