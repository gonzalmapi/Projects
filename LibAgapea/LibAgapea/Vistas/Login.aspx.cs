using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibAgapea.App_Code.Controlador;
using LibAgapea.App_Code.Modelo;
using System.Collections.Specialized;

namespace LibAgapea.Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        private Controlador_Login control;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void IbtnRegistro_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Vistas/RegistroUsuario.aspx");
        }

        protected void IBtnLogin_Click(object sender, ImageClickEventArgs e)
        {
      
            control = new Controlador_Login();
            NameValueCollection coleccionCookies_userInfo;

            if (Request.Cookies["userInfo"] != null)
            {
                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
            }

            string usu = TBUsuario.Text;
            string pass = TBPassw.Text;

            if (control.ExisteUsuario(usu, pass) == true)
            {
                HttpCookie miCookie = Request.Cookies["userInfo"];
                miCookie.Values["nombreUsu"] = TBUsuario.Text;
                miCookie.Values["ultimaVisita"] = DateTime.Now.ToString();
                Response.Cookies.Add(miCookie);

                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                this.Response.Redirect("Index.aspx?usuario=" + TBUsuario.Text);
            }
            else
            {
                labelError.Visible = true;
            }
        }
    }
}