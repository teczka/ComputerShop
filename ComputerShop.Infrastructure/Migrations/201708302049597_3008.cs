namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3008 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        City = c.String(),
                        PostCode = c.String(),
                        Line = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        BasketId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskets", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        AmountOfProducts = c.Int(nullable: false),
                        Basket_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskets", t => t.Basket_Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.Basket_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        ProducentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Producents", t => t.ProducentId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ProducentId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        GroupId = c.Int(nullable: false),
                        IsAssemblyCategory = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.FeaturesForCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeatureId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.FeatureId, cascadeDelete: true)
                .Index(t => t.FeatureId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeatureValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FeatureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.FeatureId, cascadeDelete: true)
                .Index(t => t.FeatureId);
            
            CreateTable(
                "dbo.FeatureValueForProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        FeatureValueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FeatureValues", t => t.FeatureValueId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.FeatureValueId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Producents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Id", "dbo.Baskets");
            DropForeignKey("dbo.Baskets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "ProducentId", "dbo.Producents");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.FeatureValueForProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.FeatureValueForProducts", "FeatureValueId", "dbo.FeatureValues");
            DropForeignKey("dbo.FeatureValues", "FeatureId", "dbo.Features");
            DropForeignKey("dbo.FeaturesForCategories", "FeatureId", "dbo.Features");
            DropForeignKey("dbo.FeaturesForCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.BasketItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets");
            DropIndex("dbo.FeatureValueForProducts", new[] { "FeatureValueId" });
            DropIndex("dbo.FeatureValueForProducts", new[] { "ProductId" });
            DropIndex("dbo.FeatureValues", new[] { "FeatureId" });
            DropIndex("dbo.FeaturesForCategories", new[] { "CategoryId" });
            DropIndex("dbo.FeaturesForCategories", new[] { "FeatureId" });
            DropIndex("dbo.Categories", new[] { "GroupId" });
            DropIndex("dbo.Products", new[] { "ProducentId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.BasketItems", new[] { "Basket_Id" });
            DropIndex("dbo.BasketItems", new[] { "ProductId" });
            DropIndex("dbo.Baskets", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "Id" });
            DropIndex("dbo.Addresses", new[] { "Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Producents");
            DropTable("dbo.Groups");
            DropTable("dbo.FeatureValueForProducts");
            DropTable("dbo.FeatureValues");
            DropTable("dbo.Features");
            DropTable("dbo.FeaturesForCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.BasketItems");
            DropTable("dbo.Baskets");
            DropTable("dbo.Orders");
            DropTable("dbo.Addresses");
        }
    }
}
