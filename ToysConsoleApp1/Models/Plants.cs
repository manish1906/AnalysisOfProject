using System;
using System.Collections.Generic;

namespace ToysConsoleApp1.Models
{
    public partial class Plants
    {
        public Plants()
        {
            ToysDetails = new HashSet<ToysDetails>();
        }

        public int PlantId { get; set; }
        public string PlanName { get; set; }

        public virtual ICollection<ToysDetails> ToysDetails { get; set; }
    }
}
