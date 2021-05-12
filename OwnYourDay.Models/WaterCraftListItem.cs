using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnYourDay.Models
{
    public class WaterCraftListItem
    {
        public int WaterCraftId { get; set; }

        public int OccupancyCount { get; set; }

        public string VehicleMake { get; set; }

        public string VehicleModel { get; set; }

        public string Captain { get; set; }
    }
}
