using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleOrder.Business.Models;

namespace SimpleOrder.Business.Service
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrder();
        Order GetOrder(int orderId);
    }
}
