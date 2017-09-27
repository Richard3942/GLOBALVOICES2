using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MatriculaDto
    {
        public Int32 Id { get; set; }

        public DateTime FechaMatricula { get; set; }

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

        public int IdHorario { get; set; }
        public bool Turno { get; set; }
        public Int32 HoraIni { get; set; }
        public Int32 HoraFin { get; set; }
        public String Dias { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
      

        public Int32 IdNivel { get; set; }
        public String NombreN { get; set; }
       

        public Int32 IdCiclo { get; set; }
        public String NombreC { get; set; }


        public Int32 IdSalon { get; set; }
        public String NombreS { get; set; }
        public Int32 Capacidad { get; set; }



    }
}
