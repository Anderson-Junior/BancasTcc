using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace GerenciamentoBancasTcc.Services.Email
{
    public class EmailService : IEmailService
    {
        public bool SendMail(string email, string subject, string body)
        {
            try
            {
                MailMessage _mailMessage = new MailMessage();
                _mailMessage.From = new MailAddress("gerenciador.de.bancas@outlook.com");
                _mailMessage.Subject = subject;
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = body;

                SmtpClient _smtpClient = new SmtpClient("smtp.office365.com", Convert.ToInt32("587"));

                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("gerenciador.de.bancas@outlook.com", "Gerenciador123@");

                _smtpClient.EnableSsl = true;
                _mailMessage.CC.Add(email);
                _smtpClient.Send(_mailMessage);
 
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SendMailInvite(string email, string subject)
        {
            try
            {
                MailMessage _mailMessage = new MailMessage();
                _mailMessage.From = new MailAddress("gerenciador.de.bancas@outlook.com");
                _mailMessage.Subject = subject;
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = File.ReadAllText(@"Views/Shared/EmailConvite.cshtml");

                SmtpClient _smtpClient = new SmtpClient("smtp.office365.com", Convert.ToInt32("587"));

                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("gerenciador.de.bancas@outlook.com", "Gerenciador123@");

                _smtpClient.EnableSsl = true;
                _mailMessage.CC.Add(email);
                _smtpClient.Send(_mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
