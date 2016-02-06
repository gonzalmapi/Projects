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
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}")]
       // [RegularExpression("^(?:(?:0?[1-9]|1\\d|2[0-8])(\\/|-)(?:0?[1-9]|1[0-2]))(\\/|-)(?:[1-9]\\d\\d\\d|\\d[1-9]\\d\\d|\\d\\d[1-9]\\d|\\d\\d\\d[1-9])$|^(?:(?:31(\\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\\/|-)(?:0?[1,3-9]|1[0-2])))(\\/|-)(?:[1-9]\\d\\d\\d|\\d[1-9]\\d\\d|\\d\\d[1-9]\\d|\\d\\d\\d[1-9])$|^(29(\\/|-)0?2)(\\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\\d\\d)?(?:0[48]|[2468][048]|[13579][26]))$", ErrorMessage = "Format invalid")]
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