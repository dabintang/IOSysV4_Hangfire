using Hangfire;
using Hangfire.RecurringJobExtensions;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tdb.DTO.IOSys;
using Tdb.Helper.Config;
using Tdb.Helper.Helper;
using Tdb.Helper.Http;

namespace Tdb.Hangfire.Jobs
{
    /// <summary>
    /// 周期任务
    /// </summary>
    public class RecurringJobs
    {
        ///// <summary>
        ///// 测试每分钟执行一次（测试结果，即使不开浏览器也是会执行任务的!）
        ///// </summary>
        //[RecurringJob("* * * * *", RecurringJobId = "测试每分钟执行一次", TimeZone = "China Standard Time")]
        //public void TestPerMinute()
        //{
        //    LogHelper.Info($"开始[TestPerMinute] 测试每分钟执行一次：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        //}

        /// <summary>
        /// 每天凌晨3点备份收支系统数据库【[0 3 * * *]每天凌晨3点执行】/【[* * * * *]没分钟执行】
        /// </summary>
        /// <param name="context"></param>
        [RecurringJob("0 3 * * *", RecurringJobId = "每天凌晨3点备份收支系统数据库", TimeZone = "China Standard Time")]
        public void BackupIOSysDB(PerformContext context)
        {
            LogHelper.Info("开始[BackupIOSysDB] 备份收支系统数据库");

            //头部参数
            var headerParams = new Dictionary<string, string>();
            headerParams["Authorization"] = "0";

            //请求备份接口
            var client = new TdbHttpClient(SysJson.Inst.Sys.ApiUrl.Base);
            var res = client.ExecPost<ResultInfo<bool>>(SysJson.Inst.Sys.ApiUrl.BackupDB, null, headerParams);

            if (res.StatusCode == System.Net.HttpStatusCode.OK && res.Result.IsOK)
            {
                LogHelper.Info("完成[BackupIOSysDB] 备份收支系统数据库成功");
            }
            else
            {
                LogHelper.Info(res.ErrorException, $"失败[BackupIOSysDB] 备份收支系统数据库失败。错误信息：{res.Result.Msg}");

                //发送邮件
                var content = $"收支数据库备份失败,{DateTime.Now.ToString("yyyyMMdd")}";
                EmailHelper.Send(content, content, false, SysJson.Inst.Sys.EmailAddr.BackupIODBFails);
            }
        }

        /// <summary>
        /// 每天凌晨1点统计账户排序权重
        /// </summary>
        /// <param name="context"></param>
        [RecurringJob("0 1 * * *", RecurringJobId = "每天凌晨1点统计账户排序权重", TimeZone = "China Standard Time")]
        public void UpdateAmountAccountSortWeight(PerformContext context)
        {
            LogHelper.Info("开始[UpdateAmountAccountSortWeight] 统计账户排序权重");

            //头部参数
            var headerParams = new Dictionary<string, string>();
            headerParams["Authorization"] = "0";

            //请求备份接口
            var client = new TdbHttpClient(SysJson.Inst.Sys.ApiUrl.Base);
            var res = client.ExecPost<ResultInfo<bool>>(SysJson.Inst.Sys.ApiUrl.UpdateAmountAccountSortWeight, null, headerParams);

            LogHelper.Info("完成[UpdateAmountAccountSortWeight] 统计账户排序权重");
        }

        /// <summary>
        /// 每天凌晨1点统计收入类型排序权重
        /// </summary>
        /// <param name="context"></param>
        [RecurringJob("0 1 * * *", RecurringJobId = "每天凌晨1点统计收入类型排序权重", TimeZone = "China Standard Time")]
        public void UpdateInTypeSortWeight(PerformContext context)
        {
            LogHelper.Info("开始[UpdateInTypeSortWeight] 统计收入类型排序权重");

            //头部参数
            var headerParams = new Dictionary<string, string>();
            headerParams["Authorization"] = "0";

            //请求备份接口
            var client = new TdbHttpClient(SysJson.Inst.Sys.ApiUrl.Base);
            var res = client.ExecPost<ResultInfo<bool>>(SysJson.Inst.Sys.ApiUrl.UpdateInTypeSortWeight, null, headerParams);

            LogHelper.Info("完成[UpdateInTypeSortWeight] 统计收入类型排序权重");
        }

        /// <summary>
        /// 每天凌晨1点统计支出类型排序权重
        /// </summary>
        /// <param name="context"></param>
        [RecurringJob("0 1 * * *", RecurringJobId = "每天凌晨1点统计支出类型排序权重", TimeZone = "China Standard Time")]
        public void UpdateOutTypeSortWeight(PerformContext context)
        {
            LogHelper.Info("开始[UpdateOutTypeSortWeight] 统计支出类型排序权重");

            //头部参数
            var headerParams = new Dictionary<string, string>();
            headerParams["Authorization"] = "0";

            //请求备份接口
            var client = new TdbHttpClient(SysJson.Inst.Sys.ApiUrl.Base);
            var res = client.ExecPost<ResultInfo<bool>>(SysJson.Inst.Sys.ApiUrl.UpdateOutTypeSortWeight, null, headerParams);

            LogHelper.Info("完成[UpdateOutTypeSortWeight] 统计支出类型排序权重");
        }
    }
}
