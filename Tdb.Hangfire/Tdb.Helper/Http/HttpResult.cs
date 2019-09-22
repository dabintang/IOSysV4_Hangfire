using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Tdb.Helper.Http
{
    /// <summary>
    /// Http请求结果
    /// </summary>
    public class HttpResult<T>
    {
        /// <summary>
        /// Contains the values of status codes defined for HTTP.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// 错误异常
        /// </summary>
        public Exception ErrorException { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public T Result { get; set; }
    }
}
