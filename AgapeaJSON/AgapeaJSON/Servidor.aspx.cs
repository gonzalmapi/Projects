using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using AgapeaJSON.App_Code.Modelo;

namespace AgapeaJSON
{
    public partial class Servidor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatosRecibidosCliente recibido = new JavaScriptSerializer().Deserialize<DatosRecibidosCliente>(this.Request.Params["data"]);
            
            Boolean encontrado = (from unalinea in new System.IO.StreamReader(this.Server.MapPath("Usuarios.txt")).ReadToEnd().Split(new char[] { '\r', '\n' }).Where(una => una.Length > 0)
                                  let campousu = unalinea.Split(new char[] { ':' })[0].ToString()
                                  let campopas = unalinea.Split(new char[] { ':' })[1].ToString()
                                  where recibido.Login == campousu && recibido.Passw == campopas
                                  select true).SingleOrDefault();
            string respuesta = "";
            if (encontrado)
            {
                respuesta = "{\"codigo\":0, \"mensaje\":\"autentificacion correcta\"}";
            }
            else
            {
                respuesta = "{\"codigo\":1, \"mensaje\":\"autentificacion incorrecta\"}";
            }
            this.Response.ContentType="application/json";
            this.Response.Write(respuesta);
            this.Response.End();
        }
    }
}