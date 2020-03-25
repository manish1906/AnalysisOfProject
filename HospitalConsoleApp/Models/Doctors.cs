using System;
using System.Collections.Generic;

namespace HospitalConsoleApp.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Appointments = new HashSet<Appointments>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DocorGender { get; set; }
        public int DoctorAge { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
    }
}
