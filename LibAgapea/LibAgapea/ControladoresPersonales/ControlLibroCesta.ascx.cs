using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibAgapea.App_Code.Modelo;

namespace LibAgapea.ControladoresPersonales
{
    public partial class ControlLibroCesta : System.Web.UI.UserControl
    {
        #region ".......propiedades de mi control......."
        private string titulo;
        private decimal precioUnidad;
        private decimal precioTotalLibro;
        private int cantidad;

        public string tituloLibro
        {
            get { return this.titulo; }
            set
            {
                this.titulo = value;
                this.linkButton_Titulo.Text = this.titulo;
            }
        }
        public decimal precioLibro
        {
            get { return this.precioUnidad; }
            set
            {
                this.precioUnidad = value;
                this.label_PrecioUnidad.Text = this.precioUnidad.ToString() + "€";
            }
        }

        public decimal precioTotal
        {
            get { return this.precioTotalLibro; }
            set
            {
                this.precioTotalLibro = value;
                this.label_PrecioTotal.Text = this.precioTotalLibro.ToString() + "€";
            }
        }

        public int CantidadLibros
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                this.label_Cantidad.Text = cantidad.ToString();
            }
        }

        #endregion

        #region ".......metodos de clase......."

        public ControlLibroCesta() { }

        public ControlLibroCesta(Libro libro)
        {
            this.tituloLibro = libro.titulo;
            this.precioLibro = libro.precio;
            this.precioTotal = libro.precio * Convert.ToDecimal(label_Cantidad);
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}