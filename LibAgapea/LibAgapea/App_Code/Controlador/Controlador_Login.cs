using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibAgapea.App_Code.Controlador
{
    public class Controlador_Login
    {
        private Controlador_Ficheros control = new Controlador_Ficheros();
        public bool ExisteUsuario(string nombre,string pass)
        {
            control.RutaFichero = "~/Ficheros/Usuarios.txt";
            control.AbrirFichero("ruta", "leer");
            bool resultado = control.ExisteUsuario(nombre, pass);
            return resultado;
        }
    }
}