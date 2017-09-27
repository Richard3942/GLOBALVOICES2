using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Asistencia
    {
        public Int32 Id { get; set; }
        public Matricula Matricula { get; set; }
        public Int32 MatriculaFk { get; set; }
        public bool Asistio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
