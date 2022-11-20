using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    [Table("BancaPossiveisDataHora")]
    public class BancaPossivelDataHora
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BancaPossivelDataHoraId { get; set; }
        public DateTime PossivelDataHora { get; set; }

        public int BancaId { get; set; }
        public Banca Banca { get; set; }
    }
}
