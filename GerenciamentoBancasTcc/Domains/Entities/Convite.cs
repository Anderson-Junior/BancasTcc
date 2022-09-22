namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Convite
    {
        public int ConviteId { get; set; }
        public string Descrição { get; set; }
        public bool Aceito { get; set; }

        public int BancaId { get; set; }
        public Banca Banca { get; set; }

        public string CoordenadorId { get; set; }
        public Usuario Coordenador { get; set; }

        public string ProfessorId { get; set; }
        public Usuario Professor { get; set; }
    }
}
