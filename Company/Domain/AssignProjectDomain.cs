using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Company.Models;
using Company.Domain;

namespace Company.Domain
{
    class AssignProjectDomain:SoftwareCompanyDBContext
    {
        ProjectDomain projectDomain = new ProjectDomain();
        EmployeeDomain employeeDomain = new EmployeeDomain();
        public void assignProject(AssignProject assignProject)
        {

           
            projectDomain.getProjectDetails();
            Console.WriteLine("Enter Project Id");
            assignProject.ProjectId= Convert.ToInt32(Console.ReadLine());
            employeeDomain.getEmployee();
            Console.WriteLine("Enter Employee Id");
            assignProject.EmployeeId = Convert.ToInt32(Console.ReadLine());
            var a = AssignProject.SingleOrDefault(p => p.EmployeeId == assignProject.EmployeeId);
            var v = Projects.SingleOrDefault(v => v.AssignManager == assignProject.EmployeeId);
            var b = OnVacation.SingleOrDefault(b => b.EmployeeId==assignProject.EmployeeId);
            if (b != null)
            {
                Console.WriteLine("This Employee is on vacation");
            }
            else
            {
                if (a == null)
                {

                    if (v == null)
                    {
                        AssignProject.Add(assignProject);
                        SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("This Employee, Manager in other project");
                    }
                }
                else
                {


                    if (v == null)
                    {
                        AssignProject.Add(assignProject);
                        SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("This Employee, Manager in other project");
                    }
                    Console.WriteLine("Employee already in other Project");

                }
            }
        }
        public void DeleteAssignProject(AssignProject assignProject)
        {
            this.getProjectAssignDetails();
            Console.WriteLine("Enter Assign Id:");
            assignProject.AssignId = Convert.ToInt32(Console.ReadLine());
            AssignProject.Remove(assignProject);
            SaveChanges();

        }
        public void getProjectAssignDetails()
        {
            Console.WriteLine("AssignId\tEmployee Name\tProject Name\t Unit Name");
            foreach (var p in VAssignProject.ToList())
            {
                Console.WriteLine($"{p.AssignId}\t  {p.EmployeeName}\t   {p.ProjectName}\t   {p.UnitName}");
            }
        
        }
    }
}
