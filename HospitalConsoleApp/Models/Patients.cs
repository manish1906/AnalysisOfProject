using System;
using System.Collections.Generic;

namespace HospitalConsoleApp.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Appointments = new HashSet<Appointments>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientAddres { get; set; }
        public long PatientMobNumber { get; set; }
        public int PatientAge { get; set; }
        public string PatientGender { get; set; }
        public string PatientDeaseas { get; set; }

       public virtual ICollection<Appointments> Appointments { get; set; }
    }
}
