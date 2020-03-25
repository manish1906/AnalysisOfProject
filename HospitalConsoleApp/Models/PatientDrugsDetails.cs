using System;
using System.Collections.Generic;

namespace HospitalConsoleApp.Models
{
    public partial class PatientDrugsDetails
    {
        public int PatientId { get; set; }
        public int MorningDrugId { get; set; }
        public int AfternoonDrugId { get; set; }
        public int EveningId { get; set; }

        public virtual DrugsDetails AfternoonDrug { get; set; }
        public virtual DrugsDetails Evening { get; set; }
        public virtual DrugsDetails MorningDrug { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
