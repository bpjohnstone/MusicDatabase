using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicDatabase.Services;

namespace MusicDatabase.Web.Controllers
{
    public class MusicalEventsController : Controller
    {
        private MusicalEventsService Service;
        public MusicalEventsController(MusicalEventsService service)
        {
            Service = service;
        }


        // GET: MusicalEvents
        public ActionResult Index()
        {
            return View(Service.RetrieveMusicalEventListings());
        }
    }
}