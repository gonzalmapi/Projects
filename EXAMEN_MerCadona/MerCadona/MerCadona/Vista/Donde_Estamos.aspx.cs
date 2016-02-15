using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MerCadona.Vista
{
    public partial class Donde_Estamos : System.Web.UI.Page
    {
        private ListItem prov_sel;
        protected void Page_Load(object sender, EventArgs e)
        {
            BusquedaRefinada.Visible = false;
            string[] lista_de_Provincias = File.ReadAllLines(Server.MapPath("/ficheros/provincias.csv"));
            foreach (string provincia in lista_de_Provincias)
            {
                Provincias.Items.Add(new ListItem(provincia.Split(';')[1]));
            }
            if (IsPostBack)
            {
                prov_sel = Provincias.SelectedItem;
                BusquedasPersonalizadas();
            }
        }

        private void BusquedasPersonalizadas()
        {
            
        }

        protected void BAceptar_Click(object sender, EventArgs e)
        {
            BusquedaRefinada.Visible = true;
            prov.Visible = false;
        }
    }
}