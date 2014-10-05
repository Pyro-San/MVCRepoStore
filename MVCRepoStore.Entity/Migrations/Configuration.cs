using MVCRepoStore.Entity.Models;

namespace MVCRepoStore.Entity.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCRepoStoreDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCRepoStoreDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Categories.AddOrUpdate(
                p => p.Name,
                new Categories{Name = "category1"},
                new Categories{Name = "category2"},
                new Categories{Name = "category3"},
                new Categories{Name = "category4"},
                new Categories{Name = "category5"},
                new Categories{Name = "category6"}
                );
        }
    }
}
