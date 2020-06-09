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
        /// Main�������������ڷ���
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //׼��һ��web����
            var hostBuilder = CreateHostBuilder(args);
            //����һ��web����
            var host = hostBuilder.Build();
            //����web����
            host.Run();
            //CreateHostBuilder(args)//
            //    .Build()
            //    .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //��log4net��־�����滻ϵͳ�Դ�����־
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
