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
    public class CicloController : Controller
    {

        [Dependency]
        public ICiclo cicloService { get; set; }

        [Dependency]
        public INivel nivelService { get; set; }

        [Authorize]
        public ViewResult Listar(string criterioBusqueda, int page = 1)
        {
            var ciclos = cicloService.ObtenerCiclosPorCriterio(criterioBusqueda, page);
            return View("ListarCiclo", ciclos);
        }
        [Authorize]
        public ViewResult Crear()
        {
            ViewBag.Niveles = nivelService.ObtenerTodosNiveles();
            return View("Crear", new Ciclo());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Guardar(Ciclo ciclo, String action)
        {

            EjecutarValidacionesCiclo(ciclo);

            if (ModelState.IsValid)
            {
                if (action == "GuardarNuevoCiclo")
                {
                    cicloService.RegistrarCiclo(ciclo);
                }
                else if (action == "GuardarEditarCiclo")
                {
                    cicloService.RegistrarCiclo(ciclo);
                    cicloService.UpdateCiclo(ciclo);

                }
            }
            else 
            {
                ViewBag.Niveles = nivelService.ObtenerTodosNiveles();
                return View("Crear", ciclo);
            }


            return RedirectToAction("Listar");
        }

        [Authorize]
        public ViewResult Editar(int id)
        {
            ViewBag.Niveles = nivelService.ObtenerTodosNiveles();
            var ciclo = cicloService.ObtenerCicloById(id);
            return View("Editar", ciclo);
        }

        [Authorize]
        public RedirectToRouteResult Eliminar(int id)
        {
            cicloService.EliminarCiclo(id);
            return RedirectToAction("Listar");
        }


        void EjecutarValidacionesCiclo(Ciclo ciclo)
        {
            if (ciclo.Nombre == "" || string.IsNullOrEmpty(ciclo.Nombre))
            {
                ModelState.AddModelError("Nombre", "Nombre es obligatorio");
            }

            if (ciclo.NivelFk == 0 || string.IsNullOrEmpty(ciclo.NivelFk.ToString()))
            {
                ModelState.AddModelError("Nivel", "Nivel es obligatorio");
            }

        }
    }
}
