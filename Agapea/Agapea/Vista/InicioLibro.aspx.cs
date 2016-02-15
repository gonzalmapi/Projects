using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea.App_Code.Controladores;
using Agapea.App_Code.Modelos;
namespace Agapea.Vista
{
    public partial class InicioLibro : System.Web.UI.Page
    {
        private Dictionary<String, Libro> coleccionLibros;
        private TableCell Celda (Libro lib)
        {
            LinkButton lblTitulo = new LinkButton();
            lblTitulo.Text = lib.titulo;
            lblTitulo.Font.Bold = true;
            lblTitulo.ForeColor = System.Drawing.Color.Red;
            lblTitulo.Font.Size = FontUnit.XLarge;
            Label lblAutor = new Label();
            lblAutor.Text = lib.autor;
            Label lblEditorial = new Label();
            lblEditorial.Text = lib.editorial;
            Label lblIsbn = new Label();
            lblAutor.Text = "ISBN10:" + lib.isbn10 + " ----  ISBN13:" + lib.isbn13 + "   ";
            Label lblPrecio = new Label();
            lblPrecio.Text = lib.precio;
            Label lblPaginas = new Label();
            lblPaginas.Text = lib.paginas;
            ImageButton botonComprar = new ImageButton(); botonComprar.ImageUrl = "~/Vista/imagenes/botoncomprar.png";

            TableCell newcell = new TableCell();
            newcell.Controls.Add(lblTitulo);
            newcell.Controls.Add(new LiteralControl("<br>"));
            newcell.Controls.Add(lblAutor);
            newcell.Controls.Add(new LiteralControl("<br>"));
            newcell.Controls.Add(lblEditorial);
            newcell.Controls.Add(new LiteralControl("<br>"));
            newcell.Controls.Add(lblIsbn);
            newcell.Controls.Add(new LiteralControl("<br>"));
            newcell.Controls.Add(lblPrecio);
            newcell.Controls.Add(new LiteralControl("<br>"));
            newcell.Controls.Add(lblPaginas);
            newcell.Controls.Add(botonComprar);
            newcell.Controls.Add(new LiteralControl("<br>"));

            return newcell;
        }
        private void DibujaTabla(Libro[] libros)
        {
            int contaceldas = 0;

            foreach (Libro unlibro in libros)
            {
                if (contaceldas % 3 == 0)
                {
                    TableRow nuevafila = new TableRow();
                    Tabla.Rows.Add(nuevafila);
                }
                ((TableRow)Tabla.Rows[Tabla.Rows.Count - 1]).Cells.Add(Celda(unlibro));
                contaceldas++;
            }

        }
        private void CargaTreeView(Dictionary<String, List<String>> datos)
        {
            datos.Keys.ToList().ForEach(valor => TreeView1.Nodes.Add(new TreeNode() { Text = valor, Value = "categoria:" + valor })); //...asi creamos los nodos principales
            datos.Keys.ToList().ForEach(delegate (String cat)
            {
                datos[cat].ForEach(subcategoria => TreeView1.FindNode("categoria:" + cat).ChildNodes.Add(new TreeNode() { Text = subcategoria, Value = "subcategoria:" + subcategoria }));
            }); //...asi añadimos las subcategorias a cada nodo del treeview que representa una categoria...

        }
        protected void BotonBusqueda_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("~/Vista/BusquedaLibro.aspx");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Controlador_Vista_Inicio micontrol = new Controlador_Vista_Inicio();
            coleccionLibros = micontrol.RecuperarLibrosMasVendidos();

            if (!this.IsPostBack)
            {  //cuando no hay postback es la 1º vez que se carga la pagina y dibujamos todos los libros...
                DibujaTabla(coleccionLibros.Values.ToArray());
                CargaTreeView(micontrol.RecuperarCatySub());
            }
            else
            { //hay postback, no es la 1º vez que se carga la pagina pq ha habido algun evento sobre algun componente de la pagina...detectamos si es del treeview
                switch (this.Request.Params.GetValues("__EVENTTARGET")[0])
                {
                    case "TreeView1": //lo ha provocado un nodo del treeview, viendo el __EVENTARGUMENTS se si es una categoria o una subcategoria:
                        string valueNodoTreeview = this.Request.Params.GetValues("__EVENTARGUMENT")[0].ToString();
                        Libro[] LibrosCat = valueNodoTreeview.Contains("subcategoria") ? micontrol.BuscarLibrosCategoria("subcategoria", valueNodoTreeview.Split(new char[] { ':' })[2]) : micontrol.BuscarLibrosCategoria("categoria", valueNodoTreeview.Split(new char[] { ':' })[1]);
                        DibujaTabla(LibrosCat);
                        break;
                };


            };

        }
    }
           
    }
