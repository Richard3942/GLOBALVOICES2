using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Matricula
    {
        public Int32 Id { get; set; }
        public String NroVoucher { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Int32 NroMatricula { get; set; }
        public String TipoMatricula { get; set; }
        public bool Estado { get; set; }

        public Horario Horario { get; set; }
        public Persona Persona { get; set; }
        public Int32 HorarioFk { get; set; }
        public Int32 PersonaFk { get; set; }

        public List<Asistencia> Asistencias { get; set; }
        public List<Nota> Notas { get; set; }
    }
}
