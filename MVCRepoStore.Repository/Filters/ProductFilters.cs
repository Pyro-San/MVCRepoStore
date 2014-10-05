using System;
using System.Linq;
using MVCRepoStore.Data;

namespace MVCRepoStore.Repository.Filters
{
    public static class ProductFilters
    {

        public static IQueryable<Product> WithCategory(this IQueryable<Product> qry,
            int categoryId)
        {
            return from p in qry
                where p.CategoryId == categoryId
                select p;
        }

        public static IQueryable<Product> WithId(this IQueryable<Product> qry,
            int productId)
        {
            return from p in qry
                where p.Id == productId
                select p;
        }
    }
}
