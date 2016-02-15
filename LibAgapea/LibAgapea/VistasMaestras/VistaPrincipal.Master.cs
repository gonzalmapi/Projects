using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibAgapea.App_Code.Controlador;


namespace LibAgapea.VistasMaestras
{
    public partial class VistaPrincipal : System.Web.UI.MasterPage
    {
        private Controlador_Inicio inicio = new Controlador_Inicio();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                cargarTreeview(inicio.recuperarCat());
            }
        }

         private void cargarTreeview(Dictionary<string, List<string>>datos)
        {
            List<string> categorias = datos.Keys.ToList();

            foreach (string cat in categorias)
            {
                TreeView1.Nodes.Add(new TreeNode() { Text = cat, Value = "Categoria:" + cat });
            }

    categorias.ForEach(delegate (String cat)
            {
                datos[cat].ForEach(subcategoria => TreeView1.FindNode("Categoria:" + cat).ChildNodes.Add(new TreeNode() { Text = subcategoria, Value = "Subcategoria:" + subcategoria }));
            });          
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/Login.aspx");
        }
    }
}