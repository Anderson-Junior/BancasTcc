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

        [Display(Name = "Status")]
        public StatusConvite StatusConvite { get; set; }

        [Display(Name = "Data/Hora")]
        public DateTime DataHoraAcao { get; set; }

        [Display(Name = "Número de aceites")]
        public int QuantidadeAceites { get; set; }
        public string DiaConvite { get; set; }
        public int BancaId { get; set; }
        public Banca Banca { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int QtdPrimeiroDia { get; set; }
        public int QtdSegundoDia { get; set; }
        public int QtdTerceiroDia { get; set; }
    }
}
