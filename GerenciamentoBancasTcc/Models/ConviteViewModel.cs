using GerenciamentoBancasTcc.Domains.Entities;
using GerenciamentoBancasTcc.Domains.Enums;
using System;
using System.Collections.Generic;

namespace GerenciamentoBancasTcc.Models
{
    public class ConviteViewModel
    {
        public Guid ConviteId { get; set; }

        public StatusConvite StatusConvite { get; set; }

        public DateTime DataHoraAcao { get; set; }

        public string Banca { get; set; }

        public string Professor { get; set; }

        public string Turma { get; set; }

        public string Tema { get; set; }

        public string Curso { get; set; }

        public string Orientador { get; set; }

        public int Sala { get; set; }

        public List<Aluno> Alunos { get; set; }
    }
}
