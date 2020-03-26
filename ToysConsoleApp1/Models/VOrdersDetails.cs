using System;
using System.Collections.Generic;

namespace ToysConsoleApp1.Models
{
    public partial class VOrdersDetails
    {
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ToyType { get; set; }
        public int Quantity { get; set; }
        public string Address { get; set; }
        public int TotalPrice { get; set; }
    }
}
