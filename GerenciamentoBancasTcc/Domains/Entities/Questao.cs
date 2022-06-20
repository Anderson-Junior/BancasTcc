namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Questao
    {
        public int QuestaoId { get; set; }
        public string Pergunta { get; set; }
        public string Tipo { get; set; }
        public int OrdemPergunta { get; set; }
        public int FormularioId { get; set; }
        public Formulario Formulario { get; set; }
    }
}
