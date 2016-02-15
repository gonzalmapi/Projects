using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mercadona_JS.App_Code.Modelo;
using System.Web.Script.Serialization;
using System.IO;

namespace Mercadona_JS
{
    public partial class ServidorRegistro : System.Web.UI.Page
    {
        private StreamWriter escritor;
        protected void Page_Load(object sender, EventArgs e)
        {
            String cliente = this.Request.Form["cliente"];
            DatosRegistro data = new JavaScriptSerializer().Deserialize<DatosRegistro>(cliente);
            string objetoJSON = "";
            try
            {
                  escritor = new StreamWriter(new FileStream(this.Server.MapPath("clientes.txt"), FileMode.Append, FileAccess.Write));

                string cliente_a_registro = data.nombre + ":" + data.ape1 + ":" + data.ape2 + ":" + data.tipo_ID + ":" + data.ID + ":"
                                                + data.info + ":" + data.email + ":" + data.fecha + ":"
                                                + data.passw + ":"
                                                + data.direc + ":" + data.telf;

                escritor.WriteLine(cliente_a_registro);
                escritor.Flush();
                escritor.Close();

                objetoJSON = "{\"codigo\":0,\"mensaje\":\"cliente registrado correctamente\", \"vista\":\"registro_cliente\"}";
            }
            catch
            {
                objetoJSON = "{\"codigo\":1,\"mensaje\":\"fallo en el registro\", \"vista\":\"registro_cliente\"}";
            }
            finally
            {
                this.Response.ContentType = "application/json";
                this.Response.Write(objetoJSON);
                this.Response.End();
            }
        }
    }
    }
