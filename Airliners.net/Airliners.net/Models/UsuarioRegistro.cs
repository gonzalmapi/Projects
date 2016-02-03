using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Airliners.net.Models
{
    public class UsuarioRegistro
    {
        [Required(ErrorMessage = "Email required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [RegularExpression(@"^([\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+\.)*[\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$", ErrorMessage = "Format invalid")]
        public string email { get; set; }

        [Required(ErrorMessage = "Username required")]
        [Display(Name = "User name")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "RePassword required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string confPassword { get; set; } 

        [Required(ErrorMessage = "Name required")]
        [Display(Name = "Name and Surname")]
        public string name { get; set; }

        [Required(ErrorMessage = "Age required")]
        [Display(Name = "Age")]
        public int age { get; set; }

        [Required(ErrorMessage = "Country required")]
        [Display(Name = "Country")]
        public string country { get; set; }

        [Required(ErrorMessage = "City required")]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required(ErrorMessage = "Gender required")]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Display(Name = "Occupation")]
        public string occupation { get; set; }

        [Display(Name = "Hobbies")]
        public string hobbies { get; set; }

        [Display(Name = "Personal Homepage")]
        [RegularExpression("^(https ?://)?(([\\w!~*'().&=+$%-]+: )?[\\w!~*'().&=+$%-]+@)?(([0-9]{1,3}\\.){3}[0-9]{1,3}|([\\w!~*'()-]+\\.)*([\\w^-][\\w-]{0,61})?[\\w]\\.[a-z]{2,6})(:[0-9]{1,4})?((/*)|(/+[\\w!~*'().;?:@&=+$,%#-]+)+/*)$")]
        public string url_personal { get; set; }

        [Display(Name = "Other Information")]
        public string other { get; set; }
    }
}