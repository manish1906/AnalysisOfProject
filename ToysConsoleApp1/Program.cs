using System;
using ToysConsoleApp1.Domain;
using ToysConsoleApp1.Models;

namespace ToysConsoleApp1
{
    class Program
    {
       public static bool show = true;
        static void Main(string[] args)
        {
            Customers customers = new Customers();
            CustomerDomain customerDomain = new CustomerDomain();
            Plants plants = new Plants();
            PlantDomain plantDomain = new PlantDomain();
            ToysDetails toysDetails = new ToysDetails();
            ToysDetailDomain toysDetailDomain = new ToysDetailDomain();
            Orders orders = new Orders();
            OrderDetails orderDetails = new OrderDetails();
            OrderDomain orderDomain = new OrderDomain();


            Console.WriteLine("----------------ToysCompany----------");
            int choice;
            do
            {
                Console.WriteLine("\n======= Menu =======");
                Console.WriteLine("1.Get Customers Details");
                Console.WriteLine("2.Add Customer ");
                Console.WriteLine("3.Delete Customer ");
               
                Console.WriteLine("4.Get Plants Details");
                Console.WriteLine("5.Add Plant ");
                Console.WriteLine("6.Delete Plant ");
                Console.WriteLine("7.Get Toys Details");
                Console.WriteLine("8.Add Toy ");
                Console.WriteLine("9.Delete Toy ");
                Console.WriteLine("10.Add order");
                Console.WriteLine("11.Add OrderStatus By admin side");
                Console.WriteLine("12.Get OrderDetails ");

                


                Console.WriteLine("13.Exit");

                Console.Write("\n Enter Your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(" -----------Get Customer details -----------");
                        Console.WriteLine("CustomerId \t CustomerName\tMobileNumber\tEmail\tAddress");
                        foreach (Customers customers1 in customerDomain.GetCustomerData())
                        {

                            Console.WriteLine($"{customers1.CustomerId}\t{customers1.CustomerName}  \t{customers1.MobileNumber}  \t{customers1.Email}  \t{customers1.Address}   ");
                        }
                        break;
                    case 2:
                        Console.WriteLine(" -----------Add Customer -----------");
                        customerDomain.AddCustomer(customers);
                        break;
                    case 3:
                        Console.WriteLine(" -----------Delete Customer -----------");
                        customerDomain.DeleteCustomer(customers);
                        break;
                    case 4:
                        Console.WriteLine(" -----------Get Plants details -----------");
                        Console.WriteLine("Plant ID \tPlant Name");
                        foreach (Plants plants1 in plantDomain.GetPlantData())
                        {

                            Console.WriteLine($"{plants1.PlantId}         \t{plants1.PlanName}");
                        }
                        break;
                    case 5:
                        Console.WriteLine(" -----------Add Plant -----------");
                        plantDomain.AddPlant(plants);
                        break;
                    case 6:
                        Console.WriteLine(" -----------Delete Plant -----------");
                        plantDomain.DeletePlant(plants);
                        break;
                    case 7:
                        Console.WriteLine(" -----------Get Toys details -----------");
                        Console.WriteLine("Toy ID \t ToyType\t ToyPrice\tPlantId");
                        foreach (ToysDetails toysDetails1 in toysDetailDomain.GetToyData())
                        {

                            Console.WriteLine($"{toysDetails1.ToyId}         \t{toysDetails1.ToyType}  \t{toysDetails1.ToyPrice}\t{toysDetails1.PlantId}  ");
                        }
                        break;
                    case 8:
                        Console.WriteLine(" -----------Add Toy -----------");
                        toysDetailDomain.AddToys(toysDetails);
                        break;
                    case 9:
                        Console.WriteLine(" -----------Delete Toy -----------");
                        toysDetailDomain.DeleteToy(toysDetails);
                        break;
                   
                    case 10:
                        Console.WriteLine(" -----------Add Order-----------");
                        orderDomain.AddOrder(orders);
                        break;

                    case 11:
                        Console.WriteLine(" -----------Add OrderStatus By admin side -----------");
                        orderDomain.AddO(orderDetails);
                        break;
                    case 12:
                        Console.WriteLine(" -----------Get Order details -----------");
                        Console.WriteLine("CustomerName \tToyType \t Quantity\tTotal Price\t Status\tShippedDate \tAddress");
                        foreach (VOrdersDetails vOrdersDetails in orderDomain.GetOrderDetails())
                        {

                            Console.WriteLine($"{vOrdersDetails.CustomerName}         \t{vOrdersDetails.ToyType}\t    {vOrdersDetails.Quantity}\t   {vOrdersDetails.TotalPrice} \t   {vOrdersDetails.Status}\t  {vOrdersDetails.ShippedDate}\t\t {vOrdersDetails.Address}");
                        }
                        break;
                  
                    case 13:
                        show=false;
                        break;
                    default:
                        Console.WriteLine(" Your Choice Is Wrong");
                        break;
                }
            } while (show);
        }
    }
}
