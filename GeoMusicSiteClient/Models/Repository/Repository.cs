using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GeoMusicSiteClient.Models.DBModel;
using Microsoft.AspNet.Identity.EntityFramework;



namespace GeoMusicSiteClient.Models
{
    public class Repository
    {
        ApplicationDbContext db;

        public Repository()
        {
            db = new ApplicationDbContext();
        }


        #region // User CRUD

        public List<ApplicationUser> GetUsers
        {
            get { return db.Users.ToList<ApplicationUser>(); }
        }

        public ApplicationUser GetUser(string id)
        {

            return db.Users.Find(id);
        }

        public ApplicationUser GetUserEmail(string email)
        {
            //ApplicationUser user = db.Users.Where(u => u.Email == email).FirstOrDefault();
            //List<ApplicationUser> list = new List<ApplicationUser>();
            //list.Add(user);
            return db.Users.Where(u => u.Email == email).FirstOrDefault(); ;
        }

        public List<string>
            Failure()
        {
            List<string> list = new List<string>();
            list.Add("failed");
            return list;
        }

        public void EditUser(UserViewModel user)
        {
            ApplicationUser u = GetUser(user.Id);
            db.Entry(u).State = EntityState.Modified;
            db.UserCategories.RemoveRange(db.UserCategories.Where(c => c.UserId.Id == user.Id));
            List<Category> selectedCategories = GetCategoriesByIds(user.Categories);

            if (user.Categories.Count() != 0)
            {
                foreach (Category cat in selectedCategories)
                {
                    u.UserCategories.Add(new UserCategories { CategoryId = cat, UserId = u });
                }
            }
            else
            {
                if (u.UserCategories.Count != 0)
                {
                    u.UserCategories.Clear();
                }
            }
            u.Email = user.Email;
            u.UserName = user.UserName;
            db.SaveChanges();
        }

        public void EditUserMobile(string email, string username, HttpPostedFileBase image)
        {
            ApplicationUser u = GetUserEmail(email);
            db.Entry(u).State = EntityState.Modified;
            if (image != null)
            {
                string path = new BLL.BlobStorage().StorageImageUser(image);
                u.UserImage = path;
            }
            u.Email = email;
            u.UserName = username;

            db.SaveChanges();
        }

        public List<Category> getUserCategories(string userId)
        {
            return db.UserCategories.Where(u => u.UserId.Id.Equals(userId)).Select(u => u.CategoryId).ToList();
        }
        public UserCategories getUserCategory(string userId, int categoryId)
        {
            return db.UserCategories.Where(c => c.CategoryId.id.Equals(categoryId)).Where(u => u.UserId.Id.Equals(userId)).FirstOrDefault();
        }

        public void CreateUser(ApplicationUser user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            db.Users.Remove(db.Users.Find(id));
            db.SaveChanges();
        }

        public void ChangeUserToken(string userId, string token)
        {
            db.Users.Find(userId).Token = token;
        }

       

        

        #endregion

        #region // Records CRUD

        public List<Record> GetRecords
        {
            get { return db.Records.ToList<Record>(); }
        }

        public Record GetRecord(int id)
        {
            return db.Records.Find(id);
        }

        public void EditRecord(Record record)
        {
            db.Entry(record).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void CreateRecord(Record record)
        {
            db.Records.Add(record);
            db.SaveChanges();
        }

        public void DeleteRecord(int id)
        {
            db.Records.Remove(db.Records.Find(id));
            db.SaveChanges();
        }
        public Record GetLastRecord()
        {
            return db.Records.LastOrDefault();
        }

        public void AddRecordImage(Record record, string path)
        {
            db.Records.Find(record.id).Image = path;
            db.SaveChanges();
        }

        public List<Record> GetUserFavorite(string userId)
        {
            return db.Favorites.Where(u => u.UserId.Id == userId).Select(f => f.RecordId).ToList();
        }

        public List<Record> GetNearRecords(double lat, double lng)
        {

            return db.Records.Where(r => r.Lat <= lat + 0.004 && r.Lat >= lat - 0.004 && r.Long <= lng + 0.004 && r.Long >= lng - 0.004).ToList();
        }

        #endregion

        #region // Playlists CRUD

        public List<Playlist> GetPlaylists
        {
            get { return db.Playlists.ToList<Playlist>(); }
        }

        public List<Playlist> GetUserSubscribedPlaylist(string id)
        {
            return db.Users.Find(id).Subscribe;
        }

        public Playlist GetPlaylist(int id)
        {
            return db.Playlists.Find(id);
        }

        public List<Playlist> GetUserPlaylists(string userId)
        {
            return db.Users.Where(u => u.Id == userId).Select(p => p.Playlists).FirstOrDefault();
        }

        public List<Playlist> GetUserSubscribed(string userId)
        {
            return db.Users.Where(u => u.Id == userId).Select(s => s.Subscribe).FirstOrDefault();
        }

        public void EditPlaylist(Playlist playlist)
        {
            db.Entry(playlist).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void CreatePlaylist(Playlist playlist)
        {
            db.Playlists.Add(playlist);
            db.SaveChanges();
        }

        public void DeletePlaylist(int id)
        {
            db.Playlists.Remove(db.Playlists.Find(id));
            db.SaveChanges();
        }

        public void Subscribe(string userId, int playlistId)
        {

        }

        #endregion

        #region // Category CRUD

        public List<Category> GetCategories
        {
            get { return db.Categories.ToList<Category>(); }
        }

        public List<Category> GetCategoriesByIds(int[] ids)
        {
            List<Category> result = new List<Category>();
            foreach (int i in ids)
            {
                result.Add(db.Categories.Find(i));
            }
            return result;
        }

        public Category GetCategory(int id)
        {
            return db.Categories.Find(id);
        }

        public void EditCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void CreateCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public Category GetLastCategory()
        {
            return db.Categories.LastOrDefault();
        }

        public void AddCategoryImage(int id, string path)
        {
            db.Categories.Find(id).Image = path;
            db.SaveChanges();
        }

        public void EditUserCategory(string userId, int[] categoriesId)
        {

        }

        #endregion

        #region // Role CRUD

        public List<IdentityRole> GetRoles
        {
            get { return db.Roles.ToList<IdentityRole>(); }
        }

        public IdentityRole GetRole(string id)
        {
            return db.Roles.Find(id);
        }

        public void EditRole(IdentityRole role)
        {
            db.Entry(role).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void CreateRole(IdentityRole role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
        }

        public void DeleteRole(string id)
        {
            db.Roles.Remove(db.Roles.Find(id));
            db.SaveChanges();
        }

        public void SetUserRole(string userId, string roleId = "3ca31799-bbb1-43a4-84ea-1852d3e8bf15")
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>());
            ApplicationUser user = GetUser(userId);
            userManager.AddToRoleAsync(userId, roleId);
            db.SaveChanges();
        }

        #endregion
    }
}