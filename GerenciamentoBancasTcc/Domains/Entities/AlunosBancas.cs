namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class AlunosBancas
    {
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int BancaId { get; set; }
        public Banca Banca { get; set; }
    }
}
