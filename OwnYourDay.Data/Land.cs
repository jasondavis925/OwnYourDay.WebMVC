using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnYourDay.Data
{
    public class Land
    {
        [Key]
        public int LandId { get; set; }

        [ForeignKey(nameof(Owner))]
        public int? ProspectId { get; set; }
        public virtual Person Owner { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string PropertyDescription { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int Occupancy { get; set; }

        [Required]
        public string Activities { get; set; }
    }
}
