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

        public string Nome { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        public ICollection<Aluno> Alunos { get; set; }
        public ICollection<Banca> Banca { get; set; }
    }
}
