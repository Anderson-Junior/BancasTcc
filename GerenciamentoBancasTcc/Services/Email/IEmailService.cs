using System.Collections.Generic;

namespace GerenciamentoBancasTcc.Services.Email
{
    public interface IEmailService
    {
        bool SendMail(string email);
    }
}
