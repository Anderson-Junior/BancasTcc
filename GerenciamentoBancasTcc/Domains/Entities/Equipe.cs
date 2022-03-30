using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Equipe
    {
        [Key]
        public int EquipeId { get; set; }

        public string Tema { get; set; }

        public virtual List<Aluno> Alunos { get; set; }

        [Display(Name = "Banca")]
        public int? BancaId { get; set; }
        public virtual Banca Banca { get; set; }
    }
}
