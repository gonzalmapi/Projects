using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibAgapea.App_Code.Modelo
{
    public class Usuario
    {
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String email { get; set; }
        public String alias { get; set; }
        public String password { get; set; }
        public Dictionary<string, List<Carro>> Compras { get; set; }
      }
}