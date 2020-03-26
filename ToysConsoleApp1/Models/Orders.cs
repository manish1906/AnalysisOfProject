using System;
using System.Collections.Generic;

namespace ToysConsoleApp1.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ToyId { get; set; }
        public int Quantity { get; set; }
        public string Address { get; set; }
        public int TotalPrice { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual ToysDetails Toy { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
