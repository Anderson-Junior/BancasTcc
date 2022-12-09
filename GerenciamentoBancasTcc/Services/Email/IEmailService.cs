using System.Threading.Tasks;

namespace GerenciamentoBancasTcc.Services.Email
{
    public interface IEmailService
    {
        bool SendEmail(string email, string subject, string body);
    }
}
