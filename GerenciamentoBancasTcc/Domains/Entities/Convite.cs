using GerenciamentoBancasTcc.Domains.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    [Table("Convites")]
    public class Convite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ConviteId { get; set; }

        [Display(Name = "Status")]
        public StatusConvite StatusConvite { get; set; }

        public int BancaId { get; set; }
        public Banca Banca { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public bool EmailEnviado { get; set; }

        public ICollection<ConviteAceite> ConviteAceites { get; set; }
    }
}
