using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GeoMusicSiteClient.Models.DBModel
{
    public class Playlist: Entity
    {         
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }        
        public virtual List<Record> Records { get; set; }
        public virtual Category Category { get; set; }
    }
}