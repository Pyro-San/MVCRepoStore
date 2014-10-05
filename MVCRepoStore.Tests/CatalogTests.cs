using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCRepoStore.Data;
using MVCRepoStore.Repository;
using MVCRepoStore.Repository.Filters;
using MVCRepoStore.Service;

namespace MVCRepoStore.Tests
{
    [TestClass]
    public class CatalogTests
    {
        private CatalogService _catalogService;
        [TestInitialize]
        public void Setup()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            _catalogService = new CatalogService(rep);
        }

        #region Repository and Service Tests
        [TestMethod]
        public void CatalogRepository_Repository_IsNotNull()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            Assert.IsNotNull(rep.GetCategories());
        }

        [TestMethod]
        public void CatalogService_Can_Get_Categories_From_Service()
        {
            IList<Category> categories = _catalogService.GetCategories();
            Assert.IsTrue(categories.Count > 0);
        }

        [TestMethod]
        public void CatalogService_Can_Group_ParentCategories()
        {
            IList<Category> categories = _catalogService.GetCategories();
            Assert.AreEqual(2, categories.Count);
        }

        [TestMethod]
        public void CatalogService_Can_Group_SubCategories()
        {
            IList<Category> categories = _catalogService.GetCategories();
            Assert.AreEqual(5, categories[0].SubCategories.Count);
        }
        #endregion

        #region Product Tests

        [TestMethod]
        public void Product_Discount_Amount_Is_Valid()
        {
            var p = new Product { ListPrice = 100, DiscountPercent = 40 };
            Assert.AreEqual(p.DiscountAmount, 40);
        }

        [TestMethod]
        public void Product_Discount_Price_Is_Valid()
        {
            var p = new Product { ListPrice = 100, DiscountPercent = 40 };
            Assert.AreEqual(p.DiscountPrice, 60);
        }

        [TestMethod]
        public void Product_ShouldHave_Name_Description_Category_Price_Discount_Fields()
        {
            var p = new Product("TestName", "TestDescription", 10, 100, 20);
            Assert.AreEqual("TestName", p.Name);
            Assert.AreEqual("TestDescription",p.Description);
            Assert.AreEqual(10, p.CategoryId);
            Assert.AreEqual(20,p.DiscountPercent);
            Assert.AreEqual(100, p.ListPrice);
        }

        [TestMethod]
        public void CatalogRepository_Contains_Products()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            Assert.IsNotNull(rep.GetProducts());
        }

        [TestMethod]
        public void CatalogRepository_Each_Category_Contains_5_Products()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            var categories = rep.GetCategories().Where(c => c.ParentId != 0).ToList();
            var products = rep.GetProducts().ToList();
            foreach (
                var productCount in
                    categories.Select(c => (from p in products where p.CategoryId == c.Id select p).Count()))
            {
                Assert.AreEqual(5, productCount);
            }
            Assert.IsNotNull(rep.GetProducts());
        }

        [TestMethod]
        public void Repository_Has_Category_Filter_For_Products()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            IList<Product> products = rep.GetProducts()
                .WithCategory(11)
                .ToList();
            Assert.IsNotNull(products);
        }

        [TestMethod]
        public void Repository_ProductFilter_Returns_5_Products_With_Category_11()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            IList<Product> products = rep.GetProducts()
                .WithCategory(11).ToList();

            Assert.AreEqual(5, products.Count);

        }

        [TestMethod]
        public void CatalogServie_Returns_5_Products_With_Category_11()
        {
            IList<Product> products = _catalogService.GetProductsByCategory(11);
            Assert.AreEqual(5, products.Count);
        }

        [TestMethod]
        public void Repository_Returns_Single_Product_when_Filtered_ById_1()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            IList<Product> products = rep.GetProducts()
                .WithId(1).ToList();

            Assert.AreEqual(1, products.Count);
        }

        [TestMethod]
        public void CatalogService_Returns_Singel_Product_With_ProductId_1()
        {
            Product p = _catalogService.GetProductById(1);
            Assert.IsNotNull(p);
        }
        #endregion


    }
}
