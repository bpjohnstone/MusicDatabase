using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicDatabase.Web.Controllers
{
    public class MusicalEventsController : Controller
    {
        // GET: MusicalEvents
        public ActionResult Index()
        {
            return View();
        }
    }
}