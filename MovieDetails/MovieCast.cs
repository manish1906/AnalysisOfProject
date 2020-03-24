using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDetails
{
    class MovieCast:Base
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public string Role { get; set; }



        public void Add()
        {
            Console.WriteLine("Enter MovieId");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter ActorId");
            int actorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Actor Role");
            string role = Console.ReadLine();
            this.ExecuteNonQuery($"insert into MovieCast  values ({movieId},{actorId},'{role}') "); 




        }
        public void FindActor()
        {
           // Console.WriteLine("which actors appear in which movies");
            Console.WriteLine("Enter Movie Name, in this movie how many actor played role");
        string moviename = Console.ReadLine();
            var reader=this.GetReader($"select *from vMovieCast where moviename='{moviename}' ");
            Console.WriteLine("Actor Name\tRole");
            while (reader.Read())
            {
               
                Console.WriteLine($"{reader.GetString(1)}\t{reader.GetString(2)}");
            
            
            
            }

        
        }
        public void FindMovie()
        {
           // Console.WriteLine("which actors appear in which movies");
            Console.WriteLine("Enter Actor Name, that actor played role in which movie");
            string ActorName = Console.ReadLine();
            var reader = this.GetReader($"select *from vMovieCast where ActorName='{ActorName}' ");
            Console.WriteLine("Movie Name\tRole");
            while (reader.Read())
            {

                Console.WriteLine($"{reader.GetString(0)}\t{reader.GetString(2)}");



            }


        }


    }
}
