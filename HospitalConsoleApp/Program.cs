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
            Departments departments = new Departments();
            DepartmentDomain departmentDomain = new DepartmentDomain();
            Assistants assistants = new Assistants();
            AssistantDomain assistantDomain = new AssistantDomain();
            Treats treats = new Treats();
            TreatsDomain treatsDomain = new TreatsDomain();
            Appointments appointments = new Appointments();
            AppointmentDomain appointmentDomain = new AppointmentDomain();
            DrugsDetails drugsDetails = new DrugsDetails();
            DrugsDetailsDomain drugsDetailsDomain = new DrugsDetailsDomain();
            
          
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
                Console.WriteLine("7.Get Department Details");
                Console.WriteLine("8.Add Department ");
                Console.WriteLine("9.Delete Department ");
                Console.WriteLine("10.Get Assistant Details");
                Console.WriteLine("11.Add Assistant ");
                Console.WriteLine("12.Delete Assistant ");
                Console.WriteLine("13.Get Treatment Details");
                Console.WriteLine("14.Add Treartment ");
                
                Console.WriteLine("15.Book Appointment ");
                Console.WriteLine("16.Get AppointMent Details");
                Console.WriteLine("17.Get Drugs Details");
                Console.WriteLine("18.Add drug ");
                Console.WriteLine("19.Delete Drug ");


                Console.WriteLine("20.Exit");

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
                        Console.WriteLine(" -----------Get Department details -----------");
                        Console.WriteLine("Department ID \tDepartment Name");
                        foreach (Departments departments1 in departmentDomain.GetDepartments())
                        {

                            Console.WriteLine($"{departments1.DepartmentId}         \t{departments1.DepartmentName}");
                        }
                        break;
                    case 8:
                        Console.WriteLine(" -----------Add Department -----------");
                        departmentDomain.AddDept(departments);
                        break;
                    case 9:
                        Console.WriteLine(" -----------Delete Department -----------");
                        departmentDomain.DeleteDept(departments);
                        break;
                    case 10:
                        Console.WriteLine(" -----------Get Assistant details -----------");
                        Console.WriteLine("Assistant ID \tAssistant Name\tAsistant Gender\tAssistant Age\tDepartmentId");
                        foreach (Assistants assistants1 in assistantDomain.GetAssistant())
                        {

                            Console.WriteLine($"{assistants1.AssistantId}         \t{assistants1.AssistantName}  \t{assistants1.AssistantGender}\t{assistants1.AssistantAge}  \t {assistants1.DepartmentId}");
                        }
                        break;
                    case 11:
                        Console.WriteLine(" -----------Add Assistant -----------");
                        assistantDomain.AddAssistanat(assistants);
                        break;
                    case 12:
                        Console.WriteLine(" -----------Delete Assistant -----------");
                        assistantDomain.DeleteAssistant(assistants);
                        break;
                    case 13:
                        Console.WriteLine(" -----------Get Treatments details -----------");
                        Console.WriteLine("Doctor Name \tPatient Name\t Department Name");
                        foreach (VTreat vTreat in treatsDomain.GetVTreats())
                        {

                            Console.WriteLine($"{vTreat.DoctorName}         \t{vTreat.PatientName}   \t{vTreat.DepartmentName}");
                        }
                        break;
                    case 14:
                        Console.WriteLine(" -----------Add Treatment Deatils -----------");
                        treatsDomain.AssignTreat(treats);
                        break;
                   
                    case 15:
                        Console.WriteLine(" -----------Book Appointment -----------");
                        appointmentDomain.BookAppontment(appointments);
                        break;
                    case 16:
                        Console.WriteLine(" -----------Get Appoinntment details -----------");
                        Console.WriteLine("Appointment ID \tPatient Id\tDoctor Id\tAppintment datetime\tAppointment description");
                        foreach (Appointments appointments1 in appointmentDomain.GetAppointmentsDetails())
                        {

                            Console.WriteLine($"{appointments1.AppointmentId}         \t{appointments1.PatientId}\t  {appointments1.DoctorId}\t {appointments1.AppointDateTime}\t  {appointments1.Description}");
                        }
                        break;
                    case 17:
                        Console.WriteLine(" -----------Get Drugs details -----------");
                        Console.WriteLine("Drug ID \tDrug Name\tDrug Description");
                        foreach (DrugsDetails drugsDetails1 in drugsDetailsDomain.GetDrugs())
                        {

                            Console.WriteLine($"{drugsDetails1.DrugId}         \t{drugsDetails1.DrugName}\t\t{drugsDetails1.DrugDescription}");
                        }
                        break;
                    case 18:
                        Console.WriteLine(" -----------Add Drug -----------");
                        drugsDetailsDomain.AddDrugs(drugsDetails);
                        break;
                    case 19:
                        Console.WriteLine(" -----------Delete Drug -----------");
                        drugsDetailsDomain.DeleteDrug(drugsDetails);
                        break;
                    case 20:
                        return;
                    default:
                        Console.WriteLine(" Your Choice Is Wrong");
                        break;
                }
            } while (i > -1);
        }
    }
}
