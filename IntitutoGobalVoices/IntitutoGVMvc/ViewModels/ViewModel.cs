using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;

namespace IntitutoGVMvc.ViewModels
{
    public class MatriculaViewModel
    {

            //otros accion
            public String Action { get; set; }
            public String NroVoucher { get; set; }
            public String TipoMatricula { get; set; }

            public String NroDocumento { get; set; }
            public String NombresCompletos { get; set; }

            public Int32 PersonaSeleccionadaId { get; set; }
            public Int32 NivelSeleccionadoId { get; set; }
            public Int32 CicloSeleccionadoId { get; set; }
            public bool TurnoSeleccionadoId { get; set; }
            public Int32 HorarioSeleccionadoId { get; set; }

            //public EstudianteViewModel EstudianteViewModel { get; set; }



        //ESTUDIANTE
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
            public Int32 UbigeoFk { get; set; }
    }

    //public class EstudianteViewModel
    //{
    //    public Int32 Id { get; set; }
    //    public String Nombres { get; set; }
    //    public String ApellidoPaterno { get; set; }
    //    public String ApellidoMaterno { get; set; }
    //    public String NroDocumento { get; set; }
    //    public String Direccion { get; set; }
    //    public String Celular { get; set; }
    //    public String Telefono { get; set; }
    //    public String Email { get; set; }
    //    public DateTime FechaNacimiento { get; set; }
    //    public bool Genero { get; set; }
    //    public bool EstadoElim { get; set; }

    //    public Int32 TipoFk { get; set; }
    //    public Int32 UbigeoFk { get; set; }
 
    //}
}