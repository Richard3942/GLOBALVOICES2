using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Ciclo
    {
       public Int32 Id { get; set; }
       public String Nombre { get; set; }
       public String Descripcion { get; set; }

       public Nivel Nivel { get; set; }
       public Int32 NivelFk { get; set; }
       public List<Horario> Horarios { get; set; }
    }
}
