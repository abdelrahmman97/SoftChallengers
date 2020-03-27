namespace Soft_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCategoryID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Works", "category_Id", "dbo.Categories");
            DropIndex("dbo.Works", new[] { "category_Id" });
            RenameColumn(table: "dbo.Works", name: "category_Id", newName: "CategoryID");
            AlterColumn("dbo.Works", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Works", "CategoryID");
            AddForeignKey("dbo.Works", "CategoryID", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Works", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Works", new[] { "CategoryID" });
            AlterColumn("dbo.Works", "CategoryID", c => c.Int());
            RenameColumn(table: "dbo.Works", name: "CategoryID", newName: "category_Id");
            CreateIndex("dbo.Works", "category_Id");
            AddForeignKey("dbo.Works", "category_Id", "dbo.Categories", "Id");
        }
    }
}
