using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAcademia
{
    public class DiaTreino
    {
        public string Dia { get; set; }
        public IList<HorarioTreino> HorariosDoDia { get; set; }
    }
}
