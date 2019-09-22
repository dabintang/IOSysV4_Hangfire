using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tdb.Helper.Helper
{
    /// <summary>
    /// 通用帮助类
    /// </summary>
    public class ComHelper
    {
        /// <summary>
        /// 当前时间
        /// </summary>
        /// <returns></returns>
        public static DateTime Now()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 自动帮助拼接上程序根路径
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFullFileName(string fileName)
        {
            string appDataPath = AppDomain.CurrentDomain.BaseDirectory;
            string fullFileName = Path.Combine(appDataPath, fileName);

            return fullFileName;
        }

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">需要复制的对象</param>
        /// <returns></returns>
        public static T Clone<T>(T obj) where T : class
        {
            if (obj == null)
            {
                return null;
            }

            var jsonStr = JsonConvert.SerializeObject(obj);
            var newObj = JsonConvert.DeserializeObject<T>(jsonStr);

            return newObj;
        }
    }
}
