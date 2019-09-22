using System;
using System.Collections.Generic;
using System.Text;

namespace Tdb.DTO.IOSys
{
    /// <summary>
    /// 结果接口
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        bool IsOK { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        string Msg { get; set; }
    }
}
