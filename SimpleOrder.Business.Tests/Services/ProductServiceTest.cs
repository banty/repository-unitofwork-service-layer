using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleOrder.Business.Models;
using SimpleOrder.Business.Repository;
using SimpleOrder.Business.Service;
using SimpleOrder.Business.UnitWork;


namespace SimpleOrder.Business.Tests.Services
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void Can_Add_Product_Service()
        {
            //Arrange
            List<Product> products = new List<Product>()
                                         {
                                             new Product(){Description="P1",ProductId=1,ProductName="p1Name"},
                                             new Product(){Description="P2",ProductId=2,ProductName="p2Name"},
                                             new Product(){Description="P3",ProductId=3,ProductName="p3Name"},
                                             new Product(){Description="P4",ProductId=4,ProductName="p4Name"},
                                             new Product(){Description="P5",ProductId=5,ProductName="p5Name"},
                                             new Product(){Description="P6",ProductId=6,ProductName="p6Name"},

                                         };
            Mock<IGenericRepository<Product>> mock1 = new Mock<IGenericRepository<Product>>();

            //Here we are going to mock repository GetAll method 
            mock1.Setup(m => m.GetAll()).Returns(products);
          
            //Here we are going to mock repository Add method
            mock1.Setup(m => m.Add(It.IsAny<Product>())).Returns((Product target) =>
            {
                var original = products.FirstOrDefault(
                    q => q.ProductId == target.ProductId);

                if (original != null)
                {
                    return false;
                }

                products.Add(target);

                return true;
            });
          
            //Now we have our repository ready for property injection

            //Here we are going to mock our IUnitOfWork
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            

            //Here we are going to inject our repository to the property 
            //mock.SetupProperty(m => m.ProductRepository).SetReturnsDefault(mock1.Object);
           mock.Setup(m => m.ProductRepository).Returns(mock1.Object);

            //Now our UnitOfWork is ready to be injected to the service
            //Here we inject UnitOfWork to constractor of our service
            ProductService productService = new ProductService(mock.Object);


            //Act
            productService.AddProduct(new Product
                                          {
                                              ProductId = 7,
                                              ProductName = "P7Name",
                                              Description = "P7"
                                          });
            var result = productService.GetAllProduct();
            var newProduct = result.FirstOrDefault(t => t.ProductId == 7);



            //Assert

            Assert.AreEqual(products.Count, result.Count);
            Assert.AreEqual("P7Name", newProduct.ProductName);
            Assert.AreEqual("P7", newProduct.Description);



        }

        [TestMethod]
        public void Can_Get_All_Product_Service()
        {
            //Arrange
            List<Product> products = new List<Product>()
                                         {
                                             new Product(){Description="P1",ProductId=1,ProductName="p1Name"},
                                             new Product(){Description="P2",ProductId=2,ProductName="p2Name"},
                                             new Product(){Description="P3",ProductId=3,ProductName="p3Name"},
                                             new Product(){Description="P4",ProductId=4,ProductName="p4Name"},
                                             new Product(){Description="P5",ProductId=5,ProductName="p5Name"},
                                             new Product(){Description="P6",ProductId=6,ProductName="p6Name"},

                                         };
            Mock<IGenericRepository<Product>> mock1 = new Mock<IGenericRepository<Product>>();

            //Here we are going to mock repository GetAll method 
            mock1.Setup(m => m.GetAll()).Returns(products);

          
            //Now we have our repository ready for property injection

            //Here we are going to mock our IUnitOfWork
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();

            //Here we are going to inject our repository to the property 
            mock.Setup(m => m.ProductRepository).Returns(mock1.Object);


            //Now our UnitOfWork is ready to be injected to the service
            //Here we inject UnitOfWork to constractor of our service
            ProductService productService = new ProductService(mock.Object);


            //Act
            var result = productService.GetAllProduct();
            //Assert
            Assert.AreEqual(products,result);

        }

        [TestMethod]
        public void Can_Update_Product_Service()
        {
            //Arrange
            List<Product> products = new List<Product>()
                                         {
                                             new Product(){Description="P1",ProductId=1,ProductName="p1Name"},
                                             new Product(){Description="P2",ProductId=2,ProductName="p2Name"},
                                             new Product(){Description="P3",ProductId=3,ProductName="p3Name"},
                                             new Product(){Description="P4",ProductId=4,ProductName="p4Name"},
                                             new Product(){Description="P5",ProductId=5,ProductName="p5Name"},
                                             new Product(){Description="P6",ProductId=6,ProductName="p6Name"},

                                         };
            Mock<IGenericRepository<Product>> mock1 = new Mock<IGenericRepository<Product>>();

           
            //Here we are going to mock repository Edit method
            mock1.Setup(m => m.Edit(It.IsAny<Product>())).Returns((Product target) =>
            {
                var original = products.FirstOrDefault(
                    q => q.ProductId == target.ProductId);

                if (original == null)
                {
                    return false;
                }

                original.ProductName = target.ProductName;

                original.Description = target.Description;

                return true;
            });

           
            //Now we have our repository ready for property injection

            //Here we are going to mock our IUnitOfWork
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();

            //Here we are going to inject our repository to the property 
            mock.Setup(m => m.ProductRepository).Returns(mock1.Object);


            //Now our UnitOfWork is ready to be injected to the service
            //Here we inject UnitOfWork to constractor of our service
            ProductService productService = new ProductService(mock.Object);


            //Act

            var updatedProduct = new Product() {ProductId = 1, ProductName = "p1NameModified", Description = "p1Modified"};
            productService.UpdateProduct(updatedProduct);
            var actualProduct = products.FirstOrDefault(t => t.ProductId == 1);
            //Assert
            
            Assert.AreEqual(actualProduct.ProductName ,updatedProduct.ProductName);
            Assert.AreEqual(actualProduct.Description, updatedProduct.Description);

        }
        [TestMethod]
        public void Can_Delete_Product_Service()
        {
            //Arrange
            List<Product> products = new List<Product>()
                                         {
                                             new Product(){Description="P1",ProductId=1,ProductName="p1Name"},
                                             new Product(){Description="P2",ProductId=2,ProductName="p2Name"},
                                             new Product(){Description="P3",ProductId=3,ProductName="p3Name"},
                                             new Product(){Description="P4",ProductId=4,ProductName="p4Name"},
                                             new Product(){Description="P5",ProductId=5,ProductName="p5Name"},
                                             new Product(){Description="P6",ProductId=6,ProductName="p6Name"},

                                         };
            Mock<IGenericRepository<Product>> mock1 = new Mock<IGenericRepository<Product>>();

            //Here we are going to mock repository FindById Method
            mock1.Setup(m => m.FindById(It.IsAny<int>())).Returns((int i) => products.Single(x => x.ProductId == i));

            //Here we are going to mock repository Delete method
            mock1.Setup(m => m.Delete(It.IsAny<Product>())).Returns((Product target) =>
            {

                var original = products.FirstOrDefault(
                    q => q.ProductId == target.ProductId);

                if (original == null)
                {
                    return false;
                }

                products.Remove(target);

                return true;
            });
          
            //Now we have our repository ready for property injection

            //Here we are going to mock our IUnitOfWork
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();

            //Here we are going to inject our repository to the property 
            mock.Setup(m => m.ProductRepository).Returns(mock1.Object);


            //Now our UnitOfWork is ready to be injected to the service
            //Here we inject UnitOfWork to constractor of our service
            ProductService productService = new ProductService(mock.Object);


            //Act

            productService.DeleteProduct(6);
            var result = products.FirstOrDefault(t => t.ProductId == 6);
            //Assert
            Assert.IsNull(result);
            Assert.IsTrue(products.Count ==5);


        }

        [TestMethod]
        public void Can_Find_By_Id()
        {
            //Arrange
            List<Product> products = new List<Product>()
                                         {
                                             new Product(){Description="P1",ProductId=1,ProductName="p1Name"},
                                             new Product(){Description="P2",ProductId=2,ProductName="p2Name"},
                                             new Product(){Description="P3",ProductId=3,ProductName="p3Name"},
                                             new Product(){Description="P4",ProductId=4,ProductName="p4Name"},
                                             new Product(){Description="P5",ProductId=5,ProductName="p5Name"},
                                             new Product(){Description="P6",ProductId=6,ProductName="p6Name"},

                                         };
            Mock<IGenericRepository<Product>> mock1 = new Mock<IGenericRepository<Product>>();

            //Here we are going to mock repository FindById Method
            mock1.Setup(m => m.FindById(It.IsAny<int>())).Returns((int i) => products.Single(x => x.ProductId == i));

            //Now we have our repository ready for property injection

            //Here we are going to mock our IUnitOfWork
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();

            //Here we are going to inject our repository to the property 
            mock.Setup(m => m.ProductRepository).Returns(mock1.Object);


            //Now our UnitOfWork is ready to be injected to the service
            //Here we inject UnitOfWork to constractor of our service
            ProductService productService = new ProductService(mock.Object);


            //Act

            var result = productService.GetProduct(6);
            var expected = products.Single(t => t.ProductId == 6);

            //Assert

            Assert.AreEqual(expected,result);
        }
    }
}
