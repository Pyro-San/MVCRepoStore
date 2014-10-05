using System;
using System.Collections.Generic;
using System.Linq;
using MVCRepoStore.Data;
using MVCRepoStore.Repository;
using MVCRepoStore.Repository.Filters;

namespace MVCRepoStore.Service
{
   public  class CatalogService
    {
       private readonly ICatalogRepository _catalogRepository;

       public CatalogService(ICatalogRepository catalogRepository)
       {
           _catalogRepository = catalogRepository;
           if(_catalogRepository == null)
               throw new InvalidOperationException("Repository cannot be null");
       }

       public List<Category> GetCategories()
       {
           var rawCategories = _catalogRepository.GetCategories().ToList();
           var parents = (from c in rawCategories
               where c.ParentId == 0
               select c).ToList();

           parents.ForEach(p =>
           {
               p.SubCategories = (from subs in rawCategories
                   where subs.ParentId == p.Id
                   select subs).ToList();
           });
           return parents;
       }

       public IList<Product> GetProductsByCategory(int categoryId)
       {
           return _catalogRepository.GetProducts().WithCategory(categoryId).ToList();
       }

       public Product GetProductById(int id)
       {
           return _catalogRepository.GetProducts().WithId(id).First();
       }
    }
}
