using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.MySql.Core;
using Hangfire.RecurringJobExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tdb.Hangfire.Filters;
using Tdb.Hangfire.Jobs;
using Tdb.Helper.Config;

namespace Tdb.Hangfire
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mvcBuilder = services.AddMvc(AddFilters);
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region hangfire

            //hangfire的任务需要数据库持久化
            //Hangfire.AspNetCore
            //Hangfire.MySql.Core  mysql引用 大小写敏感
            //Hangfire.SqlServer   sqlserver引用 大小写敏感

            //hangfire必须需要绑定一个持久化的连接数据。 官方推荐的是sqlserver,还有mg,mssql,pgsql,redis都是个人封装的
            //连接字符串必须加 Allow User Variables=true
            //services.AddHangfire(x => x.UseStorage(new MySqlStorage(
            //    "server=127.0.0.1;database=TdbHangfire;user id=root;password=t1234567890;Allow User Variables=True",
            //    new MySqlStorageOptions
            //    {
            //        TransactionIsolationLevel = IsolationLevel.ReadCommitted, // 事务隔离级别。默认是读取已提交。
            //        QueuePollInterval = TimeSpan.FromSeconds(15),             //- 作业队列轮询间隔。默认值为15秒。
            //        JobExpirationCheckInterval = TimeSpan.FromHours(1),       //- 作业到期检查间隔（管理过期记录）。默认值为1小时。
            //        CountersAggregateInterval = TimeSpan.FromMinutes(5),      //- 聚合计数器的间隔。默认为5分钟。
            //        PrepareSchemaIfNecessary = true,                          //- 如果设置为true，则创建数据库表。默认是true。
            //        DashboardJobListLimit = 50000,                            //- 仪表板作业列表限制。默认值为50000。
            //        TransactionTimeout = TimeSpan.FromMinutes(1),             //- 交易超时。默认为1分钟。
            //        TablePrefix = ""                                  //- 数据库中表的前缀。默认为none
            //    }
            //    )));
            services.AddHangfire(x =>
            {
                //使用mysql
                x.UseStorage(new MySqlStorage(SysJson.Inst.Sys.DBConnStr));
                //加载周期任务
                x.UseRecurringJob(typeof(RecurringJobs));
            });

            //添加服务
            services.AddHangfireServer();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //使用hangfire面板
            app.UseHangfireDashboard();

            app.UseMvc();
        }

        /// <summary>
        /// 添加过滤器
        /// </summary>
        /// <param name="option">配置</param>
        private void AddFilters(MvcOptions option)
        {
            //异常过滤器
            option.Filters.Add(typeof(ExcpFilterAttribute));
        }
    }
}
