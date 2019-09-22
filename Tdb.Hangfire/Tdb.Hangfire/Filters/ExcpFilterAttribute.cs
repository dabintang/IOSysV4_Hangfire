using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tdb.Helper.Helper;

namespace Tdb.Hangfire.Filters
{
    /// <summary>
    /// 异常过滤器特性
    /// </summary>
    public class ExcpFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            //如果异常以及被处理过了，不再处理
            if (context.ExceptionHandled)
            {
                return;
            }

            //写日志
            var msg = string.Format("未知异常（Action：{0}）", context.ActionDescriptor.DisplayName);
            LogHelper.Error(context.Exception, msg);

            //返回错误信息
            context.Result = new ObjectResult(context.Exception);

            base.OnException(context);
        }
    }
}
