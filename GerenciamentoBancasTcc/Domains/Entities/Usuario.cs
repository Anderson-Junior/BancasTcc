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

        [NotMapped]
        public string UserRoles { get; set; }

        public ICollection<UsuarioBanca> UsuariosBancas { get; set; }
        public ICollection<Banca> Bancas { get; set; }
        public ICollection<Formulario> Formularios { get; set; }

        //public ICollection<Convite> ConvitesCoodenadores { get; set; }
        public Convite ConviteProfessor { get; set; }
        public string DiasDisponiveis { get; set; }
    }
}
