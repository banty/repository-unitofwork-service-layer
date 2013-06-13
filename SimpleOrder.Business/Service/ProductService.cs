using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SimpleOrder.Business.Models;
using SimpleOrder.Business.UnitWork;

namespace SimpleOrder.Business.Service
{
   public class ProductService:IProductService
   {
       private readonly  IUnitOfWork _unitOfWork;
      
      public ProductService(IUnitOfWork unitOfWork)
       {
           this._unitOfWork = unitOfWork;
       }


   
       //public ProductService()
       //{
       //    this._unitOfWork = new UnitOfWork();
       //}
       public void AddProduct(Product product)
       {
           _unitOfWork.ProductRepository.Add(product);
           _unitOfWork.Save();
           
       }
       public void UpdateProduct(Product product)
       {
           _unitOfWork.ProductRepository.Edit(product);
           _unitOfWork.Save();

       }
       public  void DeleteProduct(int id)
       {
           var org = _unitOfWork.ProductRepository.FindById(id);
           _unitOfWork.ProductRepository.Delete(org);
           _unitOfWork.Save();
       }
       public List<Product> GetAllProduct()
       {
           return _unitOfWork.ProductRepository.GetAll();
       } 
       public Product GetProduct(int productId)
       {
           return _unitOfWork.ProductRepository.FindById(productId);
       }

       public void Dispose()
       {
           _unitOfWork.Dispose();
           
       }
   }
}
