using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleOrder.Business.Models;
using SimpleOrder.Business.Repository;

namespace SimpleOrder.Business.UnitWork
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly MyStoreContext _context;
        private IGenericRepository<Product> productRepository;
        private IGenericRepository<Order> orderRepository;


      
        public UnitOfWork()
        {
            this._context = new MyStoreContext();
        }
        public IGenericRepository<Product> ProductRepository
        {
            get { return this.productRepository ?? (this.productRepository = new GenericRepository<Product>(_context)); }
        }

        public IGenericRepository<Order> OrderRepository
        {
            get { return this.orderRepository ?? (this.orderRepository = new GenericRepository<Order>(_context)); }
        }
       

        public void Save()
        {
            
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
