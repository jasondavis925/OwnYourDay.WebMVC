﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnYourDay.Models
{
    public class LandListItem
    {
        public int LandId { get; set; }

        public int PropertyDescription { get; set; }

        public string Location { get; set; }

        public string Occupancy { get; set; }

        public string Activities { get; set; }
    }
}
