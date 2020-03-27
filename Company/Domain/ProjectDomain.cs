using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Company.Models;
namespace Company.Domain
{
    class ProjectDomain:SoftwareCompanyDBContext
    {
        EmployeeDomain e = new EmployeeDomain();
        public void AddProject(Projects projects)
        {
            Console.WriteLine("Enter Project Name");
            projects.ProjectName = Console.ReadLine();
            Console.WriteLine("Enter Project Description");
            projects.Description = Console.ReadLine();

           
            Console.WriteLine("Enter Bussiness ID");
            projects.BussinessId = Convert.ToInt32(Console.ReadLine());
           
            e.getEmployee();
            Console.WriteLine(" Assign Manager");
            Console.WriteLine("Enter Employee Id Which you want to make Manager");
            projects.AssignManager = Convert.ToInt32(Console.ReadLine());
            var a = Projects.SingleOrDefault(p => p.AssignManager == projects.AssignManager);
            var v = OnVacation.SingleOrDefault(m=>m.EmployeeId==projects.AssignManager);
            var b = AssignProject.SingleOrDefault(b=>b.EmployeeId==projects.AssignManager);
            if (a == null && v==null && b==null)
            {
                Projects.Add(projects);
                SaveChanges();
            }
            else if (b != null)
            {
                    Console.WriteLine("this employee work on other project");
                }
              else  if(v!=null)
                {
                Console.WriteLine("Employee On Vacation");
                }
            else
            {
                Console.WriteLine("Already Manager assign in Other Project");
            }

        }
        public void DeleteProject(Projects projects)
        {
    
            Console.WriteLine("Enter Project Id:");
            projects.ProjectId = Convert.ToInt32(Console.ReadLine());
            Projects.Remove(projects);
            SaveChanges();

        }
       
        public void getProjectDetails()
        {
           
           
                Console.WriteLine("Project ID\tProject Name \t Descripion  \tManager\tUnitName");
                foreach (var p in VProjectDetails.ToList())
                {
                    Console.WriteLine($" {p.ProjectId}\t{p.ProjectName}  \t {p.Description}  \t{p.Manager} \t{p.UnitName} ");
                }
            

        }
    }
}
