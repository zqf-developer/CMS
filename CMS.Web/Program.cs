using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CMS.Web
{
    public class Program
    {
        /// <summary>
        /// Main方法，程序的入口方法
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //准备一个web主机
            var hostBuilder = CreateHostBuilder(args);
            //创建一个web主机
            var host = hostBuilder.Build();
            //运行web主机
            host.Run();
            //CreateHostBuilder(args)//
            //    .Build()
            //    .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //用log4net日志配置替换系统自带的日志
                .ConfigureLogging((context, loggingBuilder) =>
                {
                    loggingBuilder.AddFilter("System", LogLevel.Warning);
                    loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
                    loggingBuilder.AddLog4Net();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
