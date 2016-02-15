using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibAgapea.App_Code.Controlador;
using LibAgapea.App_Code.Modelo;

namespace LibAgapea.App_Code.Controlador
{
    public class Controlador_Registro
    {
        private string usuario;
        private Controlador_Ficheros miControlador = new Controlador_Ficheros();
        public Usuario GrabarDatosUsuarios(string Nombre, string Apellidos, string Mail, string Login, string Pass)
        {


            Usuario nuevoUsuario = new Usuario();

            nuevoUsuario.nombre = Nombre;
            nuevoUsuario.apellido = Apellidos;
            nuevoUsuario.email = Mail;
            nuevoUsuario.alias = Login;
            nuevoUsuario.password = Pass;
            this.usuario += Login + ":" + Mail + ":" + Pass + ":" + Nombre + ":" + Apellidos;
            miControlador.RutaFichero = "~/Ficheros/Usuarios.txt";
            miControlador.AbrirFichero("ruta", "escribir");
            miControlador.GrabarDatos(usuario);

            return nuevoUsuario;


        }
    }
}