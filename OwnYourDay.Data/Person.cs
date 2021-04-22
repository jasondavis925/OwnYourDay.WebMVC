using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnYourDay.Data
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
        
        [Required]
        
        public int AdultCount { get; set; }


        public int ChildCount { get; set; }
        
        [Required]

        public string Email { get; set; }
        
        [Required]

        public string Destination { get; set; }
        
        [Required]

        public string TravelMode { get; set; }
    }
}
