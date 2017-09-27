using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HorarioDto
    {
        //idHorario
        public int Id { get; set; }
        public String Dias { get; set; }
        public int HoraIni { get; set; }
        public int HoraFin { get; set; }
        public String Salon { get; set; }

       
    }
}
