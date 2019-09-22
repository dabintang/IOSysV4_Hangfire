using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using Tdb.Helper.Config;
using Tdb.Helper.Helper;

namespace Tdb.Hangfire.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化配置
            ConfigHelper.Init();

            var host =
                 new WebHostBuilder()
                 .UseKestrel()
                 .UseContentRoot(Directory.GetCurrentDirectory())
                 .UseUrls(SysJson.Inst.Sys.AppUrl)
                 .UseStartup<Startup>().Build();

            host.Run();
        }
    }
}
