namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03091 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Baskets", "OrderId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Baskets", "OrderId", c => c.Int(nullable: false));
        }
    }
}
