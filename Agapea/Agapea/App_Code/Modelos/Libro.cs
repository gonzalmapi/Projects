using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agapea.App_Code.Modelos
{
    public class Libro
    {
        public String titulo { get; set; }
        public String autor { get; set; }
        public String editorial { get; set; }
        public String categoria { get; set; }
        public String isbn10 { get; set; }
        public String isbn13 { get; set; }
        public String precio { get; set; }
        public String paginas { get; set; }
        public String subcategoria { get; set; }
    }
}