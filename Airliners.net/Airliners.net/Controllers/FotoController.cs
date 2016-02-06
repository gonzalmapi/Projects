using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airliners.net.Models;

namespace Airliners.net.Controllers
{
    public class FotoController : Controller
    {
        [HttpGet]
        public ActionResult AñadirFoto() {
            return View();
        }
        [HttpPost]
        public ActionResult AñadirFoto(AddFoto af)
        {
            return View("Login");
        }
    }
}