using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalConsoleApp.Models;
namespace HospitalConsoleApp.Domains
{
    class PatientDomain:HospitalDBContext
    {


        public void AddPatient(Patients patients)
        {

            Console.WriteLine("Enter Patient Id");
            patients.PatientName = Console.ReadLine();
            Console.WriteLine("Enter Patient Address");
            patients.PatientAddres = Console.ReadLine();
            Console.WriteLine("Enter Patient MobileNumber");
            patients.PatientMobNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Patient Age");
            patients.PatientAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Patient Gender");
            patients.PatientGender = Console.ReadLine();
            Console.WriteLine("Enter Patient Deaseas");
            patients.PatientDeaseas = Console.ReadLine();

            Patients.Add(patients);
            SaveChanges();


        }
        public void DeletePatient(Patients patients)
        {

            Console.WriteLine("Enter Patient Id");
            patients.PatientId=Convert.ToInt32 (Console.ReadLine());
           
            Patients.Remove(patients);
            SaveChanges();
        
        }
       
        public List<Patients> GetPatientData()
        {

            return Patients.ToList();
        }
    }
    
}
