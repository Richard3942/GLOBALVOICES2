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

    public class SalonController : Controller
    {
        [Dependency]
        public ISalon salonService { get; set; }

        [Authorize]
        public ViewResult Listar(string criterioBusqueda, int page = 1)
        {
            var salones = salonService.ObtenerSalonPorCriterio(criterioBusqueda, page);
            return View("ListarSalones", salones);
        }

        [Authorize]
        public ViewResult Detalle(int id)
        {
            var salon = salonService.ObtenerSalonById(id);
            return View("Detalle", salon);
        }

        [Authorize]
        public ViewResult Crear()
        {
            return View("Crear", new Salon());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Guardar(Salon salon, String action)
        {

            EjecutarValidacionSalon(salon);

            if (ModelState.IsValid)
            {
                if (action == "GuardarNuevoSalon")
                {
                    salonService.RegistrarSalon(salon);
                }
                else if (action == "GuardarEditarSalon")
                {
                    salonService.UpdateSalon(salon);
                }
            }
            else {
                return View("Crear", salon);
            }

            return RedirectToAction("Listar");
        }

        [Authorize]
        public ViewResult Editar(int id)
        {
            var salon = salonService.ObtenerSalonById(id);
            return View("Editar", salon);
        }

        [Authorize]
        public RedirectToRouteResult Eliminar(int id)
        {
            salonService.EliminarSalon(id);
            return RedirectToAction("Listar");
        }


        void EjecutarValidacionSalon(Salon salon)
        {
            if (salon.Nombre == "" || string.IsNullOrEmpty(salon.Nombre))
            {
                ModelState.AddModelError("Nombre", "Nombre es obligatorio");
            }

            if (salon.Capacidad.ToString() == "" || string.IsNullOrEmpty(salon.Capacidad.ToString())  || salon.Capacidad<=0 )
            {
                ModelState.AddModelError("Capacidad", "Capacidad es obligatorio y mayor a cero");
            }


        }
    }
}
