using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    [Table("DiaQueDeveOcorrerBanca")]
    public class DiaQueDeveOcorrerBanca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiaQueDeveOcorrerBancaId { get; set; }
        public DateTime PossivelDataHoraInicial { get; set; }

        public int BancaId { get; set; }
        public Banca Banca { get; set; }

        public Guid ConviteId { get; set; }
        public Convite Convite { get; set; }

        public int QtdAceites { get; set; }
    }
}
