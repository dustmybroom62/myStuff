using System;
using Xunit;
using WebServer.Models;
using WebServer.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebServer.Test.TestOrdering;

namespace WebServer.Test {
    [TestCaseOrderer("WebServer.Test.TestOrdering.TestCollectionOrderer", "WebServer.Test")]
    public class C001_FunctionalTest {

        [Fact, TestPriority(1)]
        public void CreateProductsControllerInstanceTest() {
            var controller = new ProductsController();
            Assert.NotNull(controller);
        }

        [Fact, TestPriority(2)]
        public void RepositoryInitializtionTest() {
            Assert.NotNull(Repository.Products);
            Assert.Equal(4, Repository.Products.Count);

            foreach (var id in new int[] { 0, 1, 2, 3 }) {
                Assert.True(Repository.Products.ContainsKey(id));
            }

            foreach (var key in Repository.Products.Keys) {
                Assert.Equal(Repository.Products[key].ID, key);
            }
        }

        [Fact, TestPriority(3)]
        public void GetActionTest() {
            var controller = new ProductsController();
            Assert.IsType<OkObjectResult>(controller.Get());
            foreach (var key in Repository.Products.Keys) {
                Assert.IsType<OkObjectResult>(controller.Get(key));
            }
        }

        [Fact, TestPriority(4)]
        public void PostActionTest() {
            var controller = new ProductsController();
            int oldCount = Repository.Products.Count;
            var product = new Product { Name = "Test Product", Price = 9.9 };
            Assert.IsType<CreatedResult>(controller.Post(product));
            Assert.Equal(Repository.Products.Count, oldCount + 1);
        }

        [Fact, TestPriority(5)]
        public void DeleteActionTest() {
            var controller = new ProductsController();
            int oldCount = Repository.Products.Count;
            var maxKey = Repository.Products.Keys.Max();
            Assert.IsType<OkResult>(controller.Delete(maxKey));
            Assert.Equal(Repository.Products.Count, oldCount - 1);
        }

        [Fact, TestPriority(6)]
        public void PutActionTest() {
            var controller = new ProductsController();
            int oldCount = Repository.Products.Count;
            var maxKey = Repository.Products.Keys.Max();
            var product = Repository.Products[maxKey];
            product.Name = "Changed";
            Assert.IsType<OkResult>(controller.Put(maxKey, product));
            Assert.Equal(Repository.Products.Count, oldCount);
        }
    }
}