using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen_Feb_2016.App_Code.Modelo;
using System.Web.Script.Serialization;
using System.IO;

namespace Examen_Feb_2016
{
    public partial class ServidorRegistro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            StreamWriter escritor;
            string cliente = this.Request.Form["usuario"];
            Usuario data = new JavaScriptSerializer().Deserialize<Usuario>(cliente);
            string objetoJSON = "";
            try
            {
                escritor = new StreamWriter(new FileStream(this.Server.MapPath("usuarios.txt"), FileMode.Append, FileAccess.Write));

                string usuario_a_registro = data.email + ":"+ data.password + ":";

                escritor.WriteLine(usuario_a_registro);
                escritor.Flush();
                escritor.Close();

                objetoJSON = "{\"codigo\":0,\"mensaje\":\"cliente registrado correctamente\", \"vista\":\"registro\"}";
            }
            catch
            {
                objetoJSON = "{\"codigo\":1,\"mensaje\":\"fallo en el registro\", \"vista\":\"registro\"}";
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