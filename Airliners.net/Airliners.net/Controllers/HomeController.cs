using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airliners.net.Models;
using System.Data;
using System.Net.Mail;
namespace Airliners.net.Controllers
{
    public class HomeController : Controller
    {
        private AirlinersDBDataContext adb = new AirlinersDBDataContext();
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
                return RedirectToAction("Album");
            }
        }
        public ActionResult Album() {
            return View();
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
        public ActionResult Error() {
            return View();
        }
        public ActionResult Envio() {
            return View();
        }
        [HttpGet]
        public ActionResult Forgot() {
            return View();
        }
        [HttpPost]
        public ActionResult Forgot(RecuPass rp) {
            if (ModelState.IsValid)
            {
               // bool existe = false;
               bool existe = (from usu in adb.Usuarios
                               where usu.Email == rp.Email 
                               select true).SingleOrDefault();
                if (existe==true)
                {
                    Usuario usuario = (from usu in adb.Usuarios
                                  where usu.Email == rp.Email
                                  select usu).Single();
                    sendEmail(usuario);
                    return RedirectToAction("Envio");
                }
                else {
                    return RedirectToAction("Error");
                }
            }
            else {
                var err = ModelState.SelectMany(x => x.Value.Errors.Select(y => y.Exception));
                return View("Forgot");
            }
           
        }
        public ActionResult CondicionesdeUso() {
            return View();
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
                
                bool usuario = (from usu in adb.Usuarios
                               where usu.Alias == usulog.username && usu.Contraseña == usulog.password
                               select true).SingleOrDefault();
                if (usuario==true) {
                    Session["usuario"] = usulog.username;
                    return RedirectToAction("Index");
                }
                else{
                    return RedirectToAction("Login");
                }
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
            if (ModelState.IsValid)
            {
                bool usuario = (from usu in adb.Usuarios
                                where usu.Alias == usureg.username || usu.Email == usureg.email || usu.Nombre == usureg.name
                                select true).Any();
                if (usuario==false)
                {
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
                    adb.SubmitChanges();
                    sendEmail(usureg);
                    return RedirectToAction("Index");
                }
                else {
                    return RedirectToAction("Registro");
                }
            }
            else {
                var err = ModelState.SelectMany(x => x.Value.Errors.Select(y => y.Exception));
                return View("Registro");
            }
            } 

        private void sendEmail(UsuarioRegistro usu)
        {
            MailMessage m = new MailMessage(
            new MailAddress("proyectos.mvc.asp@gmail.com", "Airliners"),
            new MailAddress(usu.email));
            m.Subject = "INFO REGISTRO";
            m.Body = string.Format("Estimado "+usu.name+ ":<br/> Gracias por tu registro:<br/>"+
               "Info del registro:<br/>Login: "+usu.username+"<br/>Password: "+usu.confPassword+
               "<br/>Que pases un feliz vuelo en esta web" + "<br/>POR FAVOR NO CONTESTE ESTE CORREO"
                ) ;
            m.IsBodyHtml = true;
           SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Credentials = new System.Net.NetworkCredential("proyectos.mvc.asp@gmail.com", "quarantine");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        private void sendEmail(Usuario usu)
        {
            MailMessage m = new MailMessage(
            new MailAddress("proyectos.mvc.asp@gmail.com", "Airliners"),
            new MailAddress(usu.Email));
            m.Subject = "INFO LOGIN";
            m.Body = string.Format("Estimado " + usu.Nombre + ":<br/> Este email es para logearte en esta pagina:<br/>" +
               "Info del registro:<br/>Login: " + usu.Alias + "<br/>Password: " + usu.Contraseña +"<br/>"+
               "Vaya a: <br/>"+"http://localhost:2097/Home/Login"+"<br/>E Ingrese los datos ofrecidos en este email en el login"+
               "<br/>POR FAVOR NO CONTESTE ESTE CORREO"
                );
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Credentials = new System.Net.NetworkCredential("proyectos.mvc.asp@gmail.com", "quarantine");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        public ActionResult EditarUsuario(string id)
        {
            UsuarioRegistro model = GetUserById(id);
            return View(model);
        }


        [HttpPost]
        public ActionResult EditarUsuario(UsuarioRegistro usureg)
        {
            try
            {
                Usuario userData = (from usu in adb.Usuarios
                                    where usu.Alias == (string)Session["usuario"]
                                    select usu).Single();

                userData.Alias = usureg.username;
                userData.Email = usureg.email;
                userData.Contraseña = usureg.confPassword;
                userData.Edad = usureg.age;
                userData.Sexo = usureg.gender;
                userData.Pais = usureg.country;
                userData.Ocupacion = usureg.occupation;
                userData.Hobbies = usureg.hobbies;
                userData.URLPersonal = usureg.url_personal;
                userData.Otros = usureg.other;
                userData.Ciudad = usureg.city;
                adb.SubmitChanges();
                return RedirectToAction("PerfilUsuario");
                
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(usureg);
        }

        public ActionResult EliminarCuenta(string id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes";
            }
            UsuarioRegistro user = GetUserById(id);
            return View(user);
        }

        private UsuarioRegistro GetUserById(string id)
        {
            var query = (from usu in adb.Usuarios
                         where usu.Alias == id
                         select usu).Single();
            var model = new UsuarioRegistro()
            {
                name = query.Nombre,
                 username= query.Alias,
                city = query.Ciudad,
                confPassword = query.Contraseña,
                age = query.Edad,
                email = query.Email,
                hobbies = query.Hobbies,
                occupation = query.Ocupacion,
                other = query.Otros,
                country = query.Pais,
                gender = query.Sexo,
                url_personal= query.URLPersonal
            };
            return model;
        }

        [HttpPost, ActionName("EliminarCuenta")]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                UsuarioRegistro user = GetUserById(id);
                DeleteUsuario(id);
            }
            catch (DataException)
            {
                return RedirectToAction("EliminarCuenta",
                    new System.Web.Routing.RouteValueDictionary {
                { "id", id },
                { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }

        private void DeleteUsuario(string id)
        {
            var nombre = (from usu in adb.Usuarios
                          where usu.Alias == id
                          select usu.Nombre).Single();
            Usuario user = adb.Usuarios.Where(u => u.Alias == id).SingleOrDefault();
            adb.Usuarios.DeleteOnSubmit(user);
            Foto photoData = (from p in adb.Fotos
                              where p.Fotografo == nombre
                              select p).Single();
            photoData.Fotografo = "admin";           
            adb.SubmitChanges();
        }
    }
}