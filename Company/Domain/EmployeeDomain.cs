using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Company.Models;
namespace Company.Domain
{
    class EmployeeDomain:SoftwareCompanyDBContext
    {
        public void AddEmployee(Employees employees)
        {

            Console.WriteLine("Enter Employee Name");
            employees.EmployeeName = Console.ReadLine();

            Console.WriteLine("Enter Employee MobileNumber");
            employees.MobileNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Email");
            employees.Email = Console.ReadLine();
           

            Employees.Add(employees);
            SaveChanges();


        }
        public void DeleteEmployee(Employees employees)
        {
            this.getEmployee();
            Console.WriteLine("Enter Employee Id");
            employees.EmployeeId = Convert.ToInt32(Console.ReadLine());

            Employees.Remove(employees);
            SaveChanges();

        }

       
        public void getEmployee()
        {
           
            
                Console.WriteLine("EmployeeId \t EmployeeName\tMobileNumber\tEmail");
                foreach (var emp in Employees.ToList())
                {
                    Console.WriteLine($" {emp.EmployeeId}  \t {emp.EmployeeName}  \t{emp.MobileNumber} \t{emp.Email} ");
                }
            

        }
    }
}
