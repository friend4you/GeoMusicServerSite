using GeoMusicSiteClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GeoMusicSiteClient.Controllers.api
{
    public class ApiController : Controller
    {
        Repository db = new Repository();
        // GET: Api
        public JsonResult Index()
        {
            return Json("index json");
        }
        public RedirectResult CreatePlaylist()
        {
            return new RedirectResult("/Admin/Playlists");
        }

        public JsonResult GetPlaylists()
        {
            return Json(db.GetPlaylists, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserSubscribedPlaylist(string userId)
        {
            return Json(db.GetUserSubscribedPlaylist(userId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlaylist(int playlistId)
        {
            return Json(db.GetPlaylist(playlistId), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetRecord(int id)
        {
            return Json(db.GetRecord(id), JsonRequestBehavior.AllowGet);
        }

        public HttpStatusCodeResult Subscribe(string userId, int playlistId)
        {

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        public HttpStatusCodeResult UnSubscribe(string userId, int playlistId)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        public JsonResult GetCategories()
        {
            return Json(db.GetCategories, JsonRequestBehavior.AllowGet);
        }

        public HttpStatusCodeResult SaveUserInfo(string email, string username)
        {

            if (Request.Files.Count > 0)
            {
                var image = Request.Files[0];
                if (image == null || image.ContentLength == 0)
                {
                    db.EditUserMobile(email, username, null);

                }
                else
                {
                    db.EditUserMobile(email, username, image);
                }
                if (email.Equals("") || username.Equals(""))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NoContent);
                }


            }
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public JsonResult GetUserFavorites(string userId)
        {
            return Json(db.GetUserFavorite(userId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNearRecords(double latitude, double longitude)
        {
            return Json(db.GetNearRecords(latitude, longitude), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRecords()
        {
            return Json(db.GetRecords, JsonRequestBehavior.AllowGet);
        }

    }
}