using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Mercadona_JS.App_Code.Modelo;

namespace Mercadona_JS
{
    public partial class ServidorLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           DatosAcceso recibido = new JavaScriptSerializer().Deserialize<DatosAcceso>(this.Request.Params["data"]);

             Boolean encontrado = (from unalinea in new System.IO.StreamReader(this.Server.MapPath("Clientes.txt")).ReadToEnd().Split(new char[] { '\r', '\n' }).Where(una => una.Length > 0)
                                    let campousu = unalinea.Split(new char[] { ':' })[6].ToString()
                                    let campopas = unalinea.Split(new char[] { ':' })[8].ToString()
                                    where recibido.email == campousu && recibido.passw == campopas
                                    select true).SingleOrDefault();
            string respuesta = "";
            if (encontrado)
            {
                respuesta = "{\"codigo\":0, \"mensaje\":\"cliente OK\", \"vista\":\"login\"}";
            }
            else
            {
                respuesta = "{\"codigo\":1, \"mensaje\":\"cliente no existe\",\"vista\":\"login \"}";
            }
            this.Response.ContentType = "application/json";
            this.Response.Write(respuesta);
            this.Response.End();
        }
    }
    }
