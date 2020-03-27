using System;
using System.Collections.Generic;

namespace Company.Models
{
    public partial class VProjectDetails
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set;}
        public string Manager { get; set; }
        public string UnitName { get; set; }
    }
}
