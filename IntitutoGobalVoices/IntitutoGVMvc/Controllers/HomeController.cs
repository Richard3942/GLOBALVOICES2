﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntitutoGVMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //[Authorize]
         [AllowAnonymous] 
        public ActionResult Index()
        {
            return View();
        }

         [AllowAnonymous]
         public ActionResult AboutUs()
         {
             return View("AboutUs");
         }
    }
}
