namespace GeoMusicSiteClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addusertoken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Token", c => c.String());
            AddColumn("dbo.AspNetUsers", "ExpireTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "Surnname");
            DropColumn("dbo.AspNetUsers", "VkToken");
            DropColumn("dbo.AspNetUsers", "GoogleToken");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "GoogleToken", c => c.String());
            AddColumn("dbo.AspNetUsers", "VkToken", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surnname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "ExpireTime");
            DropColumn("dbo.AspNetUsers", "Token");
        }
    }
}
