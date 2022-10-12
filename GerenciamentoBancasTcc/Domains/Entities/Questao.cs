using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    [Table("Questoes")]
    public class Questao
    {
        public int QuestaoId { get; set; }

        [Required(ErrorMessage = "É necessário informar a pergunta.")]
        public string Pergunta { get; set; }

        [Required(ErrorMessage = "É necessário selecionar o tipo da pergunta.")]
        public int TipoQuestaoId { get; set; }

        [Display(Name = "Tipo da questão")]
        public TipoQuestao TipoQuestao { get; set; }

        public int? FormularioId { get; set; }
        public Formulario Formulario { get; set; }
    }
}
