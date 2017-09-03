namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0309 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Baskets", "OrderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Baskets", "OrderId");
        }
    }
}
