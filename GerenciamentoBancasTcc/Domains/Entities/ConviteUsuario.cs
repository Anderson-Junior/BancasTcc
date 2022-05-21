using System;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class ConviteUsuario
    {
        public int ConviteId { get; set; }
        public Convite Convite { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
