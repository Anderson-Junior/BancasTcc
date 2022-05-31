using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Formulario
    {
        public int FormularioId { get; set; }
        public string Nome { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Display(Name = "Curso")]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public ICollection<Questao> Questoes { get; set; }
    }
}
