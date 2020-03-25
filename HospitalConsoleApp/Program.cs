using System;
using HospitalConsoleApp.Domains;
using HospitalConsoleApp.Models;
namespace HospitalConsoleApp
{
    class Program
    {
        public static int i;
        static void Main(string[] args)
        {
            Patients patients = new Patients();
            PatientDomain patientDomain = new PatientDomain();
            Doctors doctors = new Doctors();
            DoctorDomain doctorDomain = new DoctorDomain();
            
          
            //  
            Console.WriteLine("----------------Hospital----------");
            int choice;
            do
            {
                Console.WriteLine("\n======= Menu =======");
                Console.WriteLine("1.Get Patients Details");
                Console.WriteLine("2.Add Patient Details");
                Console.WriteLine("3.Delete Patient Details");
                Console.WriteLine("4.Get Doctor Details");
                Console.WriteLine("5.Add Doctor Details");
                Console.WriteLine("6.Delete Doctor Details");
                


                Console.WriteLine("7.Exit");

                Console.Write("\n Enter Your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(" -----------Get movies details -----------");
                        Console.WriteLine("PatientId \t PatientName\tPatientAddres\tPatientMobNumber\tPatientAge\tPatientGender\tPatientDeaseas");
                        foreach (Patients patients1 in patientDomain.GetPatientData())
                        {

                            Console.WriteLine($"{patients1.PatientId}\t{patients1.PatientName}  \t{patients1.PatientAddres}  \t{patients1.PatientMobNumber}  \t{patients1.PatientAge}  \t{patients1.PatientGender}   \t{patients1.PatientDeaseas} ");
                        }
                        break;
                    case 2:
                        Console.WriteLine(" -----------Add Patient Details -----------");
                        patientDomain.AddPatient(patients);
                        break;
                    case 3:
                        Console.WriteLine(" -----------Delete Patient Details -----------");
                        patientDomain.DeletePatient(patients);
                        break;
                    case 4:
                        Console.WriteLine(" -----------Get Doctor details -----------");
                        Console.WriteLine("DoctorId \tDoctorName\t DocorGender\tDoctorAge\tQualification\tExperience");
                        foreach (Doctors doctors1 in doctorDomain.GetDoctorsData())
                        {

                            Console.WriteLine($"{doctors1.DoctorId}         \t{doctors1.DoctorName}\t  {doctors1.DocorGender}     \t{doctors1.DoctorAge}       \t{doctors1.Qualification}    \t{doctors1.Experience}  ");
                        }
                        break;
                    case 5:
                        Console.WriteLine(" -----------Add Doctor Details -----------");
                        doctorDomain.AddDoctor(doctors);
                        break;
                    case 6:
                        Console.WriteLine(" -----------Delete Doctor Details -----------");
                        doctorDomain.DeleteDoctor(doctors);
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine(" Your Choice Is Wrong");
                        break;
                }
            } while (i > -1);
        }
    }
}
