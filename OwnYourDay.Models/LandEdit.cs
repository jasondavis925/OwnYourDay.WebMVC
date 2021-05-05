using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnYourDay.Models
{
    public class LandEdit
    {
        public int LandId { get; set; }

        public int PropertyDescription { get; set; }

        public string Location { get; set; }

        public string Occupancy { get; set; }

        public string Activities { get; set; }
    }
}
