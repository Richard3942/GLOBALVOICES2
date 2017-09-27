using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadoSalon
    {
        public Int32 Id { get; set; }
        public int NroMatriculados { get; set; }
        public bool Turno { get; set; }//////////////////////////////////////////////////////
        public Int32 HoraIni { get; set; }
        public Int32 HoraFin { get; set; }
        public bool Estado { get; set; }

        public Horario Horario { get; set; }
        public Int32 HorarioFk { get; set; }

        public Salon Salon { get; set; }
        public Int32 SalonFk { get; set; }

    }
}
