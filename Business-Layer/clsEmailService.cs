using System;
using System.Net;
using System.Net.Mail;
using System.Text;
namespace Business_Layer
{
    public class clsEmailService
    {
        public static void SendEmail(string fromEmail, string password, string toEmail, string subject, string body, bool isBodyHtml)
        {
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential(fromEmail, password);
                smtp.EnableSsl = true;
                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress(fromEmail, "Residences Management System");
                    message.To.Add(toEmail);
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = isBodyHtml;
                    message.BodyEncoding = Encoding.UTF8;
                    message.SubjectEncoding = Encoding.UTF8;
                    smtp.Send(message);
                }
            }
        }
    }
}