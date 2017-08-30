namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29082 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BasketItems", "ProductId");
            AddForeignKey("dbo.BasketItems", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "ProductId", "dbo.Products");
            DropIndex("dbo.BasketItems", new[] { "ProductId" });
        }
    }
}
