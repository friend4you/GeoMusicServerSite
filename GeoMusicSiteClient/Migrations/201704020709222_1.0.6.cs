namespace GeoMusicSiteClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _106 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCategories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CategoryId_id = c.Int(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.CategoryId_id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.CategoryId_id)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCategories", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserCategories", "CategoryId_id", "dbo.Categories");
            DropIndex("dbo.UserCategories", new[] { "UserId_Id" });
            DropIndex("dbo.UserCategories", new[] { "CategoryId_id" });
            DropTable("dbo.UserCategories");
        }
    }
}
