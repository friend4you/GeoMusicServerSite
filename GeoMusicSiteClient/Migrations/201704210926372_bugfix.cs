namespace GeoMusicSiteClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bugfix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ExpireDate", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "ExpireTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ExpireTime", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "ExpireDate");
        }
    }
}
