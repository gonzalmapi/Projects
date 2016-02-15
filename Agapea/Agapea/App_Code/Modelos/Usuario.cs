using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agapea.App_Code.Controladores;


namespace Agapea.App_Code.Modelos
{
    public class Usuario
    {
             
        public String alias { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String email { get; set; }
        public String contraseña { get; set; }

    }
   }