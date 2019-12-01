using System;
using System.Collections.Generic;
using System.Text;

namespace Tdb.Helper.Config
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class SysConfig
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string DBConnStr { get; set; }

        /// <summary>
        /// 仪表盘登录用户名
        /// </summary>
        public string HangfireAuth { get; set; }

        /// <summary>
        /// 仪表盘登录用户参数名
        /// </summary>
        public string HangfireUrlKey { get; set; }

        /// <summary>
        /// 自宿地址
        /// </summary>
        public string AppUrl { get; set; }

        /// <summary>
        /// 模拟收支接口地址
        /// </summary>
        public string SimulatorApiUrl { get; set; }

        /// <summary>
        /// api地址配置
        /// </summary>
        public ApiUrlConfig ApiUrl { get; set; }

        /// <summary>
        /// 邮箱地址配置
        /// </summary>
        public EmailAddrConfig EmailAddr { get; set; }

        /// <summary>
        /// email配置
        /// </summary>
        public EmailConfig Email { get; set; }
    }

    /// <summary>
    /// api地址配置
    /// </summary>
    public class ApiUrlConfig
    {
        /// <summary>
        /// 根地址
        /// </summary>
        public string Base { get; set; }

        /// <summary>
        /// 备份数据库
        /// </summary>
        public string BackupDB { get; set; }

        /// <summary>
        /// 更新账户的排序权重
        /// </summary>
        public string UpdateAmountAccountSortWeight { get; set; }

        /// <summary>
        /// 更新收入类型的排序权重
        /// </summary>
        public string UpdateInTypeSortWeight { get; set; }

        /// <summary>
        /// 更新支出类型的排序权重
        /// </summary>
        public string UpdateOutTypeSortWeight { get; set; }
    }

    /// <summary>
    /// 邮箱地址配置
    /// </summary>
    public class EmailAddrConfig
    {
        /// <summary>
        /// 备份数据库
        /// </summary>
        public string BackupIODBFails { get; set; }
    }

    /// <summary>
    /// email配置
    /// </summary>
    public class EmailConfig
    {
        /// <summary>
        /// SMTP 服务器地址
        /// </summary>
        public string SmtpHost { get; set; }

        /// <summary>
        /// SMTP 服务器端口
        /// </summary>
        public int SmtpPort { get; set; }

        /// <summary>
        /// SMTP密码
        /// </summary>
        public string SmtpPwd { get; set; }

        /// <summary>
        /// 发件人名称
        /// </summary>
        public string FromEmailName { get; set; }

        /// <summary>
        /// 发件人邮箱
        /// </summary>
        public string FromEmail { get; set; }
    }
}
