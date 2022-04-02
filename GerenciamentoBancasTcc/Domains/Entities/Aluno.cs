using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Aluno
    {
        [Key]
        [Column("AlunoId")]
        public int AlunoId { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Matricula")]
        public string Matricula { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        public ICollection<CursosAlunos> CursosAlunos { get; set; }

        [Display(Name = "Equipe")]
        public int? EquipeId { get; set; }
        public virtual Equipe Equipe { get; set; }
    }
}
