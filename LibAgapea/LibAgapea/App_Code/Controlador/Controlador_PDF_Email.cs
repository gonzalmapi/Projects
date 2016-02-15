using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibAgapea.App_Code.Modelo;
using Spire.Pdf;
using Spire.Pdf.HtmlConverter;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Collections.Specialized;


namespace LibAgapea.App_Code.Controlador
{
    public class Controlador_PDF_Email
    {
        private string keyString = "";
        public PdfDocument CrearDocPDF(string rutaFichero, /*Usuario user,*/ Dictionary<string, List<Libro>> coleccionLibrosCarrito, string infoCookieLibros)
        {
            PdfDocument miFactura = new PdfDocument();

            PdfHtmlLayoutFormat htmlLayoutFormat = new PdfHtmlLayoutFormat();

            htmlLayoutFormat.IsWaiting = false;

            PdfPageSettings setting = new PdfPageSettings();
            setting.Size = PdfPageSize.A4;

            //String facturaHTML = File.ReadAllText(rutaFichero + "PlantillaFactura.html");
            String facturaHTML = GenerarFacturaEnHTML(rutaFichero + "Imagenes/", coleccionLibrosCarrito.Values.ElementAt(0), /*user,*/ infoCookieLibros);

            List<string> nombreKey = coleccionLibrosCarrito.Keys.ToList();
            string keyString = "";
            foreach (string key in nombreKey)
            {
                keyString = key;
                keyString = keyString.Replace('/', '_').Replace(' ', '_').Replace(':', '_');
            }

            Thread thread = new Thread(() =>
            {
                miFactura.LoadFromHTML(facturaHTML, false, setting, htmlLayoutFormat);
                //miFactura.LoadFromHTML(facturaHTML, false, true, true);
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            //string filePath = rutaFichero + "facturas/" + user.loginUsuario + keyString + ".pdf";

            //if (!File.Exists(filePath))
            //{
            //    FileStream f = File.Create(filePath);
            //    f.Close();
            //}
            try
            {
                //  miFactura.SaveToFile(rutaFichero + "Facturas/" + /*user.alias + keyString +*/ "Recibo.pdf");
                miFactura.SaveToFile("Recibo.pdf");
                mandar_email(miFactura);
            }
            catch (Exception e)
            {

            }


            //System.Diagnostics.Process.Start(rutaFichero + "facturas/" + user.loginUsuario + keyString + ".pdf");

            return miFactura;
        }


        private String GenerarFacturaEnHTML(string ruta, List<Libro> coleccionLibrosCarrito, /*Usuario user,*/ string infoCookieLibros)
        {
            string filas = "";
            StringBuilder midocHTML = new StringBuilder();

            midocHTML.Append("<img src='" + ruta + "encabezado_inicio.png'/>" + "<br/>");

            midocHTML.Append("LIBRERÍA AGAPEA" + "<br/>");
            midocHTML.Append("FACTURA DEL CLIENTE: /*+ user.nombre +*/ <br/>");
            midocHTML.Append("Libros comprados:" + @"<br/>");
            midocHTML.Append("------------------------------------" + "<br/>");
            midocHTML.Append("<table style='border-top: solid blue; width:595px; heigh:842px; text-align:center'>");
            midocHTML.Append("<th>TITULO</th><th>AUTOR</th><th>PRECIO</th><th>CANTIDAD</th><th>TOTAL</th>");
            foreach (Libro lib in coleccionLibrosCarrito)
            {
                midocHTML.Append("<tr>");
                midocHTML.Append("<td style='width:30%'>" + lib.titulo + "</td>");
                midocHTML.Append("<td>" + lib.autor + "</td>");
                decimal precio = lib.precio;
                midocHTML.Append("<td>" + precio + "</td>");
                decimal cantidad = Convert.ToDecimal(recuperaCantidad(infoCookieLibros, lib.ISBN10));
                midocHTML.Append("<td>" + cantidad + "</td>");
                midocHTML.Append("<td>" + (precio * cantidad).ToString() + "</td>");
                midocHTML.Append("</tr>");
            }
            midocHTML.Append("</table>");

            return midocHTML.ToString();
        }

        public int recuperaCantidad(string infoCookieLibros, string isbn10)
        {
            int cantidad = 0;

            List<string> isbn = infoCookieLibros.Split(new char[] { '$' }).ToList();

            for (int i = 0; i < isbn.Count; i++)
            {
                if (isbn[i].ToString() != "")
                {
                    if (isbn[i].ToString() == isbn10)
                    {
                        cantidad = Convert.ToInt32(isbn[i - 1]);
                    }
                }
            }

            return cantidad;
        }


        public bool mandar_email(PdfDocument pdf)
        {
            string pdfs = pdf.ToString();
            MailMessage nuevoCorreo = new MailMessage();
            nuevoCorreo.To.Add(new MailAddress("gonzalmapi@hotmail.com"));
            nuevoCorreo.From = new MailAddress("gonzalmapi@gmail.com");
            nuevoCorreo.Subject = "Factura compra en Libreria Agapea";
            nuevoCorreo.Attachments.Add(new Attachment(pdfs));
            nuevoCorreo.Body = "Gracias por usar nuestra Pagina";

            SmtpClient servidor = new SmtpClient();
            servidor.Host = "smtp.gmail.com";
            servidor.Port = 587;
            servidor.EnableSsl = true;
            servidor.DeliveryMethod = SmtpDeliveryMethod.Network;
            servidor.Credentials = new NetworkCredential("gonzalmapi@gmail.com", "w95iniciodisco");
            servidor.Timeout = 20000;
            try
            {
                servidor.Send(nuevoCorreo);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
