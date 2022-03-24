using GerenciamentoBancasTcc.Domains.Enums;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class DiasDisponiveis
    {
        public int DiasDisponiveisId { get; set; }
        public DiaDaSemana DiaDisponivel { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
