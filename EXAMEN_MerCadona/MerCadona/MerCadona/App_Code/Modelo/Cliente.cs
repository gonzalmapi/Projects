using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerCadona.App_Code.Modelo
{
    public class Cliente
    {
        public String nombre { get; set; }
        public String apellido1 { get; set; }
        public String apellido2 { get; set; }
        public String tipoID { get; set; }
        public String ID { get; set; }
        public Boolean publi { get; set; }
        public String email { get; set; }
        public String dia { get; set; }
        public String mes { get; set; }
        public String anyo { get; set; }
        public String telefono {get;set;}
                
    }
}