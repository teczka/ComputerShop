namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2708 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountOfProducts = c.Int(nullable: false),
                        Product_Id = c.Int(),
                        Basket_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Baskets", t => t.Basket_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Basket_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        BasketId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskets", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Baskets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "Id", "dbo.Baskets");
            DropForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets");
            DropForeignKey("dbo.BasketItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "Id" });
            DropIndex("dbo.BasketItems", new[] { "Basket_Id" });
            DropIndex("dbo.BasketItems", new[] { "Product_Id" });
            DropIndex("dbo.Baskets", new[] { "UserId" });
            DropTable("dbo.Orders");
            DropTable("dbo.BasketItems");
            DropTable("dbo.Baskets");
        }
    }
}
