using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airliners.net.Models;
using System.IO;
using System.Data;
using System.Collections.Generic;

namespace Airliners.net.Controllers
{
    public class FotoController : Controller
    {
        public IEnumerable<AddFoto> GetPhotos()
        {
            AirlinersDBDataContext adb = new AirlinersDBDataContext();
            IList<AddFoto> photoList = new List<AddFoto>();
            var query = from photo in adb.Fotos
                        select photo;
            var photos = query.ToList();
            foreach (var photoData in photos)
            {
                photoList.Add(new AddFoto()
                {
                    airline = photoData.Aerolinea,
                    airplane = photoData.Avion,
                    date = photoData.Fecha,
                    name = photoData.Fotografo,
                    photo = photoData.Nombre,
                    place = photoData.Lugar,
                    notes = photoData.Notas
                });
            }
            return photoList;
        }
        [HttpGet]
        public ActionResult TusFotos(AddFoto af)
        {
          var  fotos = GetPhotos();
          return View(fotos);
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
                af.name = (string)nombre;
                af.photo = (string)Session["nombreFoto"];
                nuevo.Aerolinea = af.airline;
                nuevo.Avion = af.airplane;
                nuevo.Fecha = af.date;
                nuevo.Fotografo = af.name;
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
            
            return View("Login");
        }
    } 
}