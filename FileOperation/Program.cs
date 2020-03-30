using System;
using System.IO;

namespace FileOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            bool show = true;
            Console.WriteLine("-------File Operation--------");
            File1 file = new File1();
          
            do
            {
                Console.WriteLine("1.Create a file");
                Console.WriteLine("2.Write into file");
                Console.WriteLine("3.Display conten of a file");
                Console.WriteLine("4.Rename a file");
                Console.WriteLine("5.Copy a file");
                Console.WriteLine("6.Concate two  files");
                Console.WriteLine("7.Exit");

                Console.WriteLine("Enter Your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        file.createFile();
                        break;
                    case 2:
                        file.write();
                        break;
                    case 3:
                        file.display();
                        break;
                    case 4:
                        file.renameFile();
                        break;
                    case 5:
                        file.copy();
                        break;
                    case 6:
                        file.concate();
                        break;
                    case 7:
                        show = false;
                        break;

                    default:Console.WriteLine("Your Choice is wrong");
                        break;
                }
            } while (show);




        }

    }
}
