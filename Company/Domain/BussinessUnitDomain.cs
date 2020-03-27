using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Company.Models;


namespace Company.Domain
{
    class BussinessUnitDomain:SoftwareCompanyDBContext
    {
        public void AddBussiness(BussinessUnits bussinessUnits)
        {
            Console.WriteLine("Enter Bussiness Unit  Name");
            bussinessUnits.UnitName = Console.ReadLine();
            BussinessUnits.Add(bussinessUnits);
            SaveChanges();


        }
        public void DeleteBussiness(BussinessUnits bussinessUnits)
        {
            this.getBussinessUnitDetails();
            Console.WriteLine("Enter Bussiness Unit Id:");
            bussinessUnits.BussinessUnitId = Convert.ToInt32(Console.ReadLine());
            BussinessUnits.Remove(bussinessUnits);
            SaveChanges();

        }

        public void getBussinessUnitDetails()
        {

        
            Console.WriteLine("BussinessUnit ID \tUnit Name");
            foreach (var b in BussinessUnits.ToList())
            {

                Console.WriteLine($"{b.BussinessUnitId}         \t{b.UnitName}");
            }
        }
}
}
