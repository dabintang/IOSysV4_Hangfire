using System;
using System.Collections.Generic;
using System.Text;

namespace Tdb.Helper.Inner
{
    /// <summary>
    /// 日志类
    /// </summary>
    class Logger
    {
        #region 单例

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        private Logger(NLog.Logger logger)
        {
            this.logger = logger;
        }

        private NLog.Logger logger = null;
        private static object _lock = new object();
        private static Logger _inst = null;
        /// <summary>
        /// 单例
        /// </summary>
        public static Logger Inst
        {
            get
            {
                if (_inst == null)
                {
                    lock (_lock)
                    {
                        if (_inst == null)
                        {
                            _inst = new Logger(NLog.LogManager.GetCurrentClassLogger());
                        }
                    }
                }

                return _inst;
            }
        }

        #endregion

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public void Debug(string msg, params object[] args)
        {
            logger.Debug(msg, args);
        }

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public void Debug(Exception ex, string msg, params object[] args)
        {
            logger.Debug(ex, msg, args);
        }

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public void Info(string msg, params object[] args)
        {
            logger.Info(msg, args);
        }

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public void Info(Exception ex, string msg, params object[] args)
        {
            logger.Info(ex, msg, args);
        }

        /// <summary>
        /// 痕迹日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public void Trace(string msg, params object[] args)
        {
            logger.Trace(msg, args);
        }

        /// <summary>
        /// 痕迹日志
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public void Trace(Exception ex, string msg, params object[] args)
        {
            logger.Trace(ex, msg, args);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public void Error(string msg, params object[] args)
        {
            logger.Error(msg, args);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public void Error(Exception ex, string msg, params object[] args)
        {
            logger.Error(ex, msg, args);
        }

        /// <summary>
        /// 致命日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public void Fatal(string msg, params object[] args)
        {
            logger.Fatal(msg, args);
        }

        /// <summary>
        /// 致命日志
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public void Fatal(Exception ex, string msg, params object[] args)
        {
            logger.Fatal(ex, msg, args);
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public void Warn(string msg, params object[] args)
        {
            logger.Warn(msg, args);
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public void Warn(Exception ex, string msg, params object[] args)
        {
            logger.Warn(ex, msg, args);
        }
    }
}
