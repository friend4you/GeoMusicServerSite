using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoMusicSiteClient.Models.DBModel
{
    public class UserCategories : Entity
    {
        public virtual ApplicationUser UserId { get; set; }
        public virtual Category CategoryId { get; set; }
    }
}