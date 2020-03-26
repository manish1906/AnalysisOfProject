using System;
using System.Collections.Generic;
using System.Text;
using HospitalConsoleApp.Models;
using System.Linq;

namespace HospitalConsoleApp.Domains
{
    class AssistantDomain:HospitalDBContext
    {
        public void AddAssistanat(Assistants assistants)
        {
            Console.WriteLine("Enter Assistant Name");
            assistants.AssistantName = Console.ReadLine();
            Console.WriteLine("Enter Assistant Gender");
            assistants.AssistantGender = Console.ReadLine();
            Console.WriteLine("Enter Assistant Age");
            assistants.AssistantAge =Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Enter Department ID");
            assistants.DepartmentId = Convert.ToInt32(Console.ReadLine());
            Assistants.Add(assistants);
            SaveChanges();


        }
        public void DeleteAssistant(Assistants assistants)
        {

            Console.WriteLine("Enter Assistant Id:");
            assistants.AssistantId = Convert.ToInt32(Console.ReadLine());
            Assistants.Remove(assistants);
            SaveChanges();

        }
        public List<Assistants> GetAssistant()
        {

            return Assistants.ToList();
        }


    }
}
