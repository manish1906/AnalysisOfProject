using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ToysConsoleApp1.Models;
namespace ToysConsoleApp1.Domain
{
    class PlantDomain:ToyCompanyDBContext
    {
        public void AddPlant(Plants plants)
        {
            Console.WriteLine("Enter Plant Name");
            plants.PlanName = Console.ReadLine();
            Plants.Add(plants);
            SaveChanges();


        }
        public void DeletePlant(Plants plants)
        {

            Console.WriteLine("Enter Plant Id:");
            plants.PlantId = Convert.ToInt32(Console.ReadLine());
            Plants.Remove(plants);
            SaveChanges();

        }
        public List<Plants> GetPlantData()
        {

            return Plants.ToList();
        }
    }
}
