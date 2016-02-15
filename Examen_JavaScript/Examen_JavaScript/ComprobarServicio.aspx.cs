using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;

namespace Examen_JavaScript
{
    public partial class ComprobarServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CodPostal = (string)this.Request.QueryString["postalCode"];
            /*
            nos bajamos la pag.entera que tiene el formato si es correcto:   <html><head></head><body> {"codigoPostal":"28805","error":"0"} </body></html>
               si es erroneo: <html><head></head><body> {"error":"1"} </body></html>
            */
            String URI = "http://www.carrefouronline.carrefour.es/supermercado/ComprobarServicio.aspx?postalCode=" + CodPostal;

            string respuesta = "{\"codigo\": ";
            try
            {
                WebClient webClient = new WebClient();
                Stream stream = webClient.OpenRead(URI);
                String request = new StreamReader(stream).ReadToEnd();
                if (System.Text.RegularExpressions.Regex.IsMatch(request, "error\":\"0\"}"))
                {
                    respuesta += "0}";
                }
                else
                {
                    respuesta += "1}";
                }
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse)
                {
                    switch (((HttpWebResponse)ex.Response).StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            respuesta += "1}";
                            break;

                        default:
                            throw ex;
                    }
                }
            }

            this.Response.Clear();
            this.Response.ContentType = "application/json";
            this.Response.Write(respuesta);
            this.Response.Flush();

        }
    }
}
    
