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

        // GET: MusicalEvents/Details/e0424a11-fc69-4047-b543-e9967b044fad
        public ActionResult Details(Guid? ID)
        {
            ActionResult result = null;

            if (ID.HasValue)
            {
                var musicalEvent = Service.RetrieveMusicalEventDetails(ID.Value);
                if (musicalEvent != null)
                    result = View(musicalEvent);
            }

            if (result == null)
                result = RedirectToAction("Index");

            return result;
        }

        // GET: MusicalEvents/Group/e0424a11-fc69-4047-b543-e9967b044fad
        public ActionResult Group(Guid? ID)
        {
            ActionResult result = null;

            if(ID.HasValue)
            {
                var eventGroup = Service.RetrieveEventGroupDetails(ID.Value);
                if (eventGroup != null)
                    result = View(eventGroup);
            }

            if (result == null)
                result = RedirectToAction("Index");

            return result;
        }
    }
}