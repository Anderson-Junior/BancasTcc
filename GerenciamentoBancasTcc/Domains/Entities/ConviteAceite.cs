using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    [Table("ConviteAceites")]
    public class ConviteAceite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConviteAceiteId { get; set; }

        public Guid ConviteId { get; set; }
        public Convite Convite { get; set; }

        public DateTime PossivelDataHora { get; set; }
    }
}
