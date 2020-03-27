using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ToysConsoleApp1.Models;



namespace ToysConsoleApp1.Domain
{
    class ToysDetailDomain:ToyCompanyDBContext
    {
        public void AddToys(ToysDetails toysDetails)
        {
            Console.WriteLine("Enter Toy Type");
            toysDetails.ToyType = Console.ReadLine();
            
            Console.WriteLine("Enter Toy Price");
            toysDetails.ToyPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter plant ID");
            toysDetails.PlantId = Convert.ToInt32(Console.ReadLine());
            ToysDetails.Add(toysDetails);
            SaveChanges();


        }
        public void DeleteToy(ToysDetails toysDetails)
        {

            Console.WriteLine("Enter Toy Id:");
            toysDetails.ToyId = Convert.ToInt32(Console.ReadLine());
            ToysDetails.Remove(toysDetails);
            SaveChanges();

        }
        public List<ToysDetails> GetToyData()
        {

            return ToysDetails.ToList();
        }
    }
}
