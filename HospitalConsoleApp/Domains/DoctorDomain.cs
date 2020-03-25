using System;
using System.Collections.Generic;
using System.Text;
using HospitalConsoleApp.Models;
using System.Linq;

namespace HospitalConsoleApp.Domains
{
    class DoctorDomain:HospitalDBContext
    {
        public void AddDoctor(Doctors doctors)
        {

            Console.WriteLine("Enter Doctor Name");
            doctors.DoctorName = Console.ReadLine();
            Console.WriteLine("Enter Doctor Gender");
            doctors.DocorGender = Console.ReadLine();
            Console.WriteLine("Enter Doctor Age");
            doctors.DoctorAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Doctor Qualification");
            doctors.Qualification = Console.ReadLine();
            Console.WriteLine("Enter Doctor Experince");
            doctors.Experience = Convert.ToInt32(Console.ReadLine());
            
           

            Doctors.Add(doctors);
            SaveChanges();


        }
        public void DeleteDoctor(Doctors doctors)
        {

            Console.WriteLine("Enter Doctor Id");
            doctors.DoctorId = Convert.ToInt32(Console.ReadLine());

            Doctors.Remove(doctors);
            SaveChanges();

        }

        public List<Doctors> GetDoctorsData()
        {

            return Doctors.ToList();
        }
    }
}
