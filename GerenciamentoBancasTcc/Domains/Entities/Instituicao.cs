using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Instituicao
    {
        [Key]
        [Column("InstituicaoId")]
        public int InstituicaoId { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "É necessário informar o nome da instituição.")]
        public string Nome { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        public virtual List<Filial> Filiais { get; set; } = new List<Filial>();
    }
}
