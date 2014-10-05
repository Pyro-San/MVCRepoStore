using System.Linq;
using MVCRepoStore.Data;

namespace MVCRepoStore.Repository
{
    public interface ICatalogRepository
    {
        IQueryable<Category> GetCategories();
        IQueryable<Product> GetProducts();
        IQueryable<ProductReview> GetReviews();
        IQueryable<ProductDesctiption> GetDesctiptions();
    }
}
