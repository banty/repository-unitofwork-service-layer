using System;
using SimpleOrder.Business.Models;
using SimpleOrder.Business.Repository;


namespace SimpleOrder.Business.UnitWork
{
   public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Product> ProductRepository { get;  }
        IGenericRepository<Order> OrderRepository { get;  }
       void Save();

    }
}
