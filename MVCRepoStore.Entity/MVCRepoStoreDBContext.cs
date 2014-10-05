﻿using System.Data.Entity;
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
       public DbSet<Cultures> Cultures { get; set; }
       public DbSet<ProductDescriptions> ProductDescriptions { get; set; }
       public DbSet<ProductReviews> ProductReviews { get; set; }
       public DbSet<Products> Products { get; set; }
    }
}
