using System;
using System.Collections.Generic;

namespace ToysConsoleApp1.Models
{
    public partial class ToysDetails
    {
        public ToysDetails()
        {
            Orders = new HashSet<Orders>();
        }

        public int ToyId { get; set; }
        public string ToyType { get; set; }
        public int ToyPrice { get; set; }
        public int PlantId { get; set; }

        public virtual Plants Plant { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
