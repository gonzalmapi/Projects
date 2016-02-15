using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Agapea.App_Code.Controladores;
using Agapea.App_Code.Modelos;

namespace Agapea.App_Code.Controladores
{
    
    public class Controlador_Acceso_Fichero_Usuario
    {
        private StreamReader lector;
        private StreamWriter escritor;
        private FileStream ficheroesc;
        private String[] leido;
        private String ruta=HttpContext.Current.Request.MapPath("~/Ficheros/usuario.txt");
        public Controlador_Acceso_Fichero_Usuario() { }
        public void setRuta(String ruta)
        {
            this.ruta = ruta;
        }
        public String getruta()
        {
            if (this.ruta == null)
            {
                return HttpContext.Current.Request.MapPath("~/Ficheros/usuario.txt");
            }
            else return this.ruta;
        }
        public String[] getLeido()
        {
            return this.leido;
        }
        public Boolean AbrirFichero(string ruta)
        {
            try
            {
                this.lector = new StreamReader(ruta);
                this.leido = this.lector.ReadToEnd().Split(new char[] {'\n'});
                return true;
            }
            catch(IOException e)
            {
                return false;
            }            
        }
        public Boolean AbrirFichero()
        {
            try
            {
                this.lector = new StreamReader(this.temporal("lectura"));
                this.leido = this.lector.ReadToEnd().Split(new char[] { '\n' });
                this.lector.Close();
                return true;
            }
            catch (IOException e)
            {
                return false;
            }
        }
        public Boolean GrabarDatos(Usuario usu)
        {
            try
            {
                this.escritor = new StreamWriter(this.ficheroesc);
                this.escritor.WriteLine(usu.nombre + ":" + usu.apellido + ":" + usu.alias + ":" + usu.email + ":" + usu.contraseña);
                this.escritor.Flush();
                this.escritor.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            throw new NotImplementedException();
        }
        public Boolean GrabarDatos(string alias, string nombre, string apellido,string email, string contraseña)
        {
            try
            {
               this.escritor = new StreamWriter(this.temporal("escritura"));
                this.escritor.WriteLine(nombre + ":" + apellido + ":" + alias + ":" + email + ":" + contraseña);
                this.escritor.Flush();
                this.escritor.Close();
                return true;
            }
            catch (Exception e)
            { return false;
            }throw new NotImplementedException();
        }
        private FileStream temporal(string modo)
        {
            switch (modo)
            {
                case ("lectura"):
                    this.ficheroesc = new FileStream(this.ruta, FileMode.OpenOrCreate, FileAccess.Read);
                    break;
                case ("escritura"):
                    this.ficheroesc = new FileStream(this.ruta, FileMode.Append, FileAccess.Write);
                    break;
            }
            return this.ficheroesc;
        }
        
        
    }
      
}