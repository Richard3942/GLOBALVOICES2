using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Nota
    {
        public Int32 Id { get; set; }
        public decimal Puntaje { get; set; }
        public String TipoNota { get; set; }
        public Matricula Matricula { get; set; }
        public Int32 MatriculaFk { get; set; }
    }
}
