using System;
using System.Collections.Generic;

namespace Company.Models
{
    public partial class BussinessUnits
    {
        public BussinessUnits()
        {
            Projects = new HashSet<Projects>();
        }

        public int BussinessUnitId { get; set; }
        public string UnitName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Projects> Projects { get; set; }
    }
}
