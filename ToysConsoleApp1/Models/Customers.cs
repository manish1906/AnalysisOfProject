using System;
using System.Collections.Generic;

namespace ToysConsoleApp1.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int MobileNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
