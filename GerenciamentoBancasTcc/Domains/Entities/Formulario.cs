﻿using System.Collections.Generic;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Formulario
    {
        public int FormularioId { get; set; }
        public string Nome { get; set; }
        public string Questoes { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
