using System.Linq;
using MVCRepoStore.Data;

namespace MVCRepoStore.Repository.Filters
{
    public static class ProductFilters
    {

        public static IQueryable<Product> WithCategory(this IQueryable<Product> qry,
            int categoryId)
        {
            
        }
    }
}
