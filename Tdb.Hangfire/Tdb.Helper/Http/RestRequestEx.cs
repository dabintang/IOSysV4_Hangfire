using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tdb.Helper.Http
{
    /// <summary>
    /// RestRequest扩展
    /// </summary>
    public class RestRequestEx : RestRequest
    {
        /// <summary>
        /// 使用自定义的JSON序列化类
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="method">方法</param>
        /// <param name="jsonSerializer">JSON序列化类</param>
        public RestRequestEx(string url, Method method, ISerializer jsonSerializer) : base(url, method)
        {
            this.JsonSerializer = jsonSerializer;
        }
    }
}
