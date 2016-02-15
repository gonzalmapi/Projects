using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agapea.App_Code.Modelos;

namespace Agapea.App_Code.Controladores
{
     public class Controlador_Vista_Registro
    {
        private Controlador_Acceso_Fichero_Usuario micontrolador = new Controlador_Acceso_Fichero_Usuario();
        public Boolean GrabarUsuario(string alias,string nombre,string apellido, string email,string contraseña)
        {
            Usuario nuevousuario = new Usuario();
            nuevousuario.alias = alias;
            nuevousuario.nombre =nombre;
            nuevousuario.apellido = apellido;
            nuevousuario.email = email;
            nuevousuario.contraseña = contraseña;
            return  micontrolador.GrabarDatos(alias, nombre, apellido,email,contraseña);
            
        }
    }
}