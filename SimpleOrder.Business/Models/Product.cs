using System;
using System.Collections.Generic;

namespace SimpleOrder.Business.Models
{
    public partial class Product
    {
        public Product()
        {
            this.OrderDeatils = new List<OrderDeatil>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OrderDeatil> OrderDeatils { get; set; }
    }
}
