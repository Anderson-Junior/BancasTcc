namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class UsuarioBanca
    {
        public string UsuarioId { get; set; }
        public Usuario Usuarios { get; set; }

        public int BancaId { get; set; }
        public Banca Bancas { get; set; }
    }
}
