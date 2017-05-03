namespace GeoMusicSiteClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _107 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Categories", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Categories", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Categories", "ApplicationUser_Id");
            AddForeignKey("dbo.Categories", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
