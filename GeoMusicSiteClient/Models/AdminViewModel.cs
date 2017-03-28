using GeoMusicSiteClient.Models.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeoMusicSiteClient.Models
{
    public class UserViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Categories")]
        public int[] categories { get; set; }      
        
    }

    public class RecordViewModel
    {

    }

    public class PlaylistViewModel
    {               
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Author")]
        public string Author { get; set; }        

        [Required]        
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}