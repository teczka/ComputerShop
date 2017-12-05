namespace ComputerShop.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2310 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssemblyProducts",
                c => new
                    {
                        Assembly_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Assembly_Id, t.Product_Id })
                .ForeignKey("dbo.Assemblies", t => t.Assembly_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Assembly_Id)
                .Index(t => t.Product_Id);
            
            AlterColumn("dbo.Comments", "AssemblyId", c => c.Int());
            CreateIndex("dbo.Comments", "AssemblyId");
            AddForeignKey("dbo.Comments", "AssemblyId", "dbo.Assemblies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssemblyProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.AssemblyProducts", "Assembly_Id", "dbo.Assemblies");
            DropForeignKey("dbo.Comments", "AssemblyId", "dbo.Assemblies");
            DropIndex("dbo.AssemblyProducts", new[] { "Product_Id" });
            DropIndex("dbo.AssemblyProducts", new[] { "Assembly_Id" });
            DropIndex("dbo.Comments", new[] { "AssemblyId" });
            AlterColumn("dbo.Comments", "AssemblyId", c => c.Int(nullable: false));
            DropTable("dbo.AssemblyProducts");
        }
    }
}
