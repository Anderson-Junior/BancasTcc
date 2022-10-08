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
        [Required(ErrorMessage = "É necessário informar a data e a hora.")]
        public DateTime? DataHora { get; set; }

        [Required(ErrorMessage = "É necessário informar a sala.")]
        public int Sala { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public ICollection<Arquivo> Arquivos { get; set; }

        public ICollection<UsuarioBanca> UsuariosBancas { get; set; }
        public ICollection<Convite> Convites { get; set; }

        //public ICollection<DiaDisponivel> DiasDisponiveis { get; set; }


        public DateTime PrimeiroDia { get; set; }
        public DateTime SegundoDia { get; set; }
        public DateTime TerceiroDia { get; set; }

        public bool PrimeiroHorario { get; set; }
        public bool SegundoHorario { get; set; }
        public bool TerceiroHorario { get; set; }

        public int QtdProfBanca { get; set; }
    }
}
