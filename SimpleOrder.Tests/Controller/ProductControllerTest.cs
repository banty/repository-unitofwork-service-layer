using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleOrder.Business.Models;
using SimpleOrder.Business.Service;
using System.Linq;
using SimpleOrder.Controllers;
using System.Web.Mvc;
using SimpleOrder.HtmlHelpers;
using SimpleOrder.Models;

namespace SimpleOrder.Tests.Controller
{
    [TestClass]
    public class ProductControllerTest
    {
       [TestMethod]
        public void Can_Paginate()
       {
           //Arrange
           Mock<IProductService> mock= new Mock<IProductService>();
           var products = new List<Product>();
           
           mock.Setup(m => m.GetAllProduct()).Returns((new Product[]
                                                          {
                                                              new Product(){ProductId=1,ProductName = "P1"} ,
                                                               new Product(){ProductId=2,ProductName = "P2"} ,
                                                                new Product(){ProductId=3,ProductName = "P3"} ,
                                                                 new Product(){ProductId=4,ProductName = "P4"} ,
                                                                  new Product(){ProductId=5,ProductName = "P5"} ,
                                                                  

                                                          }).ToList());
     
           ProductController controller=new ProductController(mock.Object);

           controller.PageSize = 3;


           //Act

           ProductListViewModel result = (ProductListViewModel)controller.Index(2).Model;



           //Assert
           Product[] prodArray = result.Products.ToArray();
           Assert.IsTrue(prodArray.Length==2);
           Assert.AreEqual(prodArray[0].ProductName,"P4");
           Assert.AreEqual(prodArray[1].ProductName,"P5");

       }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            //Arrange -define an Html helper -we need to do this
            //in order to apply the extension method

            HtmlHelper myHelper = null;

            //Arrange -create PagingInfo data

            PagingInfo pagingInfo = new PagingInfo()
                                        {
                                            CurrentPage = 2,
                                            TotalItems = 28,
                                            ItemsPerPage = 10
                                        };

            //Arrange -set up the delegate using a lamda expression

            Func<int, string> pageUrlDelegate = i => "Page" + i;

            //Act

            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            //Assert

            Assert.AreEqual(result.ToString(),@"<a href=""Page1"">1</a>"
                +@"<a class=""selected"" href=""Page2"">2</a>"+
                @"<a href=""Page3"">3</a>");
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            Mock<IProductService> mock = new Mock<IProductService>();
          

            mock.Setup(m => m.GetAllProduct()).Returns((new Product[]
                                                          {
                                                              new Product(){ProductId=1,ProductName = "P1"} ,
                                                               new Product(){ProductId=2,ProductName = "P2"} ,
                                                                new Product(){ProductId=3,ProductName = "P3"} ,
                                                                 new Product(){ProductId=4,ProductName = "P4"} ,
                                                                  new Product(){ProductId=5,ProductName = "P5"} ,
                                                                  

                                                          }).ToList());

            ProductController controller = new ProductController(mock.Object);

            controller.PageSize = 3;


            //Act
            ProductListViewModel result = (ProductListViewModel) controller.Index(2).Model;


            //Assert
            PagingInfo pagingInfo = result.PagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage,2);
            Assert.AreEqual(pagingInfo.ItemsPerPage,3);
            Assert.AreEqual(pagingInfo.TotalItems,5);
            Assert.AreEqual(pagingInfo.TotalPages,2);
        }

    }
}
