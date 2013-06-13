using System;
using System.Collections.Generic;

namespace SimpleOrder.Business.Models
{
    public partial class OrderDeatil
    {
        public int OrderDeatilId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
