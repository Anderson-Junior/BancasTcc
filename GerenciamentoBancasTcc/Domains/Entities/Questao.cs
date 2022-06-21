using System.ComponentModel.DataAnnotations;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Questao
    {
        public int QuestaoId { get; set; }

        [Required(ErrorMessage = "É necessário informar a pergunta.")]
        public string Pergunta { get; set; }

        [Required(ErrorMessage = "É necessário selecionar o tipo da pergunta.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "É necessário informar a ordem da pergunta.")]
        public int OrdemPergunta { get; set; }

        public int FormularioId { get; set; }
        public Formulario Formulario { get; set; }
    }
}
