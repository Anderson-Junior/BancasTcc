using GerenciamentoBancasTcc.Domains.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    [Table("Convites")]
    public class Convite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ConviteId { get; set; }
        public StatusConvite StatusConvite { get; set; }
        public DateTime DataHoraAcao { get; set; }
        public int QuantidadeAceites { get; set; }

        public int BancaId { get; set; }
        public Banca Banca { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int QtdPrimeiroDia { get; set; }
        public int QtdSegundoDia { get; set; }
        public int QtdTerceiroDia { get; set; }
    }
}
