using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using LibAgapea.App_Code.Modelo;

namespace LibAgapea.App_Code.Controlador
{
    public class Controlador_Ficheros
    {
        #region "Variables"
        private StreamReader lector;
        private StreamWriter escritor;
        private string rutafichero;
        private FileStream fichero;
        #endregion
        #region "Metodos"
        public String RutaFichero
        {
            get { return rutafichero; }
            set { rutafichero = HttpContext.Current.Request.MapPath(value); }
        }
        public Boolean AbrirFichero(string ruta, string accion)
        {
            try
            {

                switch (accion)
                {
                    case "escribir":
                        escritor = new StreamWriter(new FileStream(RutaFichero, FileMode.Append, FileAccess.Write));
                        break;

                    case "leer":
                        lector = new StreamReader(new FileStream(RutaFichero, FileMode.Open, FileAccess.Read));
                        break;

                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }
        public Boolean GrabarDatos(string datos)
        {
            try
            {
                escritor.WriteLine(datos);
                escritor.Flush();
                escritor.Close();
                return true;
            }
            catch (IOException e)
            {
                return false;
            }
        }
        public bool ExisteUsuario(string nombre, string pass)
        {
            bool resultadoBusqueda = (from unalinea in this.lector.ReadToEnd().Split(new char[] { '\r', '\n' }).Where(linea => !new System.Text.RegularExpressions.Regex("^$").Match(linea).Success)
                                      let campoUsuario = unalinea.Split(new char[] { ':' })[3]
                                      let campoPass = unalinea.Split(new char[] { ':' })[2]
                                      where nombre == campoUsuario && pass == campoPass
                                      select true).SingleOrDefault();


            return resultadoBusqueda == true ? true : false;
        }
        public List<string> recuperarLineas()
        {
            List<String> lineas = (from unaLinea in this.lector.ReadToEnd().Split(new char[] { '\r', '\n' }).Where(linea => !new System.Text.RegularExpressions.Regex("^$").Match(linea).Success)
                                   select unaLinea).ToList();
            return lineas;
        }
        public Usuario recuperaUsuario(string login)
        {
            string infoUsuario = (from unaLinea in this.lector.ReadToEnd().Split(new char[] { '\r', '\n' }).Where(linea => !new System.Text.RegularExpressions.Regex("^$").Match(linea).Success)
                                  let loginUsuario = unaLinea.Split(new char[] { ':' })[3]
                                  where login == loginUsuario
                                  select unaLinea).SingleOrDefault();

            Usuario user = new Usuario();
            //List<String> argumentosUsuario = infoUsuario.Split(new char[] { ':' }).ToList();
            user.nombre = infoUsuario.Split(new char[] { ':'})[4].ToString();
            user.apellido = infoUsuario.Split(new char[] { ':' })[1].ToString();
            user.email = infoUsuario.Split(new char[] { ':' })[0].ToString();
            user.alias = infoUsuario.Split(new char[] { ':' })[3].ToString();
            user.password = infoUsuario.Split(new char[] { ':' })[2].ToString();
            //string compras = argumentosUsuario[5].ToString();//-->NULL XQ NO EXISTEN COMPRAS EN EL FICHERO

            //comprasUsuario =  public Dictionary <string, List<CarritoCompra>>
            //user.comprasUsuario = 

            return user;
        }
        #endregion

    }
}