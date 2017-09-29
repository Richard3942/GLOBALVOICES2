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
    public class NivelController : Controller
    {
        [Dependency]
        public INivel nivelService { get; set; }
       

        [Authorize]
        public ViewResult Listar(string criterioBusqueda, int page = 1)
        {
            var niveles = nivelService.ObtenerNivelesPorCriterio(criterioBusqueda,page);
            return View("ListarNivel", niveles);

        }

        [Authorize]
        public ViewResult Crear()
        {
            return View("Crear", new Nivel());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Guardar(Nivel nivel, String action)
        {
            EjecutarValidacionesNivel(nivel);
            if (ModelState.IsValid)
            {

                if (action == "GuardarNuevoNivel")
                {
                    nivelService.RegistrarNivel(nivel);
                }
                else if (action == "GuardarEditarNivel")
                {
                    nivelService.UpdateNivel(nivel);
                }
            }
            else {
                return View("Crear", nivel);
            }


            return RedirectToAction("Listar");
        }

        [Authorize]
        public RedirectToRouteResult Eliminar(int id)                             
        {
            nivelService.EliminarNivel(id);
            return RedirectToAction("Listar");
        }

        [Authorize]
        public ViewResult Detalle(int id)
        {
            var nivel = nivelService.ObtenerNivelById(id);       
            return View("Detalle", nivel);
        }


        [Authorize]
        public ViewResult Editar(int id)
        {        
            var nivel = nivelService.ObtenerNivelById(id);
            return View("Editar", nivel);
        }

        void EjecutarValidacionesNivel(Nivel nivel)
        {
            if (nivel.Nombre == "" || string.IsNullOrEmpty(nivel.Nombre) )
            {
                ModelState.AddModelError("Nombre", "Nombre es obligatorio");
            }
        }
      

    }
}
