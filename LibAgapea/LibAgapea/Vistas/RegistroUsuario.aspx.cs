using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibAgapea.App_Code.Controlador;
using LibAgapea.App_Code.Modelo;

namespace LibAgapea.Vistas
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        private Controlador_Registro control;
        protected void Page_Load(object sender, EventArgs e)
        {
  
        }
        protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!this.CB1.Checked) args.IsValid = false;
        }

        protected void BotonRegistro_Click(object sender, ImageClickEventArgs e)
        {
            control = new Controlador_Registro();

            if (this.IsValid)
            {
                Usuario usuario = new Usuario();
                control.GrabarDatosUsuarios(this.TBAlias.Text, this.TBNombre.Text, this.TBApellidos.Text, this.TBEmail.Text, this.TBPassword.Text);
                Session["usuario"] = usuario;
                this.Response.Redirect("~/Vistas/Login.aspx");

            }
        }
    }
}