using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibAgapea.App_Code.Controlador;
using LibAgapea.App_Code.Modelo;
using LibAgapea.ControladoresPersonales;
using System.Collections.Specialized;

namespace LibAgapea.Vistas
{
    public partial class Index : System.Web.UI.Page
    {
        private Controlador_Inicio control = new Controlador_Inicio();
        private void Dibuja_Tabla(List<Libro> librosAPintarList, string tipo_Control)
        {
            for (int i = 0; i < 3; i++)
            {
                TableLibros.Rows.Add(new TableRow());

                for (int k = 0; k < 3 && librosAPintarList.Count() - 1 >= i * 3 + k; k++)
                {
                    TableLibros.Rows[i].Cells.Add(new TableCell());
                    Libro libro = librosAPintarList.ElementAt(i * 3 + k);

                    switch (tipo_Control)
                    {
                        case "control_Libro":
                            ControlLibro unLibro;
                            unLibro = (ControlLibro)LoadControl("~/ControladoresPersonales/ControlLibro.ascx");
                            unLibro.tituloLibro = libro.titulo;
                            unLibro.autorLibro = libro.autor;
                            unLibro.editorialLibro = libro.editorial;
                            unLibro.precioLibro = libro.precio;
                            unLibro.isbnLibro = libro.ISBN10;
                            TableLibros.Rows[i].Cells[k].Controls.Add(unLibro);
                            unLibro.FindControl("LBtnTitulo").ID += unLibro.isbnLibro;
                            unLibro.FindControl("BtnComprar").ID += "$" + unLibro.isbnLibro;
                            break;
                        case "detalles_Libro":
                            ControlLibroDetalles detallesLibroSelecc;
                            detallesLibroSelecc = (ControlLibroDetalles)LoadControl("~/ControladoresPersonales/ControlLibroDetalles.ascx");
                            detallesLibroSelecc.tituloLibro = libro.titulo;
                            detallesLibroSelecc.autorLibro = libro.autor;
                            detallesLibroSelecc.editorialLibro = libro.editorial;
                            detallesLibroSelecc.isbnLibro = libro.ISBN10;
                            detallesLibroSelecc.precioLibro = libro.precio;
                            detallesLibroSelecc.resumenLibro = libro.resumen;
                            TableLibros.Rows[i].Cells[k].Controls.Add(detallesLibroSelecc);
                            break;
                    }

                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            /*if (!this.IsPostBack)
            {
                List<Libro> todosLosLibros = control.listaLibrosRecuperados();
                Dibuja_Tabla(todosLosLibros, "control_Libro");
            }*/
            NameValueCollection coleccionCookies_userInfo;

            HttpCookie cookie = Request.Cookies["userInfo"];

            if (cookie == null)
            {
                HttpCookie miCookie = new HttpCookie("userInfo");
                miCookie.Values["nombreUsu"] = "anonymous";
                miCookie.Values["IP"] = Context.Request.ServerVariables["REMOTE_ADDR"];
                miCookie.Values["ultimaVisita"] = DateTime.Now.ToString();
                miCookie.Expires = DateTime.MinValue;
                Response.Cookies.Add(miCookie);
            }

            if (!this.IsPostBack)
            {
                List<Libro> todosLosLibros = control.listaLibrosRecuperados();
                Dibuja_Tabla(todosLosLibros, "control_Libro");

                if (!Request.Cookies["userInfo"].Values["nombreUsu"].Equals("anonymous"))
                {
                    cambiaCabecera();
                }

                if (Request.Cookies["userInfo"].Values["isbn_LibrosAComprar"] != null)
                {

                    List<string> isbnsAContar = Request.Cookies["userInfo"].Values["isbn_LibrosAComprar"].Split(new char[] { '$' }).ToList();
                    int cantidad = recuperaCantidad(isbnsAContar);

                    Button cesta = (Button)this.Master.FindControl("btnMiCesta");
                    if (cesta != null)
                    {
                        cesta.Visible = true;
                        cesta.Text += " " + cantidad;
                    }
                }
            }
            else
            {

                foreach (string clave in Request.Params.AllKeys)
                {
                    if (clave.Contains("BtnComprar") && clave.EndsWith(".x"))
                    {
                        string isbnLibroAComprar = clave.Split(new char[] { '$' })[4].Replace(".x", "");
                        HttpCookie miCookie = Request.Cookies["userInfo"];
                        miCookie.Values["isbn_LibrosAComprar"] += "$1$" + isbnLibroAComprar;
                        Response.Cookies.Add(miCookie);

                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                        List<string> isbns = coleccionCookies_userInfo["isbn_LibrosAComprar"].Split(new char[] { '$' }).ToList();
                        string isbns_puros = coleccionCookies_userInfo["isbn_LibrosAComprar"].ToString();

                        foreach (string isbnBuscado in isbns)
                        {
                            if (isbnBuscado == isbnLibroAComprar)
                            {
                                miCookie.Values["isbn_LibrosAComprar"] = modificarCookie(isbns_puros, isbnLibroAComprar);
                                Response.Cookies.Add(miCookie);
                            }
                        }

                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                        this.Response.Redirect("Compras.aspx?usuario=" + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper() + "$libro=" + Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]));

                    }

                    if (clave.Contains("btnBuscar"))
                    {
                        TextBox libroABuscar = (TextBox)this.Master.FindControl("TBBuscador");
                        List<Libro> librosRecuperados = new List<Libro>();

                        if (libroABuscar != null)
                        {
                            string libroParaBuscar = libroABuscar.Text;
                            foreach (string param in Request.Params.AllKeys)
                            {
                                if (param.Contains("busqueda"))
                                {
                                    string radioButtonSelec = this.Request.Params.GetValues(param)[0].ToString().Split(new char[] { '_' })[1];
                                    librosRecuperados = control.recuperarLibrosPorParametro(radioButtonSelec, libroParaBuscar);
                                    Dibuja_Tabla(librosRecuperados, "control_Libro");

                                }
                            }
                        }
                    }

                    if (clave.Contains("btnMiCesta"))
                    {
                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                        this.Response.Redirect("Compras.aspx?usuario=" + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper() + "$libro=" + Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]));
                    }



                    if (clave == ("__EVENTTARGET"))
                    {
                        string valor = this.Request.Params[clave];

                        if (valor.Contains("TreeView1"))
                        {
                            string nodoTreeViewSeleccionado = this.Request.Params.GetValues("__EVENTARGUMENT")[0].ToString();
                            List<Libro> librosCategoriaSeleccionada = nodoTreeViewSeleccionado.Contains("Subcategoria") ? control.recuperarLibrosPorParametro("Subcategoria", nodoTreeViewSeleccionado.Split(new char[] { ':' })[2]) : control.recuperarLibrosPorParametro("Categoria", nodoTreeViewSeleccionado.Split(new char[] { ':' })[1]);
                            Dibuja_Tabla(librosCategoriaSeleccionada, "control_Libro");
                        }

                        if (valor.Contains("LBtnTitulo"))
                        {
                            string isbnLibroSeleccionado = this.Request.Params.GetValues("__EVENTTARGET")[0].Split(new char[] { '$' })[3].Replace("LBtnTitulo", "");
                            List<Libro> libroRecuperado = control.recuperarLibrosPorParametro("ISBN", isbnLibroSeleccionado);
                            Dibuja_Tabla(libroRecuperado, "detalles_Libro");
                        }

                        if (valor.Contains("LinkButton1"))
                        {
                            coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                            if (coleccionCookies_userInfo["isbn_LibrosAComprar"] != null)
                            {
                                this.Response.Redirect("Login.aspx?usuario=" + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper() + "$libro=" + Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]));
                            }
                            else
                            {
                                this.Response.Redirect("Login.aspx?usuario=" + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper());
                            }


                        }

                    }

                }


            }

        }

        public string modificarCookie(string isbns_puros, string isbnsASumar)
        {
            string cookieModificada = "";
            string parteSuma = "";

            int contador = 0;

            List<string> isbnsList = isbns_puros.Split(new char[] { '$' }).ToList();

            List<string> listaModificada = new List<string>();


            for (int i = 0; i < isbnsList.Count; i++)
            {
                if (isbnsList[i].ToString() != "")
                {

                    if (i % 2 == 0)
                    {
                        if (isbnsList[i].ToString() == isbnsASumar)
                        {
                            contador++;
                            parteSuma = "$" + contador + "$" + isbnsList[i].ToString();
                        }
                        else
                        {
                            cookieModificada += "$" + isbnsList[i - 1].ToString() + "$" + isbnsList[i].ToString();
                        }
                    }
                }
            }
            cookieModificada += parteSuma;
            return cookieModificada;
        }

        public void cambiaCabecera()
        {
            NameValueCollection coleccionCookies_userInfo;

            LinkButton acceso = (LinkButton)this.Master.FindControl("linkButton_AccesoCuenta");
            if (acceso != null)
            {
                acceso.Visible = false;
            }

            if (Request.Cookies["userInfo"] != null)
            {
                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                Label labelUsu = (Label)this.Master.FindControl("Label1");
                if (labelUsu != null)
                {
                    labelUsu.Visible = true;
                    labelUsu.Text = labelUsu.Text + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]);
                }

            }
        }

        public int recuperaCantidad(List<string> isbnsAContar)
        {
            int cantidad = 0;

            NameValueCollection coleccionCookies_userInfo;

            if (Request.Cookies["userInfo"] != null)
            {
                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                for (int i = 0; i < isbnsAContar.Count; i++)
                {
                    if (isbnsAContar[i].ToString() != "")
                    {
                        if (i % 2 == 1)
                        {
                            cantidad += Convert.ToInt32(isbnsAContar[i]);
                        }
                    }
                }
            }
            return cantidad;
        }
    }
}
    
