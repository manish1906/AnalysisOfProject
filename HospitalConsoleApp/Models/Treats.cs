using System;
using System.Collections.Generic;

namespace HospitalConsoleApp.Models
{
    public partial class Treats
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
