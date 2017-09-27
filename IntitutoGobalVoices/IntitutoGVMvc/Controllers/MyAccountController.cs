using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Entidades;
using Interfaces;
using Microsoft.Practices.Unity;

namespace IntitutoGVMvc.Controllers
{
    public class MyAccountController : Controller
    {
        
        [Dependency]
        public IUsers UsersService { get; set; }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login l, string ReturnUrl = "")
        {

            var userBD = UsersService.ObtenerUserByUserName(l.Username);

           // FormsAuthentication.SetAuthCookie(userBD.Username, l.RememberMe);////////////////////
            if (userBD != null && userBD.Username == l.Username && userBD.Password == l.Password)
            {
                FormsAuthentication.SetAuthCookie(userBD.Username, l.RememberMe);
                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            // }
            // ModelState.Remove("Password");
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
