using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    [Table("TipoQuestoes")]
    public class TipoQuestao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoQuestaoId { get; set; }
        public string Descricao { get; set; }
        public ICollection<Questao> Questoes { get; set; }
    }
}
