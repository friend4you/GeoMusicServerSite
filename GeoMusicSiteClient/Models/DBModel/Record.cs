using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GeoMusicSiteClient.Models.DBModel
{
    public class Record:Entity
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Description { get; set; }
        public DateTime AddDate { get; set; }
        public string Url { get; set; }
        public Double Lat { get; set; }
        public Double Long { get; set; }
        public string Image { get; set; }
         
    }
}