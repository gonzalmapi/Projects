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
        private AirlinersDBDataContext adb = new AirlinersDBDataContext();
        public IEnumerable<AddFoto> GetPhotos()
        {
            IList<AddFoto> photoList = new List<AddFoto>();
            if ((string)Session["usuario"] != "admin")
            {
                var tio = (from usu in adb.Usuarios
                           where usu.Alias == (string)Session["usuario"]
                           select usu.Nombre).Single();
                var query = from photo in adb.Fotos
                            where photo.Fotografo == tio
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
            }
            else {
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
            }

            return photoList;
        }
        public AddFoto GetPhotoById(string photo)
        {
           
            var query = (from ph in adb.Fotos
                         where ph.Nombre == photo + ".jpg"
                         select ph).Single();
            // var det = query.FirstOrDefault();
            var model = new AddFoto()
            {
                photo = query.Nombre,
                name = query.Fotografo,
                airline = query.Aerolinea,
                airplane = query.Avion,
                date = query.Fecha,
                place = query.Lugar,
                notes = query.Notas
            };
            return model;
        }
        public ActionResult EditarFoto(string photo)
        {
            AddFoto model = GetPhotoById(photo);
            return View(model);
        }


        [HttpPost]
        public ActionResult EditarFoto(AddFoto ph)
        {
            try
            {


                Foto photoData = (from p in adb.Fotos
                                  where p.Nombre == ph.photo + ".jpg"
                                  select p).Single();
                //Foto photoData = adb.Fotos.Where(u => u.Nombre == (ph.photo+".jpg")).SingleOrDefault();
                photoData.Aerolinea = ph.airline;
                photoData.Avion = ph.airplane;
                photoData.Fecha = ph.date;
                photoData.Lugar = ph.place;
                photoData.Notas = ph.notes;
                adb.SubmitChanges();
                return RedirectToAction("TusFotos");

            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(ph);
        }
        [HttpGet]
        public ActionResult TusFotos()
        {
            var fotos = GetPhotos();
            return View(fotos);
        }
        [HttpGet]
        public ActionResult AñadirFoto()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MasInfo()
        {
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

            
            var nombre = (from usu in adb.Usuarios
                          where usu.Alias == (string)Session["usuario"]
                          select usu.Nombre).Single();

            Foto nuevo = new Foto();
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

            return RedirectToAction("Index", "Home");
        }
        public void DeleteFoto(string id) {
            Foto ph = adb.Fotos.Where(u => u.Nombre == (id+".jpg")).SingleOrDefault();
            string fullPath = Request.MapPath("~/Images/" + id+".jpg");
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            adb.Fotos.DeleteOnSubmit(ph);
           adb.SubmitChanges();
        }
        public ActionResult EliminarFoto(string photo, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            AddFoto foto = GetPhotoById(photo);
            return View(foto);
        }

        [HttpPost, ActionName("EliminarFoto")]
        public ActionResult DeleteConfirmed(string photo)
        {
            try
            {
                AddFoto foto = GetPhotoById(photo);
                DeleteFoto(photo);
            }
            catch (DataException)
            {
                return RedirectToAction("EliminarFoto",
                    new System.Web.Routing.RouteValueDictionary {
                { "id", photo },
                { "saveChangesError", true } });
            }
            return RedirectToAction("TusFotos");
        }
    }
}