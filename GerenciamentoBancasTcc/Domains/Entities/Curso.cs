using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Curso
    {
        [Key]
        [Column("CursoId")]
        public int CursoId { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Periodos")]
        public int Periodos { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Display(Name = "Filial")]
        public int FilialId { get; set; }
        public virtual Filial Filial { get; set; }

        public ICollection<CursosAlunos> CursosAlunos { get; set; }
        public ICollection<Banca> Bancas { get; set; }
    }
}
