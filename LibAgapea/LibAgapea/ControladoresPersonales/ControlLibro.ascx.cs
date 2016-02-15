using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibAgapea.App_Code.Modelo;

namespace LibAgapea.ControladoresPersonales
{
    public partial class ControlLibro : System.Web.UI.UserControl
    {
        #region "atributos"
        private string titulo;
        private string autor;
        private string editorial;
        private string isbn;
        private decimal precio;
        #endregion
        #region "get y sets"
        public string tituloLibro
        {
            get { return this.titulo; }
            set
            {
                this.titulo = value;
                this.LBtnTitulo.Text = this.titulo;
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

        public string autorLibro
        {
            get { return this.autor; }
            set
            {
                this.autor = value;
                this.LabelAutor.Text = this.autor;
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
                this.LabelPrecio.Text = this.precio.ToString();
            }
        }
        #endregion

        #region ".......metodos de clase......."

        public ControlLibro() { }
        public ControlLibro(Libro unLibro)
        {
            this.tituloLibro = unLibro.titulo;
            this.editorialLibro = unLibro.editorial;
            this.autorLibro = unLibro.autor;
            this.isbnLibro = unLibro.ISBN10;
            this.precioLibro = unLibro.precio;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}