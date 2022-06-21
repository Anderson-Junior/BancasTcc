using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Curso
    {
        [Key]
        [Column("CursoId")]
        public int CursoId { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "É necessário preencher o nome do curso.")]
        public string Nome { get; set; }

        [Column("Periodos")]
        [Required(ErrorMessage = "É necessário informar a quantidade de períodos do curso.")]
        public int Periodos { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Display(Name = "Filial")]
        [Required(ErrorMessage = "É necessário selecionar de qual filial o curso faz parte.")]
        public int FilialId { get; set; }
        public virtual Filial Filial { get; set; }
        public ICollection<Turma> Turmas { get; set; }
        public ICollection<Formulario> Formularios { get; set; }
    }
}
