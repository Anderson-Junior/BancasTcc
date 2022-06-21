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
        [Required(ErrorMessage = "É necessário preencher o nome do aluno.")]
        public string Nome { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Display(Name = "Turma")]
        [Required(ErrorMessage = "É necessário selecionar a turma.")]
        public int? TurmaId { get; set; }
        public Turma Turma { get; set; }

        public ICollection<AlunosBancas> AlunosBancas { get; set; }
    }
}
