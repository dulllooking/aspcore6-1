using System.Net.Mail;

namespace aspcore6_1.Service
{
    /// <summary>
    /// Gmail 發信服務
    /// </summary>
    public class GmailService : IMail
    {
        public string Account { get; set; }

        public string Password { get; set; }

        public GmailService()
        {
            Account = "topidea.justin@gmail.com";
            Password = "12345678";
        }

        /// <summary>
        /// 一般發送信件
        /// </summary>
        /// <param name="mailTo">收信人</param>
        /// <param name="subject">信件主旨</param>
        /// <param name="body">信件內容</param>
        public void SendMail(string mailTo, string subject, string body)
        {
            //send mail
            MailMessage mailMessage = new MailMessage(Account, mailTo);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;
            // SMTP Server
            SmtpClient mailSender = new SmtpClient("smtp.gmail.com");
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(Account, Password);
            mailSender.Credentials = basicAuthenticationInfo;
            mailSender.Port = 587;
            mailSender.EnableSsl = true;
            mailSender.Send(mailMessage);
            mailMessage.Dispose();
        }

        /// <summary>
        /// 發送信件CC副本
        /// </summary>
        /// <param name="mailTo">收信人</param>
        /// <param name="subject">信件主旨</param>
        /// <param name="body">信件內容</param>
        /// <param name="mailToCC">CC收信人</param>
        public void SendMailWithCC(string mailTo, string subject, string body, string mailToCC)
        {
            //send mail
            MailMessage mailMessage = new MailMessage(Account, mailTo);
            mailMessage.Subject = subject;
            mailMessage.CC.Add(mailToCC);
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;
            // SMTP Server
            SmtpClient mailSender = new SmtpClient("smtp.gmail.com");
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(Account, Password);
            mailSender.Credentials = basicAuthenticationInfo;
            mailSender.Port = 587;
            mailSender.EnableSsl = true;
            mailSender.Send(mailMessage);
            mailMessage.Dispose();
        }

        /// <summary>
        /// 發送信件夾帶附件
        /// </summary>
        /// <param name="mailTo">收信人</param>
        /// <param name="subject">信件主旨</param>
        /// <param name="body">信件內容</param>
        /// <param name="filePath">附件本地路徑</param>
        public void SendMailWithFile(string mailTo, string subject, string body, string filePath)
        {
            //send mail
            MailMessage mailMessage = new MailMessage(Account, mailTo);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;
            Attachment attachment = new Attachment(filePath);
            mailMessage.Attachments.Add(attachment);

            // SMTP Server
            SmtpClient mailSender = new SmtpClient("smtp.gmail.com");
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(Account, Password);
            mailSender.Credentials = basicAuthenticationInfo;
            mailSender.Port = 587;
            mailSender.EnableSsl = true;
            mailSender.Send(mailMessage);
            mailMessage.Dispose();
        }
    }
}
