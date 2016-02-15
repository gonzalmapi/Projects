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
        // GET: Home
        public ActionResult Index()
        {
            //var model=
            return View();
        }
        [HttpGet]
        public ActionResult Logout() {
            Session["usuario"] = null;
            return View("Index");
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
            }
            else {
                var err = ModelState.SelectMany(x => x.Value.Errors.Select(y => y.Exception));          
                return View("Login");
            }
            return View("Index");
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