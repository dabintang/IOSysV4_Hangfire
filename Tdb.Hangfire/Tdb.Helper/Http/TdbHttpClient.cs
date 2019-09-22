using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tdb.Helper.Http
{
    /// <summary>
    /// Http客户端调用
    /// </summary>
    public class TdbHttpClient
    {
        #region 变量

        /// <summary>
        /// 用于发送http请求的组件
        /// </summary>
        public RestClient client { get; set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseUrl">baseUrl</param>
        public TdbHttpClient(string baseUrl)
        {
            this.client = new RestClient(baseUrl);
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">url地址</param>
        /// <param name="method">方法</param>
        /// <param name="paramObj">参数</param>
        /// <param name="headerObj">头部参数</param>
        /// <returns></returns>
        public IRestResponse Execute(string url, Method method, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            //请求上线文
            var request = new RestRequestEx(url, method, new NewtonsoftJsonSerializer());

            //添加参数
            RestRequestWithParam(request, method, paramObj);

            //添加头部参数
            RestRequestWithHeader(request, headerObj);

            //请求
            var res = this.client.Execute(request);

            return res;
        }

        /// <summary>
        /// 请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">url地址</param>
        /// <param name="method">方法</param>
        /// <param name="paramObj">参数</param>
        /// <param name="headerObj">头部参数</param>
        /// <returns></returns>
        public HttpResult<T> Exec<T>(string url, Method method, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            //请求上线文
            var request = new RestRequestEx(url, method, new NewtonsoftJsonSerializer());

            //添加参数
            RestRequestWithParam(request, method, paramObj);

            //添加头部参数
            RestRequestWithHeader(request, headerObj);

            //请求
            var res = this.client.Execute<HttpResult<T>>(request);

            res.Data.Result = JsonConvert.DeserializeObject<T>(res.Content);
            res.Data.StatusCode = res.StatusCode;
            res.Data.ErrorException = res.ErrorException;
            res.Data.ErrorMessage = res.ErrorMessage;

            return res.Data;
        }

        /// <summary>
        /// GET请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">url地址</param>
        /// <param name="paramObj">参数</param>
        /// <param name="headerObj">头部参数</param>
        /// <returns></returns>
        public HttpResult<T> ExecGet<T>(string url, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.Exec<T>(url, Method.GET, paramObj, headerObj);
        }

        /// <summary>
        /// POST请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">url地址</param>
        /// <param name="paramObj">参数</param>
        /// <param name="headerObj">头部参数</param>
        /// <returns></returns>
        public HttpResult<T> ExecPost<T>(string url, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.Exec<T>(url, Method.POST, paramObj, headerObj);
        }

        /// <summary>
        /// PUT请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">url地址</param>
        /// <param name="paramObj">参数</param>
        /// <param name="headerObj">头部参数</param>
        /// <returns></returns>
        public HttpResult<T> ExecPut<T>(string url, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.Exec<T>(url, Method.PUT, paramObj, headerObj);
        }

        /// <summary>
        /// DELETE请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">url地址</param>
        /// <param name="paramObj">参数</param>
        /// <param name="headerObj">头部参数</param>
        /// <returns></returns>
        public HttpResult<T> ExecDelete<T>(string url, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.Exec<T>(url, Method.DELETE, paramObj, headerObj);
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="request">请求</param>
        /// <param name="method">请求方法</param>
        /// <param name="paramObj">条件</param>
        protected void RestRequestWithParam(IRestRequest request, Method method, object paramObj)
        {
            if (paramObj != null)
            {
                switch (method)
                {
                    case Method.GET:
                        request.AddGetObject(paramObj);
                        break;
                    case Method.POST:
                        request.AddJsonBody(paramObj);
                        break;
                    case Method.PUT:
                        request.AddJsonBody(paramObj);
                        break;
                    case Method.DELETE:
                        request.AddJsonBody(paramObj);
                        break;
                    default:
                        request.AddObject(paramObj);
                        break;
                }
            }
        }

        /// <summary>
        /// 添加头部参数
        /// </summary>
        /// <param name="request">请求</param>
        /// <param name="headerObj">头部参数</param>
        protected void RestRequestWithHeader(IRestRequest request, IDictionary<string, string> headerObj)
        {
            if (headerObj != null)
            {
                foreach (KeyValuePair<string, string> item in headerObj)
                {
                    request.AddHeader(item.Key, item.Value);
                }
            }
        }

        #endregion
    }
}
