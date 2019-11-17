using Hangfire;
using Hangfire.MySql.Core;
using Hangfire.RecurringJobExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Tdb.Hangfire.ConsoleApp.Filters;
using Tdb.Hangfire.ConsoleApp.Jobs;
using Tdb.Helper.Config;

namespace Tdb.Hangfire.ConsoleApp
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //使用hangfire面板
            //app.UseHangfireDashboard();
            //使用hangfire面板授权
            app.UseHangfireDashboard(
                options: new DashboardOptions() { Authorization = new[] { 
                    BaseDashboardAuthorizationFilter.Create(SysJson.Inst.Sys.HangfireAuth, SysJson.Inst.Sys.HangfireUrlKey) } }
                );
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(x =>
            {
                //使用mysql
                //x.UseStorage(new MySqlStorage(SysJson.Inst.Sys.DBConnStr, new MySqlStorageOptions() { QueuePollInterval = TimeSpan.FromSeconds(1) }));
                x.UseStorage(new MySqlStorage(SysJson.Inst.Sys.DBConnStr));
                //加载周期任务
                x.UseRecurringJob(typeof(RecurringJobs));
            });

            //添加服务
            services.AddHangfireServer();
        }
    }
}
