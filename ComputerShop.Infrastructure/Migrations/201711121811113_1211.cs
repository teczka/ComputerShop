namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1211 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assemblies", "IsFinished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assemblies", "IsFinished");
        }
    }
}
