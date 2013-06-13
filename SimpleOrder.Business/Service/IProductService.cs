using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleOrder.Business.Models;

namespace SimpleOrder.Business.Service
{
   public interface IProductService:IDisposable
   {
        void AddProduct(Product product);
       void UpdateProduct(Product product);
       void DeleteProduct(int id);
       List<Product> GetAllProduct();
        Product GetProduct(int productId);
    }
}
