using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadoDocente
    {
        public Int32 Id { get; set; }
        public bool Turno { get; set; }
        public Int32 HoraIni { get; set; }
        public Int32 HoraFin { get; set; }
        public bool Estado { get; set; }

        public Persona Persona { get; set; }
        public Int32 PersonaFk { get; set; }

        public Horario Horario { get; set; }
        public Int32 HorarioFk { get; set; }
    }
}
