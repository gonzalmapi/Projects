using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Airliners.net.Models
{
    public class UsuarioLogin
    {
        [Required(ErrorMessage = "Username Requiered")]
        [Display(Name = "Login")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }
    }
}