using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDetails
{
    class Actor:Base
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string ActorNationality { get; set; }
        public DateTime ActorDOB { get; set;   }
        public string ActorGender { get; set; }


        public void Add()
        {
            Console.WriteLine("Enter Actor Name");
            string ActorName = Console.ReadLine();
           
            Console.WriteLine("Enter Actor Nationality");
            string ActorNationality = Console.ReadLine();
            Console.WriteLine("Enter Actor Dob");
            DateTime ActorDOB = Convert.ToDateTime( Console.ReadLine());
            
            Console.WriteLine("Enter Actor Gender");
            string ActorGender = Console.ReadLine();
            this.ExecuteNonQuery($"insert into Actors (ActorName,ActorNationality,ActorDOB,ActorGender) values ('{ActorName}','{ActorNationality}','{ActorDOB}','{ActorGender}') ");

        }
        public void Delete()
        {
            Console.WriteLine("Enter Actor Name");
            string ActorName = Console.ReadLine();
            this.ExecuteNonQuery($"delete from Actors where ActorName='{ActorName}'");
        }
         public void Get()
        {

            var reader = this.GetReader("select *from Actors");
            
            Console.WriteLine("Actor Name\tActor Nationality\tActor Dob\tActor gender");
            while (reader.Read())
            {
                
                Console.WriteLine($"{reader.GetString(1)} \t{reader.GetString(2)} \t \t\t{reader.GetDateTime(3)}\t{reader.GetString(4)}");
              
               
                


            }
          
        }


    }
}
