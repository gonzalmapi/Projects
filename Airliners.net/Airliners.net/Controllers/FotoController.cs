using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airliners.net.Models;
using System.IO;

namespace Airliners.net.Controllers
{
    public class FotoController : Controller
    {
        [HttpGet]
        public ActionResult TusFotos()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AñadirFoto() {
            return View();
        }
        [HttpGet]
        public ActionResult MasInfo() {
            return View();
        }
        [HttpPost]
        public ActionResult AñadirFoto(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                Console.WriteLine(fileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                file.SaveAs(path);
                Session["nombreFoto"] = fileName;
                
            }
            return RedirectToAction("MasInfo");

        }
        [HttpPost]
        public ActionResult MasInfo(AddFoto af)
        {
                
                
                AirlinersDBDataContext adb = new AirlinersDBDataContext();
            var nombre = (from usu in adb.Usuarios
                          where usu.Alias == (string)Session["usuario"]
                          select usu.Nombre).Single();
            
            Fotos nuevo = new Fotos();
                 af.name = (string) nombre;
                af.photo = (string)Session["nombreFoto"];
            nuevo.Aerolinea = af.airline;
                nuevo.Avion = af.airplane;
                nuevo.Fecha = af.date;
                nuevo.Fotografo =af.name;
                nuevo.Lugar = af.place;
                nuevo.Notas = af.notes;
                nuevo.Nombre = af.photo;
                adb.Fotos.InsertOnSubmit(nuevo);
                try
                {
                    adb.SubmitChanges();
                }
                catch
                {
                    throw;
                }
            return View();
        }
    }
    
}