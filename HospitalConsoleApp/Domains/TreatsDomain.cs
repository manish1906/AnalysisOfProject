using System;
using System.Collections.Generic;
using System.Text;
using HospitalConsoleApp.Models;
using System.Linq;

namespace HospitalConsoleApp.Domains
{
    class TreatsDomain:HospitalDBContext
    {
        public void AssignTreat(Treats treats)
        {
            Console.WriteLine("Enter Doctor Id");
            treats.DoctorId =Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Enter Patient Id");
            treats.PatientId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Deparment Id");
            treats.DepartmentId = Convert.ToInt32(Console.ReadLine());
            Treats.Add(treats);
            SaveChanges();


        }
        public List<VTreat> GetVTreats()
        {
             
            return VTreat.ToList();
        }


    }
}
