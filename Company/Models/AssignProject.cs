using System;
using System.Collections.Generic;

namespace Company.Models
{
    public partial class AssignProject
    {
        public int AssignId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Projects Project { get; set; }
    }
}
