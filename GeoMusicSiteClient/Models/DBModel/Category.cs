using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GeoMusicSiteClient.Models.DBModel
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }

    }
}