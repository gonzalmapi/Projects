using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airliners.net.Models;


namespace Airliners.net.Controllers
{
    public class HomeController : Controller
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
        public AddFoto GetPhotoById(string photo)
        {
            AirlinersDBDataContext adb = new AirlinersDBDataContext();
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
        public ActionResult AñadirAlbum(string photo)
        {
            AirlinersDBDataContext adb = new AirlinersDBDataContext();
            var tio = (from usu in adb.Usuarios
                       where usu.Alias == (string)Session["usuario"]
                       select usu.Nombre).Single();
            bool esta = (from alb in adb.Albums
                         where alb.Nombre_Foto == photo + ".jpg" && alb.Nombre_Usu == tio
                         select true).SingleOrDefault();
            if (esta == false)
            {
                var query = (from ph in adb.Fotos
                             where ph.Nombre == photo + ".jpg"
                             select ph.Nombre).Single();
                Album nuevo = new Album();
                nuevo.Nombre_Foto = query;
                nuevo.Nombre_Usu = tio;
                adb.Albums.InsertOnSubmit(nuevo);
                try
                {
                    adb.SubmitChanges();
                }
                catch
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Detalles(string photo)
        {
            AddFoto model = GetPhotoById(photo);
            return View(model);
        }
        public ActionResult PerfilUsuario()
        {
            UsuarioRegistro model = getInfo();
            return View(model);
        }

        private UsuarioRegistro getInfo()
        {
            AirlinersDBDataContext adb = new AirlinersDBDataContext();
            var query = (from ph in adb.Usuarios
                         where ph.Alias == (string)Session["usuario"]
                         select ph).Single();
            var model = new UsuarioRegistro()
            {
                username = query.Alias,
                email = query.Email,
                confPassword = query.Contraseña,
                name = query.Nombre,
                age = query.Edad,
                gender = query.Sexo,
                country = query.Pais,
                occupation = query.Ocupacion,
                hobbies = query.Hobbies,
                url_personal = query.URLPersonal,
                other = query.Otros,
                city = query.Ciudad
            };
            return model;
        }

        // GET: Home
        public ActionResult Index()
        {
            Session["hay"] = false;
            var fotos = GetPhotos();
            return View(fotos);
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UsuarioLogin usulog)
        {
            if (ModelState.IsValid)
            {
                AirlinersDBDataContext adb = new AirlinersDBDataContext();
                var usuario = (from usu in adb.Usuarios
                               where usu.Alias == usulog.username && usu.Contraseña == usulog.password
                               select usu).Single();
                Session["usuario"] = usuario.Alias;
                return RedirectToAction("Index");
            }
            else {
                var err = ModelState.SelectMany(x => x.Value.Errors.Select(y => y.Exception));
                return View("Login");
            }

        }
        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registro(UsuarioRegistro usureg)
        {
            
                AirlinersDBDataContext adb = new AirlinersDBDataContext();
                Usuario nuevo = new Usuario();
                nuevo.Alias = usureg.username;
                nuevo.Email = usureg.email;
                nuevo.Contraseña = usureg.confPassword;
                nuevo.Nombre = usureg.name;
                nuevo.Edad = usureg.age;
                nuevo.Sexo = usureg.gender;
                nuevo.Pais = usureg.country;
                nuevo.Ocupacion = usureg.occupation;
                nuevo.Hobbies = usureg.hobbies;
                nuevo.URLPersonal = usureg.url_personal;
                nuevo.Otros = usureg.other;
                nuevo.Ciudad = usureg.city;
                adb.Usuarios.InsertOnSubmit(nuevo);
                try
                {
                    adb.SubmitChanges();
                }
                catch
                {
                }
            
            return RedirectToAction("Index");
        }
    }
}