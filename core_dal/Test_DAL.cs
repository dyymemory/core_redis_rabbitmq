using core_utilities;
using Dapper;
using System;
using System.Data;
using System.Linq;

namespace core_dal
{
    public class Test_DAL
    {
        public DataTable Getest(int id)
        {
            string sql = @"select top 10 * from Log";
            using (var conn = AdoConfig.GetDBConnection())
            {
                var a = conn.Query<dynamic>(sql).ToList();
                DataTable dt = new DataTable();
                dt.Load(conn.ExecuteReader(sql));
                return dt;
            }
        }
    }
}
