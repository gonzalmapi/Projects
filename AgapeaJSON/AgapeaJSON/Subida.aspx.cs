using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgapeaJSON
{
    public partial class Subida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpPostedFile fichero = this.Request.Files[0];
            String usario = this.Request.Form["usuario"];
            Byte[] contenido = new Byte[fichero.ContentLength];
           string objetojson ="";
            String ruta = HttpContext.Current.Request.MapPath("~/App_Data/Uploads/Registro.txt");
            FileStream fs= new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Write); ;
   
            StreamWriter sw= new StreamWriter(fs);
            
            try
            {
                
                sw.WriteLine(usario);
                fichero.InputStream.Read(contenido, 0, fichero.ContentLength);
            File.WriteAllBytes(Server.MapPath("~/App_Data/Uploads") + fichero.FileName, contenido);
                objetojson = "{\"codigo\":0, \"mensaje\":\"Registro correcta\"}";
            }
            catch (Exception)
            {

                objetojson = "{\"codigo\":1, \"mensaje\":\"Registro incorrecta\"}";
            }
            sw.Flush();
            sw.Close();
            this.Response.Clear();
            this.Response.ContentType = "application/json";
            this.Response.Write(objetojson);
            this.Response.End();
            }
    }
}