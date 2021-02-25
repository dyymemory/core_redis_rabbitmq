using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;

namespace core_redis
{
    public class RedisHelper
    {
        private static IDatabase _redisDB=null;
        public RedisHelper(string host, int port,string password)
        {
            
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints =
                {
                   { host, port }
                },
                Password = password,
                AllowAdmin = true
            };
            var redis = ConnectionMultiplexer.Connect(configurationOptions);
            _redisDB = redis.GetDatabase();

        }
        /// <summary>
        /// 根据key获取value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetString(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }
            else
            {
                return _redisDB.StringGet(key);
            }
        }
    }
}
