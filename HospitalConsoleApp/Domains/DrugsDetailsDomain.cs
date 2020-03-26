using System;
using System.Collections.Generic;
using System.Text;
using HospitalConsoleApp.Models;
using System.Linq;

namespace HospitalConsoleApp.Domains
{
    class DrugsDetailsDomain:HospitalDBContext
    {

        public void AddDrugs(DrugsDetails drugsDetails)
        {
            Console.WriteLine("Enter Drug Name");
            drugsDetails.DrugName = Console.ReadLine();
            Console.WriteLine("Enter Drug Description");
            drugsDetails.DrugDescription = Console.ReadLine();
            DrugsDetails.Add(drugsDetails);
            SaveChanges();


        }
        public void DeleteDrug(DrugsDetails drugsDetails)
        {

            Console.WriteLine("Enter Drug Id:");
            drugsDetails.DrugId = Convert.ToInt32(Console.ReadLine());
            DrugsDetails.Remove(drugsDetails);
            SaveChanges();

        }
        public List<DrugsDetails> GetDrugs()
        {

            return DrugsDetails.ToList();
        }
    }
}
