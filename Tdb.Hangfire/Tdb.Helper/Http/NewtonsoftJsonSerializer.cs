using Newtonsoft.Json;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tdb.Helper.Http
{
    /// <summary>
    /// 使用Newtonsoft.Json序列化
    /// </summary>
    public class NewtonsoftJsonSerializer : ISerializer
    {
        public string DateFormat
        {
            get;
            set;
        }

        public string RootElement
        {
            get;
            set;
        }

        public string Namespace
        {
            get;
            set;
        }

        public string ContentType
        {
            get;
            set;
        }

        public NewtonsoftJsonSerializer()
        {
            this.ContentType = "application/json";
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
