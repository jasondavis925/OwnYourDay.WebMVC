using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnYourDay.Models
{
    public class PersonCreate
    {
        [Required]
        [Display(Name = "Number of Adults")]
        [Range(1,100, ErrorMessage = "Please enter at least 1 adult.")]
        public int AdultCount { get; set; }

        [Required]
        [Display(Name = "Number of Children")]
        [Range(1, 100, ErrorMessage = "Please enter 0 for no children.")]
        public int ChildCount { get; set; }

        [Required]
        [Display(Name = "User Email Address")]
        public string Email { get; set; }

        [Display(Name = "Destination")]
        [MaxLength(200)]
        public string Destination { get; set; }

        [Display(Name = "Mode of Travel")]
        [MaxLength(200)]
        public string TravelMode { get; set; }
    }
}
