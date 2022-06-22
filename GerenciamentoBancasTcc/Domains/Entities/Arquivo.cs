using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Arquivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArquivosId { get; set; }
        public string Descricao { get; set; }
        public byte[] Dados { get; set; }
        public string ContentType { get; set; }
        public Banca Banca { get; set; }
        public int BancaId { get; set; }
    }
}
