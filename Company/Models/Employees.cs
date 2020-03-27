using System;
using System.Collections.Generic;

namespace Company.Models
{
    public partial class Employees
    {
        public Employees()
        {
            AssignProject = new HashSet<AssignProject>();
            OnVacation = new HashSet<OnVacation>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int MobileNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<AssignProject> AssignProject { get; set; }
        public virtual ICollection<OnVacation> OnVacation { get; set; }
    }
}
