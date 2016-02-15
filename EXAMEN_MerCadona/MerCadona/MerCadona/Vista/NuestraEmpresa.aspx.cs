using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerCadona.Vista
{
    public partial class NuestraEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            this.Response.Redirect("~/Vista/Inicio.aspx");
        }     

        protected void Donde_Click(object sender, ImageClickEventArgs e)
        {
            this.Response.Redirect("~/Vista/Donde_Estamos.aspx");
        }

        protected void AttC_Click(object sender, ImageClickEventArgs e)
        {
            this.Response.Redirect("~/Vista/Atencion_Cliente.aspx");
        }
    }
}