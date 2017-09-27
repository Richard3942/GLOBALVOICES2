using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Horario
    {
        public Int32 Id { get; set; }
        public bool Turno { get; set; }
        public Int32 HoraIni { get; set; }
        public Int32 HoraFin { get; set; }
        public String Dias { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }

        public Ciclo Ciclo { get; set; }
        public Int32 CicloFk { get; set; }
        public List<Matricula> Matriculas { get; set; }
    }
}
