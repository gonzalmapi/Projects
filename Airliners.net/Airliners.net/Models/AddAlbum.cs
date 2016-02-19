using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Airliners.net.Models
{
    public class AddAlbum
    {
        [Required(ErrorMessage = "Photo Name required")]
        [Display(Name = "Photo Name")]
        public string photo { get; set; }

        [Required(ErrorMessage = "Name required")]
        [Display(Name = "Name and Surname")]
        public string name { get; set; }
    }
}