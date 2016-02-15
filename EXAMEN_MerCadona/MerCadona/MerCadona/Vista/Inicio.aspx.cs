using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerCadona.Vista
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Nuestra_Empresa_Click(object sender,ImageClickEventArgs e)
        {
            this.Response.Redirect("~/Vista/NuestraEmpresa.aspx");
        }

        protected void Compra_Click(object sender, ImageClickEventArgs e)
        {
            this.Response.Redirect("~/Vista/CompraOnlineini.aspx");
        }
    }
}