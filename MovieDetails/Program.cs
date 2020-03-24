using System;

namespace MovieDetails
{
    class Program
    {
        public static int i;
        static void Main(string[] args)
        {
           
            Console.WriteLine("***************Movie Details*****************");
            int choice;
            
            Movie movie=new Movie();
            Actor actor = new Actor();
            MovieCast movieCast = new MovieCast();
          //  movieCast.FindMovie();

            do
            {
                Console.WriteLine("\n======= Menu =======");
                Console.WriteLine("1.Get MovieDetails");
                Console.WriteLine("2.Add Movie");
                Console.WriteLine("3.Delete Movie");
                Console.WriteLine("4.Get ActorsDetails");
                Console.WriteLine("5.Add Actors");
                Console.WriteLine("6.Delete Actors");
                Console.WriteLine("7.Add MoviCast");
                Console.WriteLine("8.In this movie How Many Actors Playd role");
                Console.WriteLine("9.This actor Played role in this movie");


                Console.WriteLine("10.Exit");

                Console.Write("\n Enter Your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(" -----------Get movies details -----------");
                        movie.Get();
                        break;
                    case 2:
                        Console.WriteLine(" -----------Add movies -----------");
                        movie.Add();
                        break;
                    case 3:
                        Console.WriteLine(" -----------Delete movies -----------");
                        movie.Delete();
                        break;
                    case 4:
                        Console.WriteLine(" -----------Get Actors details -----------");
                        actor.Get();
                        break;
                    case 5:
                        Console.WriteLine(" -----------Add Actor -----------");
                        actor.Add();
                        break;
                    case 6:
                        Console.WriteLine(" -----------Delete Actor -----------");
                        actor.Delete();
                        break;
                    case 7:
                        Console.WriteLine("-------------Add MovieCast------------");
                        movieCast.Add();
                        break;
                    case 8:
                        
                        movieCast.FindActor();
                        break;
                    case 9:
                       
                        movieCast.FindMovie();
                        break;
                    case 10: return;
                    default:
                        Console.WriteLine(" Your Choice Is Wrong");
                        break;
                }
            } while (i > -1);
        }
    }
}
    
