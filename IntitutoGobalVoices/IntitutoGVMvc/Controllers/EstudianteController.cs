using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Interfaces;
using IntitutoGVMvc.ViewModels;
using Microsoft.Practices.Unity;
using System.Text.RegularExpressions;

namespace IntitutoGVMvc.Controllers
{
    public class EstudianteController : Controller
    {
        [Dependency]
        public IPersona personaService { get; set; }
        [Dependency]
        public IMatricula matriculaService { get; set; }
        [Dependency]
        public IUbigeo ubigeoService { get; set; }

        [Authorize]
        public ViewResult Listar(string criterioBusqueda, int page = 1)
        {
            ViewBag.Paisess = ubigeoService.ObtenerTodosPaises();
            var estudiantes = personaService.ObtenerPersonas(criterioBusqueda, page);

            ViewBag.NroRegistros = personaService.ObtenerNroRegistros();
            ViewBag.page = page;
            return View("ListarEstudiante", estudiantes);
           
        }
        [Authorize]
        public ViewResult Crear()
        {
            ViewBag.Paisess = ubigeoService.ObtenerTodosPaises();
            return View("Crear", new PersonaViewModel());
        }
        [Authorize]
        public ViewResult Editar(int id)
        {
            ViewBag.Paisess = ubigeoService.ObtenerTodosPaises();
            var persona = personaService.ObtenerPersonaById(id);
            var personaViewModel = new PersonaViewModel()
            {
                ModId = id,
                Action = "",
                ModApellidoPaterno = persona.ApellidoPaterno,
                ModApellidoMaterno = persona.ApellidoMaterno,
                ModCelular = persona.Celular,
                ModCiudad = persona.Ubigeo.Ciudad,
                ModDireccion = persona.Direccion,
                ModEmail = persona.Email,
                ModFechaNacimiento = persona.FechaNacimiento,
                ModGenero = persona.Genero,
                ModNombres = persona.Nombres,
                ModNroDocumento = persona.NroDocumento,
                ModPaisSeleccionado = persona.Ubigeo.Pais,
                ModTelefono = persona.Telefono,
                ModUbigeoFk = persona.Ubigeo.Id
            };
          
            return View("Editar", personaViewModel);
        }
        [Authorize]
        public ViewResult Detalle(int id)
        {
            var persona = personaService.ObtenerPersonaById(id);
            var personaViewModel = new PersonaViewModel()
            {
                ModId = id,
                Action = "",
                ModApellidoPaterno = persona.ApellidoPaterno,
                ModApellidoMaterno = persona.ApellidoMaterno,
                ModCelular = persona.Celular,
                ModCiudad = persona.Ubigeo.Ciudad,
                ModDireccion = persona.Direccion,
                ModEmail = persona.Email,
                ModFechaNacimiento = persona.FechaNacimiento,
                ModGenero = persona.Genero,
                ModNombres = persona.Nombres,
                ModNroDocumento = persona.NroDocumento,
                ModPaisSeleccionado = persona.Ubigeo.Pais,
                ModTelefono = persona.Telefono,
                ModUbigeoFk = persona.Ubigeo.Id

            };
            return View("Detalle", personaViewModel);
        }
        [Authorize]
        public RedirectToRouteResult Eliminar(int id)//debe eliminar  en caso el estudiante no este matriculado                              
        {
            ViewBag.NroRegistros = personaService.ObtenerNroRegistros();
            ViewBag.page = 1;
            if (!matriculaService.EstaMatriculado(id))
            {
                personaService.EliminarPersona(id);
                TempData["msjEstudianteHaSidoEliminado"] = "ACTIVAR";
            }
            else
            {
                TempData["msjEstudianteEstaMatriculado"] = "ACTIVAR";
            }
            ViewBag.Paisess = ubigeoService.ObtenerTodosPaises();
           // var estudiantes = personaService.ObtenerPersonas("");
            //Redirect("/HOME/index");
            return RedirectToAction("Listar");
            //return View("ListarEstudiante", estudiantes);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Guardar(PersonaViewModel personaViewModel)//un mismo estudiante no puede estar registrado dos o mas veces
        {
            ViewBag.NroRegistros = personaService.ObtenerNroRegistros();
            ViewBag.page = 1;
            
            if (personaViewModel.Action == "GuardarEstudiante")
            {
                EjecutarValidacionesRegistrarPersonaViewModel(personaViewModel);////////////////////////////////////////////////////////////////////////
                if (ModelState.IsValid)
                {
                    var ubigeo = new Ubigeo()
                    {
                        Pais = personaViewModel.ModPaisSeleccionado,
                        Ciudad = personaViewModel.ModCiudad
                    };
                    ubigeoService.RegistrarUbigeo(ubigeo);
                   // var ubigeoRegistrado = ubigeoService.ObtenerUbigeoById(ubigeo.Id);

                    var estudiante = new Persona()
                    {
                        Nombres = personaViewModel.ModNombres,
                        ApellidoPaterno = personaViewModel.ModApellidoPaterno,
                        ApellidoMaterno = personaViewModel.ModApellidoMaterno,
                        NroDocumento = personaViewModel.ModNroDocumento,
                        Direccion = personaViewModel.ModDireccion,
                        Celular = personaViewModel.ModCelular,
                        Telefono = personaViewModel.ModTelefono,
                        Email = personaViewModel.ModEmail,
                        FechaNacimiento = personaViewModel.ModFechaNacimiento,
                        Genero = personaViewModel.ModGenero,
                        EstadoElim = false,
                        TipoFk = 1,
                        UbigeoFk = ubigeo.Id
                    };
                    personaService.RegistrarPersona(estudiante);
                    TempData["msjeGuardoConExito"] = "ACTIVAR";



                  //  var estudiantes = personaService.ObtenerPersonas("");
                    return RedirectToAction("Listar");
                    //return View("ListarEstudiante", estudiantes);


                   

                }
                else
                {
                    ViewBag.Paisess = ubigeoService.ObtenerTodosPaises();

                    
                   return View("Crear", personaViewModel);
                }
            }
            if (personaViewModel.Action == "EditarEstudiante")
            {
                EjecutarValidacionesEditarPersonaViewModel(personaViewModel);
                if (ModelState.IsValid)
                {

                var ubigeo = new Ubigeo()
                {
                    Id = personaViewModel.ModUbigeoFk,
                    Pais = personaViewModel.ModPaisSeleccionado,
                    Ciudad = personaViewModel.ModCiudad
                };

                var estudiante = new Persona()
                {
                    Id = personaViewModel.ModId,
                    Nombres = personaViewModel.ModNombres,
                    ApellidoPaterno = personaViewModel.ModApellidoPaterno,
                    ApellidoMaterno = personaViewModel.ModApellidoMaterno,
                    NroDocumento = personaViewModel.ModNroDocumento,
                    Direccion = personaViewModel.ModDireccion,
                    Celular = personaViewModel.ModCelular,
                    Telefono = personaViewModel.ModTelefono,
                    Email = personaViewModel.ModEmail,
                    FechaNacimiento = personaViewModel.ModFechaNacimiento,
                    Genero = personaViewModel.ModGenero,
                    EstadoElim = false,
                    TipoFk = 1,
                    Ubigeo = ubigeo,
                    UbigeoFk = personaViewModel.ModUbigeoFk
                };
                personaService.UpdatePersona(estudiante);
                TempData["msjeGuardoConExito"] = "ACTIVAR";


                //var estudiantes = personaService.ObtenerPersonas("");


                return RedirectToAction("Listar");
                //return View("ListarEstudiante", estudiantes);
                }
                else
                {
                    var personaViewModel2 = personaViewModel;
                    ViewBag.Paisess = ubigeoService.ObtenerTodosPaises();/////////////////////
                    //return RedirectToAction("Editar", new { });
                     return View("Editar", personaViewModel);
                }

            }
            
           // var estudiantess = personaService.ObtenerPersonas("",0);
            return RedirectToAction("Listar");
            //return View("ListarEstudiante",estudiantess);

        }

        

        private void EjecutarValidacionesRegistrarPersonaViewModel(PersonaViewModel personaViewModel)
        {
            if (!string.IsNullOrEmpty(personaViewModel.ModNroDocumento))
            {   
                var personaAGuardar = personaService.ObtenerPersonaProNroDoc(personaViewModel.ModNroDocumento);
                if (personaAGuardar != null)
                {
                    TempData["msjeDNIYaExiste"] = "ACTIVAR";
                    ModelState.AddModelError("ModNroDocumento", "Nro Documento ya existe");
                }
            }
            if (string.IsNullOrEmpty(personaViewModel.ModFechaNacimiento.ToString()))
            {
                ModelState.AddModelError("ModFechaNacimiento", "Fecha de nacimiento  es obligatorio");
            }

            if (personaViewModel.ModFechaNacimiento.ToString() == "01/01/0001 0:00:00")
            {
            ModelState.AddModelError("ModFechaNacimiento", "Fecha de nacimiento  es obligatorio");
               TempData["msjeDNIYaExiste"] = "ACTIVAR";
            }

            var fechaInput = personaViewModel.ModFechaNacimiento;
            if (fechaInput > DateTime.Now ||
                fechaInput.Year == DateTime.Now.Year && fechaInput.Month == DateTime.Now.Month &&
                fechaInput.Day == DateTime.Now.Day)
            {
                TempData["msjeDNIYaExiste"] = "ACTIVAR";
                ModelState.AddModelError("ModFechaNacimiento", "Fecha no puede ser mayor o igual a la fecha de hoy");
            }else
            {
                var r = DateTime.Now.Year - personaViewModel.ModFechaNacimiento.Year;
                if (r == 0)
                {
                    TempData["msjeDNIYaExiste"] = "ACTIVAR";
                    ModelState.AddModelError("ModFechaNacimiento", "Debe tener como minimo 7 años");
                }
                else 
                {
                    if (r < 7)
                    {
                        //ModelState.AddModelError("ModFechaNacimiento", "Debe tener como minimo 7 años, tiene: " + r);
                        ModelState.AddModelError("ModFechaNacimiento", "Debe tener como minimo 7 años");
                    }  
                }
                           
            }
          
        }

        private void EjecutarValidacionesEditarPersonaViewModel(PersonaViewModel personaViewModel)
        {

            if (string.IsNullOrEmpty(personaViewModel.ModFechaNacimiento.ToString()))
            {
                ModelState.AddModelError("ModFechaNacimiento", "Fecha de nacimiento  es obligatorio");
            }

            if (personaViewModel.ModFechaNacimiento.ToString() == "01/01/0001 0:00:00")
            {
                 ModelState.AddModelError("ModFechaNacimiento", "Fecha de nacimiento  es obligatorio");
                TempData["msjeDNIYaExiste"] = "ACTIVAR";
            }
          
            var fechaInput = personaViewModel.ModFechaNacimiento;
            if (fechaInput > DateTime.Now ||
                fechaInput.Year == DateTime.Now.Year && fechaInput.Month == DateTime.Now.Month &&
                fechaInput.Day == DateTime.Now.Day)
            {
                TempData["msjeDNIYaExiste"] = "ACTIVAR";
                ModelState.AddModelError("ModFechaNacimiento", "Fecha no puede ser mayor o igual a la fecha de hoy");
            }

            else
            {
                var r = DateTime.Now.Year - personaViewModel.ModFechaNacimiento.Year;
                if (r == 0)
                {
                    TempData["msjeDNIYaExiste"] = "ACTIVAR";
                    ModelState.AddModelError("ModFechaNacimiento", "Debe tener como minimo 7 años");
                }
                else
                {
                    if (r < 7)
                    {
                        //ModelState.AddModelError("ModFechaNacimiento", "Debe tener como minimo 7 años, tiene: " + r);
                        ModelState.AddModelError("ModFechaNacimiento", "Debe tener como minimo 7 años");
                    }
                }

            }
        }

    }


}
