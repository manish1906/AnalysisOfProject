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
        public void AddOrder(Orders orders)
        {
            Console.WriteLine("Enter Customer Id");
            orders.CustomerId =Convert.ToInt32( Console.ReadLine());
           
            Console.WriteLine("Enter Toy Id");
            orders.ToyId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Quantity");
            orders.Quantity = Convert.ToInt32(Console.ReadLine());
          //  orders.TotalPrice = orders.Quantity * toysDetails.ToyPrice;
           // Console.WriteLine(orders.TotalPrice);
            Console.WriteLine("Enter Address");
            orders.Address = Console.ReadLine();
            Orders.Add(orders);
            SaveChanges();


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
