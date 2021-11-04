using System;
using System.Collections.Generic;

namespace AgendaAcademia
{
    public class HorarioTreino
    {
        public int HoraInicio { get; set; }
        public int HoraFim { get; set; }
        public IList<string> CpfsAlunosAgendados { get; set; }
    }
}
