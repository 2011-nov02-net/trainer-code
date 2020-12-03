using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleOrderApp.WebApp.ViewModels
{
    public class LocationViewModel
    {
        [Display(Name = "Location Name")]
        [Required, RegularExpression("[A-Z].*")]
        public string Name { get; set; }

        [Range(0, 99999)]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [Required]
        public int Stock { get; set; }
    }
}
