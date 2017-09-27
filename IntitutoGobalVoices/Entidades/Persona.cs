using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        public Int32 Id { get; set; }
        public String Nombres { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String NroDocumento { get; set; }
        public String Direccion { get; set; }
        public String Celular { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Genero { get; set; }
        public bool EstadoElim { get; set; }


        

        public Tipo Tipo { get; set; }
        public Int32 TipoFk { get; set; }
        public Ubigeo Ubigeo { get; set; }
        public Int32 UbigeoFk { get; set; }
        public List<Matricula> Matriculas { get; set; }
        public List<EstadoDocente> EstadoDocentes { get; set; }
        
    }
}
