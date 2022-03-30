using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Banca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BancaId { get; set; }
        public DateTime Data { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public virtual List<Equipe> Equipes { get; set; }
        public ICollection<UsuarioBanca> UsuariosBancas { get; set; }
    }
}
