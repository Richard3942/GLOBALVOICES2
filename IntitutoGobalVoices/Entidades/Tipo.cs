using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tipo
    {
        public Int32 Id { get; set; }
        public String Ocupacion { get; set; }
        public String Descripcion { get; set; }
        public List<Persona> Personas { get; set; }
    }
}
