namespace MVCRepoStore.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReDesignDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDescriptions", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductDescriptions", new[] { "ProductId" });
            RenameColumn(table: "dbo.ProductDescriptions", name: "ProductId", newName: "Product_ProductId");
            RenameColumn(table: "dbo.ProductReviews", name: "Products_ProductId", newName: "Product_ProductId");
            RenameIndex(table: "dbo.ProductReviews", name: "IX_Products_ProductId", newName: "IX_Product_ProductId");
            CreateTable(
                "dbo.Categories_Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_CategoryId = c.Int(),
                        Image_ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.Images", t => t.Image_ImageId)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.Image_ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ThumbUrl = c.String(),
                        FullImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateTable(
                "dbo.Categories_Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_CategoryId = c.Int(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.CategoryCultureDetails",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Culture_CultureId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Cultures", t => t.Culture_CultureId)
                .Index(t => t.Culture_CultureId);
            
            CreateTable(
                "dbo.ProductCultureDetails",
                c => new
                    {
                        ProductCultureDetailId = c.Int(nullable: false, identity: true),
                        Desctiption = c.String(),
                        ShortDescription = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Culture_CultureId = c.Int(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductCultureDetailId)
                .ForeignKey("dbo.Cultures", t => t.Culture_CultureId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Culture_CultureId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Products_Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image_ImageId = c.Int(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.Image_ImageId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Image_ImageId)
                .Index(t => t.Product_ProductId);
            
            AddColumn("dbo.Cultures", "DefaultCurrencyCode", c => c.String());
            AddColumn("dbo.ProductDescriptions", "Culture_CultureId", c => c.Int());
            AddColumn("dbo.Products", "ProductCode", c => c.String());
            AddColumn("dbo.Products", "BaseUnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ProductDescriptions", "Product_ProductId", c => c.Int());
            CreateIndex("dbo.ProductDescriptions", "Culture_CultureId");
            CreateIndex("dbo.ProductDescriptions", "Product_ProductId");
            AddForeignKey("dbo.ProductDescriptions", "Culture_CultureId", "dbo.Cultures", "CultureId");
            AddForeignKey("dbo.ProductDescriptions", "Product_ProductId", "dbo.Products", "ProductId");
            DropColumn("dbo.Cultures", "CurrencyCode");
            DropColumn("dbo.ProductDescriptions", "CultureId");
            DropColumn("dbo.ProductReviews", "ProductId");
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "UnitPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductReviews", "ProductId", c => c.String());
            AddColumn("dbo.ProductDescriptions", "CultureId", c => c.Int(nullable: false));
            AddColumn("dbo.Cultures", "CurrencyCode", c => c.String());
            DropForeignKey("dbo.ProductDescriptions", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Products_Images", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Products_Images", "Image_ImageId", "dbo.Images");
            DropForeignKey("dbo.ProductDescriptions", "Culture_CultureId", "dbo.Cultures");
            DropForeignKey("dbo.ProductCultureDetails", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCultureDetails", "Culture_CultureId", "dbo.Cultures");
            DropForeignKey("dbo.CategoryCultureDetails", "Culture_CultureId", "dbo.Cultures");
            DropForeignKey("dbo.Categories_Products", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Categories_Products", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories_Images", "Image_ImageId", "dbo.Images");
            DropForeignKey("dbo.Categories_Images", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products_Images", new[] { "Product_ProductId" });
            DropIndex("dbo.Products_Images", new[] { "Image_ImageId" });
            DropIndex("dbo.ProductDescriptions", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductDescriptions", new[] { "Culture_CultureId" });
            DropIndex("dbo.ProductCultureDetails", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductCultureDetails", new[] { "Culture_CultureId" });
            DropIndex("dbo.CategoryCultureDetails", new[] { "Culture_CultureId" });
            DropIndex("dbo.Categories_Products", new[] { "Product_ProductId" });
            DropIndex("dbo.Categories_Products", new[] { "Category_CategoryId" });
            DropIndex("dbo.Categories_Images", new[] { "Image_ImageId" });
            DropIndex("dbo.Categories_Images", new[] { "Category_CategoryId" });
            AlterColumn("dbo.ProductDescriptions", "Product_ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "BaseUnitPrice");
            DropColumn("dbo.Products", "ProductCode");
            DropColumn("dbo.ProductDescriptions", "Culture_CultureId");
            DropColumn("dbo.Cultures", "DefaultCurrencyCode");
            DropTable("dbo.Products_Images");
            DropTable("dbo.ProductCultureDetails");
            DropTable("dbo.CategoryCultureDetails");
            DropTable("dbo.Categories_Products");
            DropTable("dbo.Images");
            DropTable("dbo.Categories_Images");
            RenameIndex(table: "dbo.ProductReviews", name: "IX_Product_ProductId", newName: "IX_Products_ProductId");
            RenameColumn(table: "dbo.ProductReviews", name: "Product_ProductId", newName: "Products_ProductId");
            RenameColumn(table: "dbo.ProductDescriptions", name: "Product_ProductId", newName: "ProductId");
            CreateIndex("dbo.ProductDescriptions", "ProductId");
            AddForeignKey("dbo.ProductDescriptions", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
