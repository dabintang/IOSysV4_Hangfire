using System;
using System.Collections.Generic;
using System.Text;
using Tdb.Helper.Inner;

namespace Tdb.Helper.Helper
{
    /// <summary>
    /// 日志 帮助类
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public static void Debug(string msg, params object[] args)
        {
            Logger.Inst.Debug(msg, args);
        }

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public static void Debug(Exception ex, string msg, params object[] args)
        {
            Logger.Inst.Debug(ex, msg, args);
        }

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public static void Info(string msg, params object[] args)
        {
            Logger.Inst.Info(msg, args);
        }

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public static void Info(Exception ex, string msg, params object[] args)
        {
            Logger.Inst.Info(ex, msg, args);
        }

        /// <summary>
        /// 痕迹日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public static void Trace(string msg, params object[] args)
        {
            Logger.Inst.Trace(msg, args);
        }

        /// <summary>
        /// 痕迹日志
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public static void Trace(Exception ex, string msg, params object[] args)
        {
            Logger.Inst.Trace(ex, msg, args);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public static void Error(string msg, params object[] args)
        {
            Logger.Inst.Error(msg, args);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public static void Error(Exception ex, string msg, params object[] args)
        {
            Logger.Inst.Error(ex, msg, args);
        }

        /// <summary>
        /// 致命日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public static void Fatal(string msg, params object[] args)
        {
            Logger.Inst.Fatal(msg, args);
        }

        /// <summary>
        /// 致命日志
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public static void Fatal(Exception ex, string msg, params object[] args)
        {
            Logger.Inst.Fatal(ex, msg, args);
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public static void Warn(string msg, params object[] args)
        {
            Logger.Inst.Warn(msg, args);
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="msg">日志内容</param>
        /// <param name="args">参数</param>
        public static void Warn(Exception ex, string msg, params object[] args)
        {
            Logger.Inst.Warn(ex, msg, args);
        }
    }
}
