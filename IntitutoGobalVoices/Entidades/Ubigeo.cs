using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ubigeo
    {
        public Int32 Id { get; set; }
        public String Pais { get; set; }
        public String Ciudad { get; set; }

        public List<Persona> Personas { get; set; }
    }
}
