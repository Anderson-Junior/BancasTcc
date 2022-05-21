using System.Collections.Generic;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Convite
    {
        public int ConviteId { get; set; }
        public string Descrição { get; set; }
        public bool Aceito { get; set; }
        public ICollection<ConviteUsuario> ConvitesUsuarios { get; set; }
    }
}
