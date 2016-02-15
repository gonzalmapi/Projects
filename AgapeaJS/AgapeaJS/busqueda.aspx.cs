using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace AgapeaJS
{
    public partial class busqueda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int __campoBusqueda;
            string __valorBuscado=this.Request.QueryString["valor"];
            string __criterio = this.Request.QueryString["criterio"];
            StreamReader __fichero = new StreamReader(new FileStream(this.Server.MapPath("Libro.txt"), FileMode.Open, FileAccess.Read));
            /*foreach (string clave in this.Request.QueryString.AllKeys)
            {
                switch (clave)
                {
                    case "Titulo":
                        __campoBusqueda = 0;
                        __valorBuscado = this.Request.QueryString["Titulo"];
                        break;
                    case "Isbn":
                        __campoBusqueda = 2;
                        __valorBuscado = this.Request.QueryString["Isbn"];
                        break;
                    case "Autor":
                        __campoBusqueda = 1;
                        __valorBuscado = this.Request.QueryString["Autor"];
                        break;
                    default:
                        __campoBusqueda = 0;
                        __valorBuscado = null;
                        break;
                }*/
            if (__criterio == "Titulo")
            {
                __campoBusqueda = 0;
            } else if (__criterio == "Isbn")
            {
                __campoBusqueda = 2;
            }
            else
            {
                __campoBusqueda = 1;
            }
            
            try
                {
                    string[] lineas = (from unalinea in __fichero.ReadToEnd().Split(new char[] { '\n' })
                                       where unalinea.Split(new char[] { ':' })[__campoBusqueda] == __valorBuscado
                                       select unalinea).ToArray();
                    this.Response.ContentType = "plain/text";
                    this.Response.Write(lineas);
                    this.Response.Flush();
                    this.Response.End();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    __fichero.Close();
                }
            }

        }
    }
}