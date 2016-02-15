using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibAgapea.App_Code.Modelo;

namespace LibAgapea.ControladoresPersonales
{
    public partial class ControlLibroDetalles : System.Web.UI.UserControl
    {
        #region ".......propiedades de mi control......."
        private string titulo;
        private string autor;
        private string editorial;
        private string isbn;
        private decimal precio;
        private string resumen;
        private string indice;

        public string tituloLibro
        {
            get { return this.titulo; }
            set
            {
                this.titulo = value;
                this.LinkButtonTitulo.Text = this.titulo;
            }
        }

        public string autorLibro
        {
            get { return this.autor; }
            set
            {
                this.autor = value;
                this.LabelAutor.Text = this.autor;
            }
        }

        public string editorialLibro
        {
            get { return this.editorial; }
            set
            {
                this.editorial = value;
                this.LabelEditorial.Text = this.editorial;
            }
        }


        public string isbnLibro
        {
            get { return this.isbn; }
            set
            {
                this.isbn = value;
                this.LabelISBN.Text = this.isbn;
            }
        }

        public decimal precioLibro
        {
            get { return this.precio; }
            set
            {
                this.precio = value;
                this.LabelPrecio.Text = this.precio.ToString() + "€";
            }
        }

        public string resumenLibro
        {
            get { return this.resumen; }
            set
            {
                this.resumen = value;
                this.LabelResumen.Text = this.resumen;
            }
        }
        #endregion

        #region ".......metodos de clase......."

        public ControlLibroDetalles() { }
        public ControlLibroDetalles(Libro unLibro)
        {
            this.tituloLibro = unLibro.titulo;
            this.autorLibro = unLibro.autor;
            this.editorialLibro = unLibro.editorial;
            this.isbnLibro = unLibro.ISBN10;
            this.precioLibro = unLibro.precio;
            this.resumenLibro = unLibro.resumen;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}