using System.Collections.Generic;
using System.Linq;
using MVCRepoStore.Data;
using MVCRepoStore.Repository;

namespace MVCRepoStore.Tests
{
    public class TestCatalogRepository : ICatalogRepository
    {
        public IQueryable<Category> GetCategories()
        {
            IList<Category> result = new List<Category>();
            for (int i = 1; i <= 2; i++)
            {
                var c = new Category {Id = i, Name = "Parent" + i, ParentId = 0};
                for (int x = 10; x < 15; x++)
                {
                    var sub = new Category {Id = x*i, Name = "Sub" + x, ParentId = i};
                    result.Add(sub);
                }
                result.Add(c);
            }
            return result.AsQueryable();
        }

        public IQueryable<Product> GetProducts()
        {
            IList<Product> result = new List<Product>();
            // loop got each category
            var loopIndex = 0;
            var uniqueProductId = 1;

            var categories = GetCategories().Where(x => x.ParentId > 0).ToList();

            foreach (var c in categories)
            {
                for (var y = 1; y <= 5; y++)
                {
                    var p = new Product
                    {
                        Name = "Product" + loopIndex,
                        Id = uniqueProductId,
                        ListPrice = y*5.68M,
                        Description = "Test Description",
                        CategoryId = c.Id
                    };
                    uniqueProductId++;
                    result.Add(p);
                }
                loopIndex++;
            }
            return result.AsQueryable();
        }

        public IQueryable<ProductReview> GetReviews()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductDesctiption> GetDesctiptions()
        {
            throw new System.NotImplementedException();
        }
    }
}
