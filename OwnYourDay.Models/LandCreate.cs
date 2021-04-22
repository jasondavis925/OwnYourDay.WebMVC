using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnYourDay.Models
{
    public class LandCreate
    {
        [Required]
        public int PropertyDescription { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Occupancy { get; set; }

        [Required]
        public string Activities { get; set; }
    }
}
