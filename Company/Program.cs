using System;
using Company.Models;
using Company.Domain;
namespace Company
{
    class Program
    {

        public static bool show = true;
        static void Main(string[] args)
        {

            Employees employees = new Employees();
            EmployeeDomain employeeDomain = new EmployeeDomain();
            BussinessUnits bussinessUnits = new BussinessUnits();
            BussinessUnitDomain bussinessUnitDomain = new BussinessUnitDomain();
            Projects projects = new Projects();
            ProjectDomain projectDomain = new ProjectDomain();
            OnVacation onVacation = new OnVacation();
            OnVacationDomain onVacationDomain = new OnVacationDomain();
            AssignProject assignProject = new AssignProject();
            AssignProjectDomain assignProjectDomain = new AssignProjectDomain();

            Console.WriteLine("----------------Company----------");
            int choice;
            do
            {
                Console.WriteLine("======= Menu =======");
               

                Console.WriteLine("1.Get Employee Details");
                Console.WriteLine("2.Add Employee ");
                Console.WriteLine("3.Delete Employee ");

                Console.WriteLine("4.Get BussinessUnit Details");
                Console.WriteLine("5.Add Bussiness Unit ");
                Console.WriteLine("6.Delete Bussiness Unit ");
                Console.WriteLine("7.Get Projects Details");
                Console.WriteLine("8.Add Project ");
                Console.WriteLine("9.Delete Project ");
                Console.WriteLine("10.Get Details about which employee on vacation");
                Console.WriteLine("11.Go to Vacation ");
                Console.WriteLine("12.Delete Vacation");
                Console.WriteLine("13.Get Assign Project Details ");
                Console.WriteLine("14.Assign Project");
                Console.WriteLine("15.Delete Assign Project");




                Console.WriteLine("16.Exit");

                Console.Write("\n Enter Your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(" -----------Get Customer details -----------");
                        
                        employeeDomain.getEmployee();
                        break;
                    case 2:
                        Console.WriteLine(" -----------Add Employee -----------");
                        employeeDomain.AddEmployee(employees);
                        break;
                    case 3:
                        Console.WriteLine(" -----------Delete Employee -----------");
                        employeeDomain.DeleteEmployee(employees);
                        break;
                    case 4:
                        Console.WriteLine(" -----------Get Bussiness Unit details -----------");
                        bussinessUnitDomain.getBussinessUnitDetails();
                        break;
                    case 5:
                        Console.WriteLine(" -----------Add Bussiness Unit--------------");
                        bussinessUnitDomain.AddBussiness(bussinessUnits);
                        break;
                    case 6:
                        Console.WriteLine(" -----------Delete Bussiness Unit -----------");
                       bussinessUnitDomain.DeleteBussiness(bussinessUnits);
                        break;
                    case 7:
                        Console.WriteLine(" -----------Get Project details -----------");
                      
                        projectDomain.getProjectDetails();
                        break;
                    case 8:
                        Console.WriteLine(" -----------Add Project -----------");
                        projectDomain.AddProject(projects);
                        break;
                    case 9:
                        Console.WriteLine(" -----------Delete Project -----------");
                        projectDomain.DeleteProject(projects);
                        break;

                    case 10:
                        Console.WriteLine("--------Get Details about which employee on vacation-------");
                        onVacationDomain.getVacationDetails();
                        break;
                        break;
                    case 11:
                        Console.WriteLine(" -----------Add Vacation Details  -----------");
                        onVacationDomain.AddVacation(onVacation);
                        break;
                    case 12:
                        Console.WriteLine(" -----------Delete Vacation Delete -----------");
                        onVacationDomain.DeleteVacation(onVacation);
                        break;
                    case 13:
                        Console.WriteLine(" -----------Get Project Assign details -----------");
                        assignProjectDomain.getProjectAssignDetails();
                        break;
                    case 14:
                        Console.WriteLine("--------Assign Project--------------");
                        assignProjectDomain.assignProject(assignProject);
                        break;
                    case 15:
                        Console.WriteLine("-------- Delete Assign Project--------------");
                        assignProjectDomain.DeleteAssignProject(assignProject);
                        break;
                    case 16:
                        show = false;
                        break;
                    default:
                        Console.WriteLine(" Your Choice Is Wrong");
                        break;
                }
            } while (show);
        }
    }
}
