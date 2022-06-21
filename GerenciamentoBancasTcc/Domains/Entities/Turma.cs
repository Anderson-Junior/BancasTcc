using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Turma
    {
        [Key]
        [Column("TurmaId")]
        public int TurmaId { get; set; }

        [Required(ErrorMessage = "É necessário informar um nome para a turma.")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Curso")]
        [Required(ErrorMessage = "É necessário selecionar um curso.")]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        public ICollection<Aluno> Alunos { get; set; }
        public ICollection<Banca> Banca { get; set; }
    }
}
