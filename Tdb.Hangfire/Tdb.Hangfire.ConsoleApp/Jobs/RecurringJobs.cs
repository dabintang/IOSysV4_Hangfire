using Hangfire.RecurringJobExtensions;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Text;
using Tdb.DTO.IOSys;
using Tdb.Helper.Config;
using Tdb.Helper.Helper;
using Tdb.Helper.Http;

namespace Tdb.Hangfire.ConsoleApp.Jobs
{
    /// <summary>
    /// 周期任务
    /// </summary>
    public class RecurringJobs
    {
        /// <summary>
        /// 每天凌晨3点备份收支系统数据库【[0 3 * * *]每天凌晨3点执行】/【[* * * * *]没分钟执行】
        /// </summary>
        /// <param name="context"></param>
        [RecurringJob("0 3 * * *", RecurringJobId = "每天凌晨3点备份收支系统数据库", TimeZone = "Asia/Shanghai")]
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
        [RecurringJob("0 1 * * *", RecurringJobId = "每天凌晨1点统计账户排序权重", TimeZone = "Asia/Shanghai")]
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
        [RecurringJob("0 1 * * *", RecurringJobId = "每天凌晨1点统计收入类型排序权重", TimeZone = "Asia/Shanghai")]
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
        [RecurringJob("0 1 * * *", RecurringJobId = "每天凌晨1点统计支出类型排序权重", TimeZone = "Asia/Shanghai")]
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

        ///// <summary>
        ///// 每天半夜23点演示系统模拟收支
        ///// </summary>
        ///// <param name="context"></param>
        //[RecurringJob("0 23 * * *", RecurringJobId = "每天半夜23点演示系统模拟收支", TimeZone = "Asia/Shanghai")]
        //public void AutoSimulatorInOut(PerformContext context)
        //{
        //    LogHelper.Info("开始[AutoSimulatorInOut] 每天半夜23点演示系统模拟收支");
            
        //    //头部参数
        //    var headerParams = new Dictionary<string, string>();
        //    headerParams["Authorization"] = "0";

        //    //参数
        //    var req = new { date = DateTime.Today };

        //    //请求备份接口
        //    try
        //    {
        //        var client = new TdbHttpClient("http://127.0.0.1:20003");
        //        //var resIn = client.ExecPost<ResultInfo<bool>>("api/AutoSimulator/SimulateInCome", req, headerParams);
        //        var resIn = client.Execute("api/AutoSimulator/SimulateInCome", RestSharp.Method.POST, req, headerParams);
        //        //var resOut = client.ExecPost<ResultInfo<bool>>("api/AutoSimulator/SimulateOutPut", req, headerParams);
        //        var resOut = client.Execute("api/AutoSimulator/SimulateOutPut", RestSharp.Method.POST, req, headerParams);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error(ex, "异常1：[AutoSimulatorInOut] 每天半夜23点演示系统模拟收支");
        //        if (ex.InnerException != null)
        //        {
        //            LogHelper.Error(ex.InnerException, "异常2：[AutoSimulatorInOut] 每天半夜23点演示系统模拟收支");
        //        }
        //    }

        //    LogHelper.Info("完成[AutoSimulatorInOut] 每天半夜23点演示系统模拟收支");
        //}
    }
}
