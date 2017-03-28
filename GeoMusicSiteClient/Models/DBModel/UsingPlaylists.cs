using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoMusicSiteClient.Models.DBModel
{
    public class UsingPlaylists : Entity
    {
        public virtual ApplicationUser User { get; set; }
        public virtual Playlist Playlist { get; set; }
        public DateTime CheckTime { get; set; }
    }
}