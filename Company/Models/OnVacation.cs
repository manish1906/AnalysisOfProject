using System;
using System.Collections.Generic;

namespace Company.Models
{
    public partial class OnVacation
    {
        public int VacationId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
