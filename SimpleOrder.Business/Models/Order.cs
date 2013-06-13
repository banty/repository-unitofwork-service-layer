using System;
using System.Collections.Generic;

namespace SimpleOrder.Business.Models
{
    public partial class Order
    {
        public Order()
        {
            this.OrderDeatils = new List<OrderDeatil>();
        }

        public int OrderId { get; set; }
        public string OrderedBy { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public virtual ICollection<OrderDeatil> OrderDeatils { get; set; }
    }
}
