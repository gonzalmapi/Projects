using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace AjaxWithText
{
    public partial class Respuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string criterio = (string)this.Request.QueryString["criterio"];
            string valor = (string)this.Request.QueryString["valor"];

            //----------------------- FIJAOS COMO EN VEZ DE DEFINIR EN EL SWITCH UNA VARIABLE PARA DEFINIR LA POSICION DEL TAG EN EL NODO XML <LIBRO>....</LIBRO>
            // LO QUE HAGO ES DEFINIR EL PROPIO FILTRO QUE VA A IR EN EL WHERE del LINQ, Y ESTO SE HACE GRACIAS A LOS DELEGADOS QUE VEREMOS
            //

            Func<XmlElement, bool> filtro = delegate (XmlElement unNodoLibro) { return true; };

            switch (criterio)
            {
                case "Titulo":  filtro= delegate (XmlElement unNodoLibro) { return unNodoLibro.ChildNodes[0].ChildNodes[0].Value.Contains(valor) ? true : false;   }; break;
                case "Autor": filtro = delegate (XmlElement unNodoLibro) { return unNodoLibro.ChildNodes[1].ChildNodes[0].Value.Contains(valor) ? true : false; }; break;
                case "Isbn": filtro = delegate (XmlElement unNodoLibro) { return unNodoLibro.ChildNodes[2].ChildNodes[0].Value==valor ? true : false; }; break;
                case "Editorial": filtro = delegate (XmlElement unNodoLibro) { return unNodoLibro.ChildNodes[3].ChildNodes[0].Value.Contains(valor) ? true : false; }; break;
            }

            XmlDocument docxml = new XmlDocument(); docxml.Load(Server.MapPath("Biblioteca.xml"));
            List<XmlElement>nodosLibros=new List<XmlElement>(docxml.GetElementsByTagName("Libro").Cast<XmlElement>());

            List<XmlElement> buscarLibros = (from unNodoLibro in nodosLibros.Where(filtro)                                 
                                             select unNodoLibro).ToList();


            string respuesta = "<Libreria>";
            buscarLibros.ForEach(nodo => respuesta += nodo.OuterXml);
            respuesta += "</Libreria>";

    
            this.Response.Clear();
            this.Response.ContentType = "text/xml";
            this.Response.Write(respuesta);
            this.Response.Flush();
            this.Response.End();
        }
    }
}