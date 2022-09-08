using GerenciamentoBancasTcc.Domains.Enums;
using System;
using System.Collections.Generic;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class DiasDisponiveis
    {
        public int DiasDisponiveisId { get; set; }
        public DiaDaSemana DiaDisponivel { get; set; }

        //public List<Horario> HorariosDisponiveis { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }

    //public class Horario
    //{
    //    public DateTime HoraInicio { get; set; }
    //    public DateTime HoraFim { get; set; }
    //}
}
