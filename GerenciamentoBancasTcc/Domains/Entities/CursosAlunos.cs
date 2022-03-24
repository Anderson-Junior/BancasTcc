namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class CursosAlunos
    {
        public int CursoId { get; set; }
        public Curso Cursos { get; set; }

        public int  AlunoId { get; set; }
        public Aluno Alunos { get; set; }
    }
}
