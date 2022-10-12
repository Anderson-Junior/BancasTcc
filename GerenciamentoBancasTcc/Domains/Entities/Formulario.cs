using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Formulario
    {
        public int FormularioId { get; set; }

        [Required(ErrorMessage = "É necessário informar um nome para o formulário.")]
        public string Nome { get; set; }
        public string UsuarioId { get; set; }
        [Display(Name = "Professor")]
        public Usuario Usuario { get; set; }

        [Display(Name = "Curso")]
        [Required(ErrorMessage = "É necessário selecionar um curso.")]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public ICollection<Questao> Questoes { get; set; }
    }
}
