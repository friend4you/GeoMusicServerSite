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
        Repository repo = new Repository();
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
            return Json(repo.GetPlaylists, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserSubscribedPlaylist(string userId)
        {
            return Json(repo.GetUserSubscribedPlaylist(userId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlaylist(int playlistId)
        {
            return Json(repo.GetPlaylist(playlistId), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetRecord(int id)
        {
            return Json(repo.GetRecord(id), JsonRequestBehavior.AllowGet);
        }

        public HttpStatusCodeResult Subscribe(string userId, int playlistId)
        {
            
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        public HttpStatusCodeResult UnSubscribe(string userId, int playlistId)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}