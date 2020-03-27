using System;
using System.Collections.Generic;

namespace Company.Models
{
    public partial class Projects
    {
        public Projects()
        {
            AssignProject = new HashSet<AssignProject>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public int AssignManager { get; set; }
        public int BussinessId { get; set; }

        public virtual BussinessUnits Bussiness { get; set; }
        public virtual ICollection<AssignProject> AssignProject { get; set; }
    }
}
