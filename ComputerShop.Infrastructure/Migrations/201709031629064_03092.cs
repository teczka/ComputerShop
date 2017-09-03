namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03092 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Baskets", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Baskets", "OrderId", c => c.Int());
        }
    }
}
