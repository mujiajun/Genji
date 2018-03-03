using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genji.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Genji.Api
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        [Route("login")]
        [HttpPost]

        public object Login([FromBody]User user)
        {
            var result = new XResult();
            if (user.username == "admin" && user.password == "admin")
            {
                result.Code = 20000;
                result.Data = user.username;
                return result;
            }
            result.Code = -1;
            result.Message = "用户名密码错误.";
            return result;
        }

        [Route("info")]
        [HttpGet]
        public object Info(string token)
        {
            return new XResult()
            {
                Code = 20000,
                Data = new
                {
                    roles = "超级管理员",
                    name = "徐程意",
                    avatar = ""
                }
            };
        }
    }
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}