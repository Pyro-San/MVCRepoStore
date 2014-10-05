using System.Data.Entity;
using MVCRepoStore.Entity.Models;

namespace MVCRepoStore.Entity
{
   public class MVCRepoStoreDBContext: DbContext
    {
       public MVCRepoStoreDBContext()
           : base("DefaultConnection")
       {
           Database.SetInitializer<MVCRepoStoreDBContext>(new CreateDatabaseIfNotExists<MVCRepoStoreDBContext>());
       }

       public DbSet<Categories> Categories { get; set; }
       public DbSet<Categories_Images> Categories_Images { get; set; }
       public DbSet<Categories_Products> Categories_Products { get; set; }
       public DbSet<CategoryCultureDetail> CategoryCultureDetail { get; set; }
       public DbSet<Cultures> Cultures { get; set; }
       public DbSet<Images> Images { get; set; }
       public DbSet<ProductCultureDetail> ProductCultureDetail { get; set; }
       public DbSet<ProductDescriptions> ProductDescriptions { get; set; }
       public DbSet<ProductReviews> ProductReviews { get; set; }
       public DbSet<Products> Products { get; set; }
       public DbSet<Products_Images> Products_Images { get; set; }
    }
}
