using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Equipe
    {
        [Key]
        [Column("EquipeId")]
        public int EquipeId { get; set; }

        [Column("Tema")]
        public string Tema { get; set; }

        public virtual List<Aluno> Alunos { get; set; }

        public int BancaId { get; set; }
        public virtual Banca Banca { get; set; }
    }
}
