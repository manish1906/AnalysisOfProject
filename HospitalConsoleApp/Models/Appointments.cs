using System;
using System.Collections.Generic;

namespace HospitalConsoleApp.Models
{
    public partial class Appointments
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointDateTime { get; set; }
        public string Description { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
