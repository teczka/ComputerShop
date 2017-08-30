namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29081 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Baskets", "IsClosed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Baskets", "IsClosed");
        }
    }
}
