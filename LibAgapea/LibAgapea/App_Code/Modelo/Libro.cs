using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibAgapea.App_Code.Modelo
{
    public class Libro
    {
        public string titulo { get; set; }
        public string autor { get; set; }
        public string editorial { get; set; }
        public string categoria { get; set; }
        public string subcategoria { get; set; }
        public string ISBN10 { get; set; }
        public string ISBN13 { get; set; }
        public decimal precio { get; set; }
        public string paginas { get; set; }
        public string resumen { get; set; }
        public int cantidad { get; set; }
    }
}