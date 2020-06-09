using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMS.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            this._logger.LogInformation("--访问User-Index---");

            //不同的传值方式
            #region ViewData

            base.ViewData["User01"] = new CurrentUser()
            {
                ID = 1,
                UserName = "C#",
                Account = "C#",
                Email = "xxx01@163.com",
                Password = "12345",
                LoginTime = DateTime.Now
            };

            #endregion

            #region TempData

            base.TempData["User02"] = new CurrentUser()
            {
                ID = 1,
                UserName = "C++",
                Account = "c++",
                Email = "xxx02@163.com",
                Password = "12345332",
                LoginTime = DateTime.Now
            };

            #endregion

            #region ViewBag

            base.ViewBag.User = new CurrentUser()
            {
                ID = 1,
                UserName = "CSS",
                Account = "css",
                Email = "xxx03@163.com",
                Password = "123455",
                LoginTime = DateTime.Now
            };


            #endregion

            #region Session:服务器内存的一段内容，在HttpContext

            if (string.IsNullOrWhiteSpace(this.HttpContext.Session.GetString("CurrentUserSession")))
            {
                //this-扩展方法，抽象设计最小化
                base.HttpContext.Session.SetString("CurrentUserSession",
                    Newtonsoft.Json.JsonConvert.SerializeObject(new CurrentUser()
                    {
                        ID = 2,
                        UserName = "Python",
                        Account = "python",
                        Email = "xxx04@gmail.com",
                        Password = "01234",
                        LoginTime = DateTime.Now
                    }));
            }

            #endregion

            #region Model传值

            return View(new CurrentUser() { 
                ID = 1,
                UserName = "C",
                Account = "c",
                Email = "xxx05@163.com",
                Password = "12311332",
                LoginTime = DateTime.Now
            });

            #endregion
        }
    }
}