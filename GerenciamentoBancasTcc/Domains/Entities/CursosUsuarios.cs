namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class CursosUsuarios
    {
        public int CursoId { get; set; }
        public Curso Cursos { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuarios { get; set; }
    }
}
