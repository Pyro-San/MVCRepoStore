using System.Linq;
using MVCRepoStore.Data;
using MVCRepoStore.SqlRepository;

namespace MVCRepoStore.Repository
{
    public class SqlCatalogRepository : ICatalogRepository
    {
        public IQueryable<Category> GetCategories()
        {
            var ctx = new DB();
            return from c in ctx.Categories
                   select new MVCRepoStore.Data.Category
                {
                    Id = c.CategoryId,
                    Name = c.CategoryName,
                    ParentId = c.ParentId ?? 0
                };

        }

        public IQueryable<Product> GetProducts()
        {
            throw new System.NotImplementedException();
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
