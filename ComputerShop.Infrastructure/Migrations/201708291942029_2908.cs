namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2908 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BasketItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.BasketItems", new[] { "Product_Id" });
            AddColumn("dbo.BasketItems", "ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.BasketItems", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BasketItems", "Product_Id", c => c.Int());
            DropColumn("dbo.BasketItems", "ProductId");
            CreateIndex("dbo.BasketItems", "Product_Id");
            AddForeignKey("dbo.BasketItems", "Product_Id", "dbo.Products", "Id");
        }
    }
}
