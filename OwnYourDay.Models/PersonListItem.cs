using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnYourDay.Models
{
    public class PersonListItem
    {
        public int PersonId { get; set; }

        [Display(Name ="Number of adults in family")]
        public int AdultCount { get; set; }

        [Display(Name = "Number of children in family")]
        public int ChildCount { get; set; }

        [Display(Name = "User email address")]
        public string Email { get; set; }

        [Display(Name = "Requested travel destination")]
        public string Destination { get; set; }

        [Display(Name = "Requested mode of travel")]
        public string TravelMode { get; set; }

    }
}
