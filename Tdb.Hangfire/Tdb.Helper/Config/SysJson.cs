using System;
using System.Collections.Generic;
using System.Text;

namespace Tdb.Helper.Config
{
    /// <summary>
    /// 系统的json信息
    /// </summary>
    public class SysJson
    {
        #region 单例

        /// <summary>
        /// 构造函数
        /// </summary>
        private SysJson()
        {
        }

        private static object _lock = new object();
        private static SysJson _inst = null;
        /// <summary>
        /// 单例
        /// </summary>
        public static SysJson Inst
        {
            get
            {
                if (_inst == null)
                {
                    lock (_lock)
                    {
                        if (_inst == null)
                        {
                            _inst = new SysJson();
                        }
                    }
                }

                return _inst;
            }
        }

        #endregion

        #region 变量

        /// <summary>
        ///系统配置信息
        /// </summary>
        public SysConfig Sys { get; set; }

        #endregion
    }
}
