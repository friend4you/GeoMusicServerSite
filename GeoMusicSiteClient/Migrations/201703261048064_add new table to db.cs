namespace GeoMusicSiteClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewtabletodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsingPlaylists",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CheckTime = c.DateTime(nullable: false),
                        Playlist_id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Playlists", t => t.Playlist_id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Playlist_id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsingPlaylists", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsingPlaylists", "Playlist_id", "dbo.Playlists");
            DropIndex("dbo.UsingPlaylists", new[] { "User_Id" });
            DropIndex("dbo.UsingPlaylists", new[] { "Playlist_id" });
            DropTable("dbo.UsingPlaylists");
        }
    }
}
