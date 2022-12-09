using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GerenciamentoBancasTcc.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly string username, smtpClient, password, port;

        public EmailService(IConfiguration configuration)
        {
            username = configuration["EmailConfiguration:Username"];
            smtpClient = configuration["EmailConfiguration:SmtpClient"];
            password = configuration["EmailConfiguration:Password"];
            port = configuration["EmailConfiguration:Port"];
        }

        public bool SendEmail(string email, string subject, string body)
        {
            try
            {
                var _mailMessage = new MailMessage
                {
                    Body = body,
                    Subject = subject,
                    IsBodyHtml = true,
                    From = new MailAddress(username)
                };

                var _smtpClient = new SmtpClient(smtpClient, int.Parse(port))
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(username, password)
                };

                _mailMessage.To.Add(email);
                _smtpClient.Send(_mailMessage);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
