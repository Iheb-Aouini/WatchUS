using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WatchAndUs.Controllers
{
    public class VideosController : Controller
    {
        // GET: Videos
        public ActionResult homevideo()
        {
            return View("homevideo");
        }
    }
}