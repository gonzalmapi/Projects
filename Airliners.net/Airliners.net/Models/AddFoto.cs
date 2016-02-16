using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;

namespace Airliners.net.Models
{ 
    [Serializable]
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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime date { get; set; }

        [Required(ErrorMessage = "Name required")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Photo Name required")]
        [Display(Name = "Photo Name")]
        public string photo { get; set; }

        [Display(Name = "Notes")]
        public string notes { get; set; }
    }
}