using System;
using System.Collections.Generic;
using System.Text;
using HospitalConsoleApp.Models;
using System.Linq;

namespace HospitalConsoleApp.Domains
{
    class AppointmentDomain:HospitalDBContext
    {

        public void BookAppontment(Appointments appointments)
        {

            Console.WriteLine("Enter Patient Id:");
            appointments.PatientId =Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Enter Doctor ID");
            appointments.DoctorId = Convert.ToInt32(Console.ReadLine()) ;
            Console.WriteLine("Enter Appointment date time");
            appointments.AppointDateTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Description");
            appointments.Description = Console.ReadLine();
            Appointments.Add(appointments);
            SaveChanges();



        }

        public List<Appointments> GetAppointmentsDetails()
        {
            return Appointments.ToList();
        
        }



    }
}
