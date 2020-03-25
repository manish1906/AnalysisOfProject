using System;
using System.Collections.Generic;

namespace HospitalConsoleApp.Models
{
    public partial class Assistants
    {
        public int AssistantId { get; set; }
        public string AssistantName { get; set; }
        public string AssistantGender { get; set; }
        public int AssistantAge { get; set; }
        public int DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
    }
}
