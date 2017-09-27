using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Interfaces;
using IntitutoGVMvc.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.Practices.Unity;
using Repository;


namespace IntitutoGVMvc.Controllers
{
    public class MatriculaController : Controller
    {
        [Dependency]
        public IPersona personaService { get; set; }
        [Dependency]
        public IMatricula matriculaService { get; set; }
        [Dependency]
        public INivel nivelService { get; set; }
        [Dependency]
        public ICiclo cicloService { get; set; }
        [Dependency]
        public IHorario horarioService { get; set; }
        [Dependency]
        public IUbigeo ubigeoService { get; set; }
        [Dependency]
        public ISalon salonService { get; set; }

        [Authorize]
        public ViewResult Listar(string criterio, int page =1)
        {
            var matriculas = matriculaService.ObtenerMatriculas(criterio,page);

            ViewBag.NroRegistros = matriculaService.ObtenerNroRegistros();
            ViewBag.page = page;

            return View("ListarMatricula", matriculas);
        }
        [Authorize]
        public ViewResult Crear()
        {
            var niveles = nivelService.ObtenerTodosNiveles();
            ViewBag.Niveless = niveles;
            ViewBag.Paisess = ubigeoService.ObtenerTodosPaises();
            return View("Crear",new MatriculaViewModel());
        }
        [Authorize]
        public ViewResult Detalle(int id)
        {
            var matricula = matriculaService.ObtenerMatriculaById(id);

            var matriculaViewModel = new MatriculaViewModel()
            {
                ModId = id,
                CicloSeleccionadoId = matricula.Horario.CicloFk,
                NroDocumento = matricula.Persona.NroDocumento,
                ModApellidoMaterno = matricula.Persona.ApellidoMaterno,
                ModApellidoPaterno = matricula.Persona.ApellidoPaterno,
                ModCelular = matricula.Persona.Celular,
                ModCiudad = matricula.Persona.Ubigeo.Ciudad,
                HorarioSeleccionadoId = matricula.HorarioFk,
                ModDireccion = matricula.Persona.Direccion,
                ModEmail = matricula.Persona.Email,
                ModFechaNacimiento = matricula.Persona.FechaNacimiento,
                ModGenero = matricula.Persona.Genero,
                ModNombres = matricula.Persona.Nombres,
                ModNroDocumento = matricula.Persona.NroDocumento,
                ModPaisSeleccionado = matricula.Persona.Ubigeo.Pais,
                ModTelefono = matricula.Persona.Telefono,
                NivelSeleccionadoId = matricula.Horario.Ciclo.NivelFk,
                NombresCompletos = matricula.Persona.Nombres + " " + matricula.Persona.ApellidoPaterno + " " + matricula.Persona.ApellidoMaterno,
                NroVoucher = matricula.NroVoucher,

                PersonaSeleccionadaId = matricula.PersonaFk,
                TipoMatricula = matricula.TipoMatricula,
                TipoFk = 1,
                TurnoSeleccionadoId = matricula.Horario.Turno,
                UbigeoFk = matricula.Persona.UbigeoFk,
            };

            ViewBag.Niveless = nivelService.ObtenerTodosNiveles();
            ViewBag.cicloss = cicloService.ObtenerCiclosPorNivelId(matriculaViewModel.NivelSeleccionadoId);
            ViewBag.Horarioss =
            horarioService.ObtenerHorariosPorCicloIdAndTurno(matriculaViewModel.CicloSeleccionadoId,
                matriculaViewModel.TurnoSeleccionadoId);


            return View("Detalle", matriculaViewModel);
        }
        [Authorize]
        public ViewResult Editar(int id)
        {
            ViewBag.Paisess = ubigeoService.ObtenerTodosPaises();
            var matricula = matriculaService.ObtenerMatriculaById(id);

            var matriculaViewModel = new MatriculaViewModel()
            {
                ModId = id,
                CicloSeleccionadoId = matricula.Horario.CicloFk,
                NroDocumento = matricula.Persona.NroDocumento,
                ModApellidoMaterno = matricula.Persona.ApellidoMaterno,
                ModApellidoPaterno = matricula.Persona.ApellidoPaterno,
                ModCelular = matricula.Persona.Celular,
                ModCiudad = matricula.Persona.Ubigeo.Ciudad,
                HorarioSeleccionadoId = matricula.HorarioFk,
                ModDireccion = matricula.Persona.Direccion,
                ModEmail = matricula.Persona.Email,
                ModFechaNacimiento = matricula.Persona.FechaNacimiento,
                ModGenero = matricula.Persona.Genero,
                ModNombres = matricula.Persona.Nombres,
                ModNroDocumento = matricula.Persona.NroDocumento,
                ModPaisSeleccionado =matricula.Persona.Ubigeo.Pais,
                ModTelefono = matricula.Persona.Telefono,
                NivelSeleccionadoId = matricula.Horario.Ciclo.NivelFk,
                NombresCompletos = matricula.Persona.Nombres + " " + matricula.Persona.ApellidoPaterno + " " + matricula.Persona.ApellidoMaterno,
                NroVoucher = matricula.NroVoucher,
                
                PersonaSeleccionadaId = matricula.PersonaFk,
                TipoMatricula = matricula.TipoMatricula,
                TipoFk = 1,
                TurnoSeleccionadoId = matricula.Horario.Turno,
                UbigeoFk = matricula.Persona.UbigeoFk,
            };

            ViewBag.Niveless = nivelService.ObtenerTodosNiveles();
            ViewBag.cicloss = cicloService.ObtenerCiclosPorNivelId(matriculaViewModel.NivelSeleccionadoId);
            ViewBag.Horarioss =
            horarioService.ObtenerHorariosPorCicloIdAndTurno(matriculaViewModel.CicloSeleccionadoId,
                matriculaViewModel.TurnoSeleccionadoId);  
            return View("Editar", matriculaViewModel);
        }

        public void CargarCombos(MatriculaViewModel matriculaViewModel)
        {
            ViewBag.Niveless = nivelService.ObtenerTodosNiveles();
            ViewBag.Paisess = ubigeoService.ObtenerTodosPaises();
            ViewBag.cicloss = cicloService.ObtenerCiclosPorNivelId(matriculaViewModel.NivelSeleccionadoId);
            ViewBag.Horarioss =
                horarioService.ObtenerHorariosPorCicloIdAndTurno(matriculaViewModel.CicloSeleccionadoId,
                    matriculaViewModel.TurnoSeleccionadoId);
        }

        public void RegistrarNuevoEstudiante(MatriculaViewModel matriculaViewModel)
        {
            var ubigeo = new Ubigeo()
            {
                Pais = matriculaViewModel.ModPaisSeleccionado,
                Ciudad = matriculaViewModel.ModCiudad
            };
            ubigeoService.RegistrarUbigeo(ubigeo);
            //var ubigeoRegistrado = ubigeoService.ObtenerUbigeoById(ubigeo.Id);
            var estudiante = new Persona()
            {
                Nombres = matriculaViewModel.ModNombres,
                ApellidoPaterno = matriculaViewModel.ModApellidoPaterno,
                ApellidoMaterno = matriculaViewModel.ModApellidoMaterno,
                NroDocumento = matriculaViewModel.ModNroDocumento,
                Direccion = matriculaViewModel.ModDireccion,
                Celular = matriculaViewModel.ModCelular,
                Telefono = matriculaViewModel.ModTelefono,
                Email = matriculaViewModel.ModEmail,
                FechaNacimiento = matriculaViewModel.ModFechaNacimiento,
                //Genero = matriculaViewModel.ModGenero,
                EstadoElim = false,
                TipoFk = 1,
                UbigeoFk = ubigeo.Id
            };
            personaService.RegistrarPersona(estudiante);
           // Persona estudianteRegistrado = personaService.ObtenerPersonaById(estudiante.Id);
            var matricula = new Matricula()
            {
                NroVoucher = matriculaViewModel.NroVoucher,
                FechaRegistro = DateTime.Now,
                NroMatricula = 1,
                TipoMatricula = matriculaViewModel.TipoMatricula,
                Estado = false,
                HorarioFk = matriculaViewModel.HorarioSeleccionadoId,
                // Horario = horario,
                PersonaFk = estudiante.Id
                // Persona = persona
            };

            //verificamos que haya espacio en el salon
            var estadoSalon = salonService.ObtenerEstadoSalonByHorarioId(matricula.HorarioFk);
            if (estadoSalon.Salon.Capacidad - estadoSalon.NroMatriculados > 0)
            {
                matriculaService.RegistrarMatricula(matricula);/////////////////////////////////
                estadoSalon.NroMatriculados += 1;
                salonService.ActualizarEstadoSalon(estadoSalon);
                TempData["msjeGuardoConExito"] = "ACTIVAR";

            }
            else
            {
                TempData["msjeSalonLleno"] = "ACTIVAR";
               // RedirectToAction("Listar");

            }
           
            



        }

        public void RegistrarMatriculaEstudianteExiste(MatriculaViewModel matriculaViewModel)
        {
            var matricula = new Matricula()
            {
                NroVoucher = matriculaViewModel.NroVoucher,
                FechaRegistro = DateTime.Now,
                NroMatricula = 1,
                TipoMatricula = matriculaViewModel.TipoMatricula,
                Estado = false,
                HorarioFk = matriculaViewModel.HorarioSeleccionadoId,
                // Horario = horario,
                PersonaFk = matriculaViewModel.PersonaSeleccionadaId,
                // Persona = persona
            };
          

            //verificamos que haya espacio en el salon
            var estadoSalon = salonService.ObtenerEstadoSalonByHorarioId(matricula.HorarioFk);
            if (estadoSalon.Salon.Capacidad - estadoSalon.NroMatriculados > 0)
            {
                matriculaService.RegistrarMatricula(matricula);/////////////////////////////////
                TempData["msjeGuardoConExito"] = "ACTIVAR";
                estadoSalon.NroMatriculados += 1;
                salonService.ActualizarEstadoSalon(estadoSalon);

            }
             else
                {
                    TempData["msjeSalonLleno"] = "ACTIVAR";
                    //MSJE NO HAY MAS ESPACIO EN ESTE SALÓN
                    //RedirectToAction("Crear",matriculaViewModel);
                }
            



        }

        public void EditarMatricula(MatriculaViewModel matriculaViewModel)
        {
            var ubigeo = new Ubigeo()
            {
                Id = matriculaViewModel.UbigeoFk,
                Pais = matriculaViewModel.ModPaisSeleccionado,
                Ciudad = matriculaViewModel.ModCiudad
            };

            var estudiante = new Persona()
            {
                Id = matriculaViewModel.PersonaSeleccionadaId,
                Nombres = matriculaViewModel.ModNombres,
                ApellidoPaterno = matriculaViewModel.ModApellidoPaterno,
                ApellidoMaterno = matriculaViewModel.ModApellidoMaterno,
                NroDocumento = matriculaViewModel.ModNroDocumento,
                Direccion = matriculaViewModel.ModDireccion,
                Celular = matriculaViewModel.ModCelular,
                Telefono = matriculaViewModel.ModTelefono,
                Email = matriculaViewModel.ModEmail,
                FechaNacimiento = matriculaViewModel.ModFechaNacimiento,
                Genero = matriculaViewModel.ModGenero,
                EstadoElim = false,
                TipoFk = 1,
                UbigeoFk = ubigeo.Id,
                Ubigeo = ubigeo,
            };
            var matricula = new Matricula()
            {
                Id = matriculaViewModel.ModId,
                NroVoucher = matriculaViewModel.NroVoucher,
                FechaRegistro = DateTime.Now,
                NroMatricula = 1,
                TipoMatricula = matriculaViewModel.TipoMatricula,
                Estado = false,
                HorarioFk = matriculaViewModel.HorarioSeleccionadoId,
                PersonaFk = estudiante.Id,
                Persona = estudiante,
            };

            //matriculaService.UpdateMatricula(matricula);/////////////////

            var MatriculaEnElQueEstaMatriculado = matriculaService.ObtenerSoloMatriculaById(matriculaViewModel.ModId);

            if (MatriculaEnElQueEstaMatriculado != null)
            {
                if (matricula.HorarioFk != MatriculaEnElQueEstaMatriculado.HorarioFk) //  ESTA CAMBIADO DE HORARIO?
                {
                    var estadoSalonEnElQueEstaMatriculado = salonService.ObtenerEstadoSalonByHorarioId(MatriculaEnElQueEstaMatriculado.HorarioFk);
                    var estadoSalonAlQueSeQuiereRegistrar = salonService.ObtenerEstadoSalonByHorarioId(matricula.HorarioFk);

                    if (estadoSalonAlQueSeQuiereRegistrar.Salon.Capacidad -
                        estadoSalonAlQueSeQuiereRegistrar.NroMatriculados > 0) //hay espacio en el nuevo salon?
                    {
                        //entonces lo registramos y agregamos uno al nroMatriculados
                        matriculaService.UpdateMatricula(matricula);
                        TempData["msjeGuardoConExito"] = "ACTIVAR";     
                        estadoSalonAlQueSeQuiereRegistrar.NroMatriculados += 1;
                        salonService.ActualizarEstadoSalon(estadoSalonAlQueSeQuiereRegistrar);

                        //DISMINUIMOS UNO AL ANTIGUO ESTADO SALON 
                        estadoSalonEnElQueEstaMatriculado.NroMatriculados -= 1;
                        salonService.ActualizarEstadoSalon(estadoSalonEnElQueEstaMatriculado);
                    }
                    else
                    {
                        //MSJE NO HAY MAS ESPACIO EN ESTE SALÓN
                        TempData["msjeSalonLleno"] = "ACTIVAR";
                    }
                }
                else
                {
                    
                    matriculaService.UpdateMatricula(matricula);
                    TempData["msjeGuardoConExito"] = "ACTIVAR";     
                }
            }


            



        }
        [Authorize]
        [HttpPost]
        public ActionResult GuardarEditar(MatriculaViewModel matriculaViewModel)
        {
            ModelState.Clear();
            EjecutarValidacionesEditarMatriculaViewModel(matriculaViewModel);
          
                CargarCombos(matriculaViewModel);
                ViewBag.NroRegistros = matriculaService.ObtenerNroRegistros();
                ViewBag.page = 1;
  
                if (matriculaViewModel.Action == "ParamBtnNivelChange")
                {
                    ViewBag.Horarioss = null;
                    return View("Editar", matriculaViewModel);
                }
                if (matriculaViewModel.Action == "ParamBtnCicloChange" ||
                    matriculaViewModel.Action == "ParamBtnHorarioChange" ||
                    matriculaViewModel.Action == "ParamBtnTurnoChange" ||
                    matriculaViewModel.Action == "ParamBtnHorarioChange")
                {
                    return View("Editar", matriculaViewModel);
                }

                if (matriculaViewModel.Action == "GuardarEstudiantEdit")
                {
                    ModelState.Clear();
                    EjecutarValidacionesEditarPersonaViewModel(matriculaViewModel);
                    if (ModelState.IsValid)
                    {
                        
                        matriculaViewModel.NroDocumento = matriculaViewModel.ModNroDocumento;
                        matriculaViewModel.NombresCompletos = matriculaViewModel.ModNombres + " " +
                                                          matriculaViewModel.ModApellidoPaterno + " " +
                                                          matriculaViewModel.ModApellidoMaterno;

                        var personaDB = personaService.ObtenerPersonaById(matriculaViewModel.PersonaSeleccionadaId);
                        
                        personaDB.Nombres = matriculaViewModel.ModNombres;
                        personaDB.ApellidoMaterno = matriculaViewModel.ModApellidoMaterno;
                        personaDB.ApellidoPaterno = matriculaViewModel.ModApellidoPaterno;
                        personaDB.Direccion = matriculaViewModel.ModDireccion;
                        personaDB.Telefono = matriculaViewModel.ModTelefono;
                        personaDB.Celular = matriculaViewModel.ModCelular;
                        personaDB.Email = matriculaViewModel.ModEmail;
                        personaDB.Ubigeo = null;
                        personaDB.FechaNacimiento = matriculaViewModel.ModFechaNacimiento;
                        personaDB.Genero = matriculaViewModel.ModGenero;

                        var ubigeoDB = ubigeoService.ObtenerUbigeoById(personaDB.UbigeoFk);
                        ubigeoDB.Ciudad = matriculaViewModel.ModCiudad;
                        ubigeoDB.Pais = matriculaViewModel.ModPaisSeleccionado;

                        personaService.UpdatePersona(personaDB);
                        ubigeoService.UpdateUbigeo(ubigeoDB);
                        

                    }
          

                    return View("Editar", matriculaViewModel);
                }

                if (matriculaViewModel.Action == "EditarMatricula")
                {
                    ModelState.Clear();
                    EjecutarValidacionesEditarMatriculaViewModel(matriculaViewModel);
                    if (ModelState.IsValid)
                    {
                        EditarMatricula(matriculaViewModel);
                                 
                    }
                    else
                    {
                        TempData["msjeError"] = "ACTIVAR";
                        return View("Editar", matriculaViewModel);
                        
                    }



                    return RedirectToAction("Listar");
                    //var matriculas = matriculaService.ObtenerMatriculas("");
                    //return View("ListarMatricula", matriculas);
                }
              
              return null;
        }
        [Authorize]
        [HttpPost]
        public ActionResult Guardar(MatriculaViewModel matriculaViewModel)
        {
            EjecutarValidacionesRegistrarMatriculaViewModel(matriculaViewModel);
            CargarCombos(matriculaViewModel);
            if (matriculaViewModel.Action == "ParamBtnNivelChange")
            {
                ViewBag.Horarioss = null;
                return View("Crear", matriculaViewModel);
            }

            if ( matriculaViewModel.Action == "ParamBtnCicloChange" ||matriculaViewModel.Action == "ParamBtnHorarioChange" ||
                matriculaViewModel.Action == "ParamBtnTurnoChange") 
            {
                return View("Crear", matriculaViewModel);
            }
            if (matriculaViewModel.Action == "BuscarEstudiantePorNroDoc")
            {
                var persona = personaService.ObtenerPersonaProNroDoc(matriculaViewModel.NroDocumento);
                if (persona!=null)//verdado en caso existe el estudiante //y nombres completos esta lleno
                {
                   
                    matriculaViewModel.NombresCompletos = persona.Nombres + " " + persona.ApellidoPaterno + " " +
                                                          persona.ApellidoMaterno;
                    matriculaViewModel.PersonaSeleccionadaId = persona.Id;
                }
                else
                {
                    TempData["msjeErrorValidacion"] = "ACTIVAR";//Ingrese un número de documento válido y de click en buscar
                    matriculaViewModel.NombresCompletos = "";
                    matriculaViewModel.PersonaSeleccionadaId = 0;
                }
                return View("Crear", matriculaViewModel);
            }
            if (matriculaViewModel.Action == "GuardarMatricula")
            {
                if (ModelState.IsValid && matriculaViewModel.NombresCompletos != null)
               // if (matriculaViewModel.NombresCompletos != null)
                {//ACA ES CUANDO YA _TODO ESTA BIEN Y LO VA A REGISTRAR
                    if (matriculaViewModel.PersonaSeleccionadaId == 0)//V -> el estudiatne no esta registrado
                    {
                        RegistrarNuevoEstudiante(matriculaViewModel);
                       
                    }
                    else
                    {
                        if (!matriculaService.EstaMatriculadoEnEstePeriodo_Ciclo(matriculaViewModel.PersonaSeleccionadaId))//VERIFICAMOS QUE NO ESTE MATRICULADO EN ESTE PERIODO_MES
                        {
                            RegistrarMatriculaEstudianteExiste(matriculaViewModel);
                           
                        }
                        else
                        {
                            TempData["msjeErrorEstudianteNoPuedeMatricularseEnEsteMesDosVeces"] = "ACTIVAR";
                            
                        }
                       
                    }
                    ViewBag.NroRegistros = matriculaService.ObtenerNroRegistros();
                    ViewBag.page = 1;

                    return RedirectToAction("Listar");
                    //var matriculas = matriculaService.ObtenerMatriculas("");
                   // return View("ListarMatricula", matriculas);
                }
                else
                {
                    if (matriculaViewModel.NivelSeleccionadoId != 0 && matriculaViewModel.CicloSeleccionadoId != 0 &&
                        matriculaViewModel.HorarioSeleccionadoId != 0|| matriculaViewModel.NombresCompletos==null)
                    {
                        TempData["msjeErrorValidacion"] = "ACTIVAR";//Ingrese un número de documento válido y de click en buscar
                    }
                  
                    return View("Crear", matriculaViewModel);
                }            
            }
            if (matriculaViewModel.Action == "GuardarEstudiante" )
            {
                ModelState.Clear();
                EjecutarValidacionesRegistrarPersonaViewModel(matriculaViewModel);
                if(ModelState.IsValid)
                {
                matriculaViewModel.NroDocumento = matriculaViewModel.ModNroDocumento;
                matriculaViewModel.NombresCompletos = matriculaViewModel.ModNombres +" "+
                                                      matriculaViewModel.ModApellidoPaterno +" "+
                                                      matriculaViewModel.ModApellidoMaterno;
                matriculaViewModel.PersonaSeleccionadaId = 0;
               }
                return View("Crear", matriculaViewModel);
            }
            return null;
        }

        private void EjecutarValidacionesEditarMatriculaViewModel(MatriculaViewModel matriculaViewModel)
        {
            if (string.IsNullOrEmpty(matriculaViewModel.NivelSeleccionadoId.ToString()) || matriculaViewModel.NivelSeleccionadoId == 0)
            {
                ModelState.AddModelError("NivelSeleccionadoId", "Nivel es obligatorio");
            }
            if (string.IsNullOrEmpty(matriculaViewModel.CicloSeleccionadoId.ToString()) || matriculaViewModel.CicloSeleccionadoId == 0)
            {
                ModelState.AddModelError("CicloSeleccionadoId", "Ciclo es obligatorio");
            }
            if (string.IsNullOrEmpty(matriculaViewModel.HorarioSeleccionadoId.ToString()) || matriculaViewModel.HorarioSeleccionadoId == 0)
            {
                ModelState.AddModelError("HorarioSeleccionadoId", "Horario es obligatorio");
            }
        }
        private void EjecutarValidacionesRegistrarMatriculaViewModel(MatriculaViewModel matriculaViewModel)
        {

            if (matriculaViewModel.NombresCompletos != null)
            {
                if (string.IsNullOrEmpty(matriculaViewModel.NivelSeleccionadoId.ToString()) || matriculaViewModel.NivelSeleccionadoId == 0)
                {
                    ModelState.AddModelError("NivelSeleccionadoId", "Nivel es obligatorio");
                }
                if (string.IsNullOrEmpty(matriculaViewModel.CicloSeleccionadoId.ToString()) || matriculaViewModel.CicloSeleccionadoId == 0)
                {
                    ModelState.AddModelError("CicloSeleccionadoId", "Ciclo es obligatorio");
                }
                if (string.IsNullOrEmpty(matriculaViewModel.HorarioSeleccionadoId.ToString()) || matriculaViewModel.HorarioSeleccionadoId == 0)
                {
                    ModelState.AddModelError("HorarioSeleccionadoId", "Horario es obligatorio");
                }
            }

            if (!string.IsNullOrEmpty(matriculaViewModel.NroDocumento) && matriculaViewModel.Action == "BuscarEstudiantePorNroDoc" )
            {
                var personaAGuardar = personaService.ObtenerPersonaProNroDoc(matriculaViewModel.NroDocumento);
                if (personaAGuardar == null)
                {
                    TempData["msjeErrorValidacion"] = "ACTIVAR";
                    ModelState.AddModelError("NroDocumento", "Nro Documento no registrado");
                }
            }

        }
        private void EjecutarValidacionesRegistrarPersonaViewModel(MatriculaViewModel matriculaViewModel)
        {
            var fechaInput = matriculaViewModel.ModFechaNacimiento;
            if (fechaInput.ToString() == "01/01/0001 0:00:00" && !String.IsNullOrEmpty(matriculaViewModel.ModNombres))
            {
                TempData["msjeErroModal"] = "ACTIVAR";
                ModelState.AddModelError("ModFechaNacimiento", "Fecha es Obligario");
            }
            if (fechaInput > DateTime.Now ||
                fechaInput.Year == DateTime.Now.Year && fechaInput.Month == DateTime.Now.Month &&
                fechaInput.Day == DateTime.Now.Day)
            {
                TempData["msjeErroModal"] = "ACTIVAR";
                ModelState.AddModelError("ModFechaNacimiento", "Fecha no puede ser mayor o igual a la fecha de hoy");
            }
            else
            {
                var r = DateTime.Now.Year - matriculaViewModel.ModFechaNacimiento.Year;
                if (r == 0)
                {
                    TempData["msjeErroModal"] = "ACTIVAR";
                    ModelState.AddModelError("ModFechaNacimiento", "Debe tener como minimo 7 años");
                }
                else
                {
                    if (r < 7)
                    {
                        TempData["msjeErroModal"] = "ACTIVAR";
                        //ModelState.AddModelError("ModFechaNacimiento", "Debe tener como minimo 7 años, tiene: " + r);
                        ModelState.AddModelError("ModFechaNacimiento", "Debe tener como minimo 7 años");
                    }
                }

            }

            if (!string.IsNullOrEmpty(matriculaViewModel.ModNroDocumento))
            {
                var personaAGuardar = personaService.ObtenerPersonaProNroDoc(matriculaViewModel.ModNroDocumento);
                if (personaAGuardar != null)
                {
                    TempData["msjeErroModal"] = "ACTIVAR"; //Error!! Modifique los campos en rojo y seleccione guardar
                    ModelState.AddModelError("ModNroDocumento", "Nro Documento ya existe");
                }
            }
        }
        private void EjecutarValidacionesEditarPersonaViewModel(MatriculaViewModel matriculaViewModel)
        {
            var fechaInput = matriculaViewModel.ModFechaNacimiento;
            if (fechaInput.ToString() == "01/01/0001 0:00:00" && !String.IsNullOrEmpty(matriculaViewModel.ModNombres))
            {
                TempData["msjeErroModal"] = "ACTIVAR";
                ModelState.AddModelError("ModFechaNacimiento", "Fecha es Obligario");
            }
            if (fechaInput > DateTime.Now ||
                fechaInput.Year == DateTime.Now.Year && fechaInput.Month == DateTime.Now.Month &&
                fechaInput.Day == DateTime.Now.Day)
            {
                TempData["msjeErroModal"] = "ACTIVAR";
                ModelState.AddModelError("ModFechaNacimiento", "Fecha no puede ser mayor o igual a la fecha de hoy");
            }
            else
            {
                var r = DateTime.Now.Year - matriculaViewModel.ModFechaNacimiento.Year;
                if (r == 0)
                {
                    TempData["msjeErroModal"] = "ACTIVAR";
                    ModelState.AddModelError("ModFechaNacimiento", "Debe tener como minimo 7 años");
                }
                else
                {
                    if (r < 7)
                    {
                        TempData["msjeErroModal"] = "ACTIVAR";
                        //ModelState.AddModelError("ModFechaNacimiento", "Debe tener como minimo 7 años, tiene: " + r);
                        ModelState.AddModelError("ModFechaNacimiento", "Debe tener como minimo 7 años");
                    }
                }

            }


        }
    }
}
