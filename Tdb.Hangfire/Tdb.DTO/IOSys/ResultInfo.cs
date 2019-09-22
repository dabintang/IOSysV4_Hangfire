using System;
using System.Collections.Generic;
using System.Text;

namespace Tdb.DTO.IOSys
{
    /// <summary>
    /// 单个结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultInfo<T> : IResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOK { get; set; }

        /// <summary>
        /// 消息编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public T Info { get; set; }
    }
}
