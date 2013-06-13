using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SimpleOrder.Business.Models;
using SimpleOrder.Business.Service;
using SimpleOrder.Models;

namespace SimpleOrder.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public int PageSize = 4;
        //
        // GET: /Product/
      
        public ProductController(IProductService productServiceParam)
        {
           
            this.productService = productServiceParam;
        }
      
        public ViewResult Index(int page=1)
        {
            ProductListViewModel model = new ProductListViewModel
                                             {
                                                 Products = productService.GetAllProduct()
                                                     .OrderBy(p => p.ProductId)
                                                     .Skip((page - 1)*PageSize)
                                                     .Take(PageSize),
                                                 PagingInfo = new PagingInfo
                                                                  {
                                                                      CurrentPage = page,
                                                                      ItemsPerPage = PageSize,
                                                                      TotalItems =
                                                                          productService.GetAllProduct().Count()
                                                                  }


                                             };

            return View(model);
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = productService.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
               productService.AddProduct(product);
               
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = productService.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.UpdateProduct(product);
            
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = productService.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            productService.Dispose();
            base.Dispose(disposing);
        }
    }
}