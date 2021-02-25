using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_bll;
using core_entity;
using core_redis;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace core_redis_rabbitmq.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ResultModel<dynamic> GetString(string key)
        {
            string name = RedisHelper.GetString(key); 
            return new ResultModel<dynamic>() { Data = name };
        }

        // GET api/values/5
        [HttpGet]
        public ResultModel<dynamic> GetID(int id)
        {
            return new ResultModel<dynamic>() { Data = new Test_BLL().Getest(id) };
        }
    }
}
