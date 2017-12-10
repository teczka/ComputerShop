namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1012 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "AddDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "AddDate");
        }
    }
}
