using System;
using System.Collections.Generic;

namespace HospitalConsoleApp.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Assistants = new HashSet<Assistants>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Assistants> Assistants { get; set; }
    }
}
