using GerenciamentoBancasTcc.Domains.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoBancasTcc.Models
{
    public class ConviteViewModel
    {
        public Guid ConviteId { get; set; }

        [Display(Name = "Status")]
        public StatusConvite StatusConvite { get; set; }

        public string Turma { get; set; }

        public string Tema { get; set; }

        public string Curso { get; set; }

        public string Orientador { get; set; }

        public IList<string> Alunos { get; set; }

        public IList<DateTime> BancaPossiveisDataHora { get; set; }

        public IList<DateTime> ConviteAceites { get; set; }
    }
}
