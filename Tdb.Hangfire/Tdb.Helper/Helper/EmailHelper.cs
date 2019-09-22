using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Tdb.Helper.Config;

namespace Tdb.Helper.Helper
{
    /// <summary>
    /// email帮助类
    /// </summary>
    public class EmailHelper
    {
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        /// <param name="isBodyHtml">内容是否html</param>
        /// <param name="to">收件人地址</param>
        /// <param name="attachments">附件完整文件名</param>
        /// <returns></returns>
        public static bool Send(string subject, string body, bool isBodyHtml, string to, params string[] attachments)
        {
            var lstTo = new List<string>() { to };
            return Send(subject, body, isBodyHtml, lstTo, null, attachments);
        }

        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        /// <param name="isBodyHtml">内容是否html</param>
        /// <param name="lstTo">收件人地址</param>
        /// <param name="lstCC">抄送地址</param>
        /// <param name="attachments">附件完整文件名</param>
        public static bool Send(string subject, string body, bool isBodyHtml, List<string> lstTo, List<string> lstCC, params string[] attachments)
        {
            try
            {
                //邮件发送类 
                var mail = new MailMessage();
                //是谁发送的邮件 
                mail.From = new MailAddress(SysJson.Inst.Sys.Email.FromEmail, SysJson.Inst.Sys.Email.FromEmailName);

                //收件人地址               
                foreach (var to in lstTo)
                {
                    mail.To.Add(to);
                }

                //抄送地址
                if (lstCC != null)
                {
                    foreach (var cc in lstCC)
                    {
                        mail.CC.Add(cc);
                    }
                }

                //标题 
                mail.Subject = subject;
                //内容编码 
                mail.BodyEncoding = Encoding.Default;
                //发送优先级 
                mail.Priority = MailPriority.Normal;
                //邮件内容 
                mail.Body = body;
                //是否HTML形式发送 
                mail.IsBodyHtml = isBodyHtml;
                //附件 
                foreach (var attachment in attachments)
                {
                    mail.Attachments.Add(new Attachment(attachment));
                }

                var smtp = GetSmtpClient();
                smtp.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"发送邮件[{subject}]失败", ex);
                return false;
            }
        }

        /// <summary>
        /// SMTP
        /// </summary>
        /// <returns></returns>
        private static SmtpClient GetSmtpClient()
        {
            //邮件服务器和端口 
            var smtp = new SmtpClient(SysJson.Inst.Sys.Email.SmtpHost, SysJson.Inst.Sys.Email.SmtpPort);
            //smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            //指定发送方式 
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //指定登录名和密码 
            smtp.Credentials = new System.Net.NetworkCredential(SysJson.Inst.Sys.Email.FromEmail, SysJson.Inst.Sys.Email.SmtpPwd);
            //超时时间 
            smtp.Timeout = 30000;

            return smtp;
        }
    }
}
