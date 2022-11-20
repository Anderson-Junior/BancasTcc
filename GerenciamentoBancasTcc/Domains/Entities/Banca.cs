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
        [Required(ErrorMessage = "É necessário selecionar a turma.")]
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public ICollection<AlunosBancas> AlunosBancas { get; set; }

        [Required(ErrorMessage = "É necessário preencher o tema da banca.")]
        public string Tema { get; set; }

        [Display(Name = "Orientador")]
        [Required(ErrorMessage = "É necessário selecionar o orientador.")]
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Display(Name = "Data/Hora")]
        public DateTime? DataHora { get; set; }

        [Display(Name = "Quantidade de professores")]
        [Required(ErrorMessage = "É necessário informar quantos professores participarão da banca.")]
        public int QtdProfBanca { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public ICollection<Arquivo> Arquivos { get; set; }

        public ICollection<UsuarioBanca> UsuariosBancas { get; set; }
        public ICollection<Convite> Convites { get; set; }
        public ICollection<BancaPossivelDataHora> BancaPossiveisDataHora { get; set; }
    }
}
