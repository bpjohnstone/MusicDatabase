using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicDatabase.Services.Services;

namespace MusicDatabase.Web.Controllers
{
    public class LocationsController : Controller
    {
        private LocationsService Service;
        public LocationsController(LocationsService service)
        {
            Service = service;
        }

        // GET: Locations
        public ActionResult Index()
        {
            return View(Service.RetrieveLocationListings());
        }

        // GET: Locations/Details/16210421-de01-46a9-9aa6-fa10fba28bc9
        public ActionResult Details(Guid? ID)
        {
            ActionResult result = null;

            if (ID.HasValue)
            {
                var person = Service.RetrieveLocationDetails(ID.Value);
                if (person != null)
                    result = View(person);
            }

            if (result == null)
                result = RedirectToAction("Index");

            return result;
        }
    }
}