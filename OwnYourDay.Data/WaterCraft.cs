using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnYourDay.Data
{
    public class WaterCraft
    {
        [Key]
        public int WaterCraftId { get; set; }

        [ForeignKey(nameof(Owner))]
        public int? ProspectId { get; set; }
        public virtual Person Owner { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int OccupancyCount { get; set; }

        [Required]
        public string VehicleMake { get; set; }

        [Required]
        public string VehicleModel { get; set; }

        [Required]
        public string Captain { get; set; }

    }
}
