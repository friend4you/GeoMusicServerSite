using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using GeoMusicSiteClient.Models.DBModel;
using System.Collections.Generic;

namespace GeoMusicSiteClient.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Playlist> Subscribe { get; set; }
        public virtual List<Record> Favorites { get; set; }
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }
        public string UserImage { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Playlist> Playlists { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Record> Records { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<UsingPlaylists> UsingPlaylists { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}