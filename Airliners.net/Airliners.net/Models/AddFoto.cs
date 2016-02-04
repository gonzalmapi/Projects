using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;

namespace Airliners.net.Models
{
    public class AddFoto
    {
        [Required(ErrorMessage = "Airline required")]
        [Display(Name = "Airline")]
        public string airline { get; set; }

        [Required(ErrorMessage = "Airplane required")]
        [Display(Name = "Airplane")]
        public string airplane { get; set; }

        [Required(ErrorMessage = "Place required")]
        [Display(Name = "Place")]
        public string place { get; set; }

        [Required(ErrorMessage = "Date required")]
        [Display(Name = "Date")]
        public string date { get; set; }

        [Required(ErrorMessage = "User required")]
        [Display(Name = "User")]
        public string name { get; set; }

        [Required(ErrorMessage = "Photo required")]
        [Display(Name = "Photo")]
        public Binary photo { get; set; }

        [Display(Name = "Notes")]
        public string notes { get; set; }
    }
}