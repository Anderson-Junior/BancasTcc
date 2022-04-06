using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Usuario : Microsoft.AspNetCore.Identity.IdentityUser
    {
        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        public ICollection<UsuarioBanca> UsuariosBancas { get; set; }
        public ICollection<Banca> Bancas { get; set; }
        public ICollection<DiasDisponiveis> DiasDisponiveis { get; set; }
    }
}
