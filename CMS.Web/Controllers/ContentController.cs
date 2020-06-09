using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMS.Web.Controllers
{
    /// <summary>
    /// 2020.05.15
    /// Calvin
    /// Content控制器
    /// </summary>
    public class ContentController : Controller
    {
        //IOC-依赖注入-控制反转
        private readonly ILogger<ContentController> _logger;

        public ContentController(ILogger<ContentController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 首页显示
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var contents = new List<Content>();
            for (int i = 1; i < 11; i++)
            {
                contents.Add(new Content { Id = i, title = $"{i}的标题", content = $"{i}的内容", status = 1, add_time = DateTime.Now.AddDays(-i) });
            }
            this._logger.LogInformation(contents.ToString());
            return View(new ContentViewModel { Contents = contents });
        }
    }
}