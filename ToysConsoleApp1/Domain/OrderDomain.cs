using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ToysConsoleApp1.Models;
using ToysConsoleApp1.Domain;

namespace ToysConsoleApp1.Domain
{
    class OrderDomain:ToyCompanyDBContext
    {
        ToysDetails toysDetails = new ToysDetails();
        ToysDetailDomain toysDetailDomain = new ToysDetailDomain();
      //  OrderDomain orderDomain = new OrderDomain();
        public void AddOrder(Orders orders)
        {
            Console.WriteLine("Toy ID \t ToyType\t ToyPrice\tPlantId");
            foreach (ToysDetails toysDetails1 in toysDetailDomain.GetToyData())
            {

                Console.WriteLine($"{toysDetails1.ToyId}         \t{toysDetails1.ToyType}  \t{toysDetails1.ToyPrice}\t{toysDetails1.PlantId}  ");
            }
            Console.WriteLine("Enter Customer Id");
            orders.CustomerId =Convert.ToInt32( Console.ReadLine());
           
            Console.WriteLine("Enter Toy Id");
            orders.ToyId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Quantity");
            orders.Quantity = Convert.ToInt32(Console.ReadLine());
        
            var price = ToysDetails.Single(t => t.ToyId == orders.ToyId);
            var m = price.ToyPrice;
            var total = m * orders.Quantity;
            
            orders.TotalPrice = total;
            Console.WriteLine("Enter Address");
            orders.Address = Console.ReadLine();
            Orders.Add(orders);
            SaveChanges();


        }
        public List<Orders> GetOrder()
        {

            return Orders.ToList();
        }
        public void AddO(OrderDetails orderDetails)
        {
            
            Console.WriteLine("Enter OrderId");
            orderDetails.OrderId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Order Status");
            orderDetails.Status = Console.ReadLine();
            Console.WriteLine("Enter shipped date");
            orderDetails.ShippedDate = Convert.ToDateTime(Console.ReadLine());
            OrderDetails.Add(orderDetails);
            SaveChanges();
        
        }
        public List<VOrdersDetails> GetOrderDetails()
        {

            return VOrdersDetails.ToList();
        }
    }
}
