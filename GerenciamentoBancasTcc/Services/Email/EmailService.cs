using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace GerenciamentoBancasTcc.Services.Email
{
    public class EmailService : IEmailService
    {
        public bool SendMail(string email)
        {
            try
            {
                MailMessage _mailMessage = new MailMessage();
                _mailMessage.From = new MailAddress("ander.junior@hotmail.com");
                _mailMessage.Subject = "Você está sendo convidado para participar de uma banca de TCC na UNIFACEAR Araucária";
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = File.ReadAllText(@"Views/Shared/EmailConvite.cshtml");

                SmtpClient _smtpClient = new SmtpClient("smtp.office365.com", Convert.ToInt32("587"));

                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("ander.junior@hotmail.com", "educar@5101");

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
