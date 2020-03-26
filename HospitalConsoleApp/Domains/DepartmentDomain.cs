using System;
using System.Collections.Generic;
using System.Text;
using HospitalConsoleApp.Models;
using System.Linq;
namespace HospitalConsoleApp.Domains
{
    class DepartmentDomain:HospitalDBContext
    {


        public void AddDept(Departments departments)
        {
            Console.WriteLine("Enter Department Name");
            departments.DepartmentName = Console.ReadLine();
            Departments.Add(departments);
            SaveChanges();
        
        
        }
        public void DeleteDept(Departments departments)
        {

            Console.WriteLine("Enter Department Id:");
            departments.DepartmentId = Convert.ToInt32(Console.ReadLine());
            Departments.Remove(departments);
            SaveChanges();
        
        }
        public List<Departments> GetDepartments()
        {

            return Departments.ToList();
        }
    }
}
