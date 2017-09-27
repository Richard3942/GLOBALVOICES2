using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntitutoGVMvc.ViewModels
{
    public class PersonaViewModel
    {
        public Int32 ModId { get; set; }
        public String ModNombres { get; set; }
        public String ModApellidoPaterno { get; set; }
        public String ModApellidoMaterno { get; set; }
        public String ModNroDocumento { get; set; }
        public String ModDireccion { get; set; }
        public String ModCelular { get; set; }
        public String ModTelefono { get; set; }
        public String ModEmail { get; set; }
        public DateTime ModFechaNacimiento { get; set; }
        public bool ModGenero { get; set; }
        //public bool ModEstadoElim { get; set; }

        public String ModPaisSeleccionado { get; set; }
        public String ModCiudad { get; set; }

        public Int32 TipoFk { get; set; }
        public Int32 ModUbigeoFk { get; set; }
        public string Action { get; set; }

        public string criterioBusqueda { get; set; }
    }
}