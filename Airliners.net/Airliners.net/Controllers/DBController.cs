using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Airliners.net.Models;

namespace Airliners.net.Controllers
{
    public class DBController : Controller
    {
       private AirlinersDBDataContext adb { get; set; }
        public DBController()
        {
            adb = new AirlinersDBDataContext(ConfigurationManager.ConnectionStrings["Airliners_netConnectionString"].ConnectionString);
        }
        public Usuario getUsuario(string Nombre)
        {
            try
            {
                return adb.Usuarios.Single(u => u.Nombre == Nombre);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
        
    }
}