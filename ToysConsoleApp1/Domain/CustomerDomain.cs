using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ToysConsoleApp1.Models;

namespace ToysConsoleApp1.Domain
{
    class CustomerDomain:ToyCompanyDBContext
    {

        public void AddCustomer(Customers customers)
        {

            Console.WriteLine("Enter CustomerName");
            customers.CustomerName = Console.ReadLine();
            
            Console.WriteLine("Enter Customer MobileNumber");
            customers.MobileNumber = Convert.ToInt32(Console.ReadLine());
           
            Console.WriteLine("Enter Email");
            customers.Email = Console.ReadLine();
            Console.WriteLine("Enter Address");
            customers.Address = Console.ReadLine();

            Customers.Add(customers);
            SaveChanges();


        }
        public void DeleteCustomer(Customers customers)
        {

            Console.WriteLine("Enter Customer Id");
            customers.CustomerId = Convert.ToInt32(Console.ReadLine());

            Customers.Remove(customers);
            SaveChanges();

        }

        public List<Customers> GetCustomerData()
        {

            return Customers.ToList();
        }
    }
}
