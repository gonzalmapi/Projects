using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea.App_Code.Controladores;

namespace Agapea
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CustomValidatorPolitica(object source, ServerValidateEventArgs args)
        {
             if (!this.CB1.Checked)
            {
                args.IsValid = false;
            }   

            if (this.TBPassword.Text.Length < 8)
            {
                args.IsValid = false;

            }
            else
            {
                this.CVpass.Visible = false;
            }


        }

        protected void BotonRegistro_Click(object sender, ImageClickEventArgs e)
        {

            if (this.IsValid)
            {
                Controlador_Vista_Registro control = new Controlador_Vista_Registro();
                if (control.GrabarUsuario(this.TBAlias.Text, this.TBNombre.Text, this.TBApellidos.Text,this.TBEmail.Text, this.TBPassword.Text))
                {
                    Response.Redirect("~/Vista/InicioLibro.aspx");
                }

            }
        }
    }
}