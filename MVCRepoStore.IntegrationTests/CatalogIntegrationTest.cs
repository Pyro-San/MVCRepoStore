using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCRepoStore.Data;
using MVCRepoStore.Repository;

namespace MVCRepoStore.IntegrationTests
{
    [TestClass]
    public class CatalogIntegrationTest
    {
        [TestMethod]
        public void SqlCatalogRepository_Should_Return_Categories_AsQueryable()
        {
            var rep = new SqlCatalogRepository();

            // this shouldn't be null
            IQueryable<Category> qry = rep.GetCategories();
            Assert.IsNotNull(qry);

            // this should woerk too
            IList<Category> catList = (from c in qry
                where c.Id == 1
                select c).ToList<Category>();
                
            // this should fire the query
            Assert.AreEqual(1, catList.Count);
            Assert.AreEqual(catList[0].Name, "category1");
        }
    }
}
