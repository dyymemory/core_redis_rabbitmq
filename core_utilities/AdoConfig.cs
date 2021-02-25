using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace core_utilities
{
    public class AdoConfig
    {
        /// <summary>
        /// 链接数据库
        /// </summary>
        /// <returns></returns>
        public static IDbConnection GetDBConnection(string dbLink = null)
        {
            if (dbLink == null)
                return GetOpenConnection(ConfigFunction.GetConfig("ConnectionStrings"));
            else
                return GetOpenConnection(dbLink);
        }
        /// <summary>
        /// 获取一个打开的数据库连接对象 
        /// </summary>
        /// <param name="key">web.config中连接字符串的key</param>
        /// <returns></returns>
        private static IDbConnection GetOpenConnection(string key)
        {
            var connection = new SqlConnection(key);
            //判断连接状态
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
