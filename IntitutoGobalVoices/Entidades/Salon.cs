using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Salon
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int32 Capacidad { get; set; }
        public List<EstadoSalon> EstadoSalones { get; set; }
    }
}
