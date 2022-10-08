using GerenciamentoBancasTcc.Domains.Entities;
using System;
using System.Collections.Generic;

namespace GerenciamentoBancasTcc.Models
{
    public class BancaViewModel
    {
        public int BancaId { get; set; }

        public string Turma { get; set; }

        public string Tema { get; set; }

        public string Curso { get; set; }

        public string Orientador { get; set; }

        public int Sala { get; set; }

        public DateTime? DataHora { get; set; }

        public List<Aluno> Alunos { get; set; }

        public List<string> Professores { get; set; }

        public List<Arquivo> Arquivos { get; set; }
    }
}
