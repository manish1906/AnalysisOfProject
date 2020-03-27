using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Company.Models;
using Company.Domain;

namespace Company.Domain
{
    class OnVacationDomain:SoftwareCompanyDBContext
    {
        EmployeeDomain e = new EmployeeDomain();
        public void AddVacation(OnVacation onVacation)
        {
            e.getEmployee();
            Console.WriteLine("Which Employee go on Vacation");
            Console.WriteLine("Enter Employee Id");
            onVacation.EmployeeId = Convert.ToInt32(Console.ReadLine());
            var v = OnVacation.SingleOrDefault(v=>v.EmployeeId==onVacation.EmployeeId);
            if (v != null)
            {
                Console.WriteLine("This Employee already on Vacation ");
                //Console.WriteLine("");
            }
            else
            {
                OnVacation.Add(onVacation);
                SaveChanges();
            }
        }
        public void DeleteVacation(OnVacation onVacation)
        {
            this.getVacationDetails();
            Console.WriteLine("Enter Vacation Id:");
            onVacation.VacationId = Convert.ToInt32(Console.ReadLine());
            OnVacation.Remove(onVacation);
            SaveChanges();

        }

        public void getVacationDetails()
        {


            Console.WriteLine("Vacation ID \tEmployee Id");
            foreach (var b in OnVacation.ToList())
            {

                Console.WriteLine($"{b.VacationId}         \t{b.EmployeeId}");
            }
        }
    }
}
