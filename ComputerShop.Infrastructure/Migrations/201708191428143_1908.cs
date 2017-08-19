namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1908 : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        ProducentId = c.Int(nullable: false),
                        IsComponent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Producents", t => t.ProducentId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ProducentId);
            
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
            DropForeignKey("dbo.FeatureValueForProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProducentId", "dbo.Producents");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.FeatureValueForProducts", "FeatureValueId", "dbo.FeatureValues");
            DropForeignKey("dbo.FeatureValues", "FeatureId", "dbo.Features");
            DropForeignKey("dbo.Categories", "GroupId", "dbo.Groups");
            DropIndex("dbo.Products", new[] { "ProducentId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.FeatureValues", new[] { "FeatureId" });
            DropIndex("dbo.FeatureValueForProducts", new[] { "FeatureValueId" });
            DropIndex("dbo.FeatureValueForProducts", new[] { "ProductId" });
            DropIndex("dbo.Categories", new[] { "GroupId" });
            DropTable("dbo.Users");
            DropTable("dbo.Producents");
            DropTable("dbo.Products");
            DropTable("dbo.FeatureValues");
            DropTable("dbo.FeatureValueForProducts");
            DropTable("dbo.Features");
            DropTable("dbo.Groups");
            DropTable("dbo.Categories");
        }
    }
}
