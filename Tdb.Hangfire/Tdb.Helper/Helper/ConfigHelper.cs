using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tdb.Helper.Config;

namespace Tdb.Helper.Helper
{
    /// <summary>
    /// 配置帮助类
    /// </summary>
    public class ConfigHelper
    {
        #region 公共方法

        /// <summary>
        /// 初始化配置信息
        /// </summary>
        public static void Init()
        {
            //初始化系统配置信息
            InitSysConfig();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化系统配置信息
        /// </summary>
        private static void InitSysConfig()
        {
            if (SysJson.Inst.Sys == null)
            {
                string fullFileName = ComHelper.GetFullFileName("JSON/SysConfig.json");
                string jsonText = File.ReadAllText(fullFileName);
                SysJson.Inst.Sys = JsonConvert.DeserializeObject<SysConfig>(jsonText);
            }
        }

        #endregion
    }
}
