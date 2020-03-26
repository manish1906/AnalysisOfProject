using System;
using System.Collections.Generic;

namespace ToysConsoleApp1.Models
{
    public partial class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public string Status { get; set; }
        public DateTime ShippedDate { get; set; }

        public virtual Orders Order { get; set; }
    }
}
