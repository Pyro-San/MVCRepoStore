namespace MVCRepoStore.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Cultures",
                c => new
                    {
                        CultureId = c.Int(nullable: false, identity: true),
                        LanguageCode = c.String(),
                        Locale = c.String(),
                        CurrencyCode = c.String(),
                    })
                .PrimaryKey(t => t.CultureId);
            
            CreateTable(
                "dbo.ProductDescriptions",
                c => new
                    {
                        ProductDescriptionId = c.Int(nullable: false, identity: true),
                        CultureId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProductDescriptionId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductReviews",
                c => new
                    {
                        ProductReviewId = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Body = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        Email = c.String(),
                        ProductId = c.String(),
                        Products_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductReviewId)
                .ForeignKey("dbo.Products", t => t.Products_ProductId)
                .Index(t => t.Products_ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        ProductName = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductReviews", "Products_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductDescriptions", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductReviews", new[] { "Products_ProductId" });
            DropIndex("dbo.ProductDescriptions", new[] { "ProductId" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductReviews");
            DropTable("dbo.ProductDescriptions");
            DropTable("dbo.Cultures");
            DropTable("dbo.Categories");
        }
    }
}
