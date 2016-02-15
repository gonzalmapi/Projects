using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibAgapea.App_Code.Modelo
{
    public class Carro
    { 
        public List<string> idLibro { get; set; }
        public string fechaCompra { get; set; }
        public List<decimal> preciototal { get; set; }
        public Dictionary<string, List<Libro>> librosCompra { get; set; }
    }
}