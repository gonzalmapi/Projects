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
        // GET: Home
        public ActionResult Index()
        {
            var fotos = GetPhotos();
            return View(fotos);
        }
        [HttpGet]
        public ActionResult Logout() {
            Session.Clear(); 
            return RedirectToAction("Index");
        }
      
        [HttpGet]
        public ActionResult Login() {
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
        public ActionResult Registro(UsuarioRegistro usureg) {
            if (ModelState.IsValid) {
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
                catch {
                }
            }
            else
            {
                var error= ModelState.SelectMany(x => x.Value.Errors.Select(y => y.Exception));
                return View("Index");
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult PerfilUsuario() {
            return View();
        }
    }
}