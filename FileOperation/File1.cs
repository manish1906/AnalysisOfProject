using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace FileOperation
{
    class File1
    {
        StreamWriter sw;
        StreamReader sr;
        public void createFile()
        {
            Console.WriteLine("Enter Path which you want to create  file and Enter file name");
            Console.WriteLine("Ex.C:/filename");
            string path = Console.ReadLine();
            if (File.Exists($"{path}.txt"))
            {

                Console.WriteLine("File already Exist");
            }
            else
            {
                try
                {
                    sw = new StreamWriter($"{path}.txt");
                    Console.WriteLine("File  Succesfully Created");
                    Console.WriteLine("Enter the Text Which You Want write in the file");
                    string str = Console.ReadLine();
                    sw.WriteLine(str);
                    sw.Flush();
                    sw.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);

                    
                }
                
            }



        }
        public void renameFile()
        {

            Console.WriteLine("Enter Path which you want to Rename  file and Enter file name");
            Console.WriteLine("Ex.C:/filename");
            string path = Console.ReadLine();
          
            if (File.Exists($"{path}.txt"))
            {
                Console.WriteLine("Enter new name with path");
                string name = Console.ReadLine();           
                File.Move($"{path}.txt", $"{name}.txt");

            }
            else
            {
                Console.WriteLine("File Not Exists");
            }


        }
        public void write()
        {
            Console.WriteLine("Enter Path which you want to write content and Enter file name");
            Console.WriteLine("Ex.C:/filename");
            string path = Console.ReadLine();
            if (File.Exists($"{path}.txt"))
            {
                sw = new StreamWriter($"{path}.txt");
                Console.WriteLine("Enter the Text Which You Want write in the file");
                string str = Console.ReadLine();
                sw.WriteLine(str);
                sw.Flush();
                sw.Close();

            }
            else
            {
                Console.WriteLine("File not Exist");
            }
            
        }
        public void display()

        {
            Console.WriteLine("Enter File Name with Path Which you want to diplay the content");
           
            Console.WriteLine("Ex.C:/filename");
            string path = Console.ReadLine();

            if (File.Exists($"{path}.txt"))
            {
               string content= File.ReadAllText($"{path}.txt");
                Console.WriteLine(content);

            }
            else
            {
                Console.WriteLine("File Not Exists");
            }




        }
        public void copy()
        {
            Console.WriteLine("Enter Source File Name with Path Which you want to Copy");

            Console.WriteLine("Ex.C:/filename");
            string path = Console.ReadLine();

            if (File.Exists($"{path}.txt"))
            {
                Console.WriteLine("Enter Destination File Name with Path Which you want to Copy");

                Console.WriteLine("Ex.C:/filename");
                string dest = Console.ReadLine();
                File.Copy($"{path}.txt", $"{dest}.txt");

            }
            else
            {
                Console.WriteLine("File Not Exists");
            }



        }

        public void concate()
        {
            Console.WriteLine("Enter 1st File Name with Path Which you want to concate");

            Console.WriteLine("Ex.C:/filename");
            string path = Console.ReadLine();

            Console.WriteLine("Enter 2nd File Name with Path Which you want to concate");

            Console.WriteLine("Ex.C:/filename");
            string dest = Console.ReadLine();
            if (File.Exists($"{path}.txt") && File.Exists($"{dest}.txt"))
            {
                sr  = new StreamReader($"{path}.txt");
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string str1 = sr.ReadLine();
                 sr = new StreamReader($"{dest}.txt");
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string str2 = sr.ReadLine();               
                Console.WriteLine("Enter target File Name with Path Which you want to concate");
                Console.WriteLine("Ex.C:/filename");
                string t = Console.ReadLine();
                StreamWriter sw = new StreamWriter($"{t}.txt");
                sw.WriteLine(str1+"\n"+str2);
                sr.Close();
                sr.Close();
                sw.Close();
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }

        }
    }
}
