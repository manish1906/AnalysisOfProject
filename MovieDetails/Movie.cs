using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDetails
{
    class Movie:Base
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int ReleaseYear { get; set; }
        public string MovieLanguage{ get; set; }
        public string MovieDirectorName { get; set; }
        public double MovieRating { get; set; }
        public int MovieType{ get; set; }

        public void Add()
        {
            Console.WriteLine("Enter Movie Name");
            string MovieName = Console.ReadLine();
            Console.WriteLine("Enter Movie Release Year");
            int ReleaseYear = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Enter Movie Language");
            string MovieLanguage = Console.ReadLine();
            Console.WriteLine("Enter Movie DirectorName");
            string MovieDirectorName = Console.ReadLine();
            Console.WriteLine("Enter Movie Rating");
            double MovieRating =Convert.ToDouble( Console.ReadLine());
            Console.WriteLine("Enter Movie Type");
            string MovieType = Console.ReadLine();
            this.ExecuteNonQuery($"insert into Movies (MovieName,ReleaseYear,MovieLanguage,MovieDirectorName,MovieRating,MovieType) values ('{MovieName}',{ReleaseYear},'{MovieLanguage}','{MovieDirectorName}',{MovieRating},'{MovieType}') ");

        }
        public void Delete()
        {
            Console.WriteLine("Enter Movie Name you want delete");
            string MovieName = Console.ReadLine();
            this.ExecuteNonQuery($"delete from Movies where MovieName='{MovieName}' ");
        }
        public void Get()
        {

            var reader = this.GetReader("select *from Movies");
            
            Console.WriteLine("Movie Name\tRelease Year\tMovie Language\tMovie Director Name\tMovie Rating\tMovie Type");
            while (reader.Read())
            {
                
                Console.WriteLine($"{reader.GetString(1)} \t\t {reader.GetInt32(2)} \t\t {reader.GetString(3)}\t\t {reader.GetString(4)}\t\t  {reader.GetDouble(5)}\t\t {reader.GetString(6)}");
              
                //console.writeline($"movie name:- {reader.getstring(1)}");
                //console.writeline("release year:- ", reader.getint32(2));

                //console.writeline("movie language:- ", reader.getstring(3));
                //console.writeline("movie director name:- ", reader.getstring(4));
                //console.writeline("movie rating:- ", reader.getdouble(5));
                //console.writeline("movie type:- ", reader.getstring(6));
                


            }
          
        }

    }
}
