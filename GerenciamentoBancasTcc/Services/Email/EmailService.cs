using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GerenciamentoBancasTcc.Services.Email
{
    public class EmailService : IEmailService
    {
        public bool SendMail()
        {
            try
            {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress("ander.junior@hotmail.com");

                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                _mailMessage.CC.Add("ander.lemos.jr@gmail.com");
                _mailMessage.Subject = "Teste Gerenciador de Bancas de TCC";
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = File.ReadAllText(@"Views/Shared/EmailConvite.cshtml");

                //CONFIGURAÇÃO COM PORTA
                SmtpClient _smtpClient = new SmtpClient("smtp.office365.com", Convert.ToInt32("587"));

                //CONFIGURAÇÃO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("ander.junior@hotmail.com", "senha");

                _smtpClient.EnableSsl = true;

                _smtpClient.Send(_mailMessage);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
