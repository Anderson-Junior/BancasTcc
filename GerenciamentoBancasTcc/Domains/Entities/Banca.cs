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

        [Display(Name = "Turma")]
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }

        public ICollection<AlunosBancas> AlunosBancas { get; set; }

        public string Tema { get; set; }

        [Display(Name = "Orientador")]
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Display(Name = "Data/Hora")]
        public DateTime DataHora { get; set; }

        public int Sala { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public ICollection<UsuarioBanca> UsuariosBancas { get; set; }
    }
}
