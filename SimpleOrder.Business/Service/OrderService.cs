using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleOrder.Business.Models;
using SimpleOrder.Business.UnitWork;

namespace SimpleOrder.Business.Service
{
    public class OrderService:IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        OrderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void AddOrder(Order order)
        {
            _unitOfWork.OrderRepository.Add(order);
            _unitOfWork.Save();

        }

        public IEnumerable<Order> GetAllOrder()
        {
            return _unitOfWork.OrderRepository.GetAll();
        }
        public Order GetOrder(int orderId)
        {
            return _unitOfWork.OrderRepository.FindById(orderId);
        }
    }
}
