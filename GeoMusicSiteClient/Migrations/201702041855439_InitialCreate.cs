namespace GeoMusicSiteClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Color = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RecordId_id = c.Int(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Records", t => t.RecordId_id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.RecordId_id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Artist = c.String(),
                        Description = c.String(),
                        AddDate = c.DateTime(nullable: false),
                        Url = c.String(),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                        Image = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Playlist_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Playlists", t => t.Playlist_id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Playlist_id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surnname = c.String(),
                        VkToken = c.String(),
                        GoogleToken = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        Category_id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.Category_id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id1)
                .Index(t => t.Category_id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id1);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PlaylistId_id = c.Int(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Playlists", t => t.PlaylistId_id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.PlaylistId_id)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscribes", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subscribes", "PlaylistId_id", "dbo.Playlists");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Favorites", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Playlists", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Playlists", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Records", "Playlist_id", "dbo.Playlists");
            DropForeignKey("dbo.Playlists", "Category_id", "dbo.Categories");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Records", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favorites", "RecordId_id", "dbo.Records");
            DropIndex("dbo.Subscribes", new[] { "UserId_Id" });
            DropIndex("dbo.Subscribes", new[] { "PlaylistId_id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Playlists", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Playlists", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Playlists", new[] { "Category_id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Records", new[] { "Playlist_id" });
            DropIndex("dbo.Records", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Favorites", new[] { "UserId_Id" });
            DropIndex("dbo.Favorites", new[] { "RecordId_id" });
            DropIndex("dbo.Categories", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Subscribes");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Playlists");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Records");
            DropTable("dbo.Favorites");
            DropTable("dbo.Categories");
        }
    }
}
