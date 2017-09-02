namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0209 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsRequiredToAssembly", c => c.Boolean(nullable: false));
            AddColumn("dbo.Features", "IsAssemblyFeature", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Features", "IsAssemblyFeature");
            DropColumn("dbo.Categories", "IsRequiredToAssembly");
        }
    }
}
