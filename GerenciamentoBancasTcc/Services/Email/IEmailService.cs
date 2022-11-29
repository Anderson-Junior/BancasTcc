namespace GerenciamentoBancasTcc.Services.Email
{
    public interface IEmailService
    {
        bool SendMail(string email, string subject, string body);
    }
}
