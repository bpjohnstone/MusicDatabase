using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicDatabase.Services;

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

        // GET: Locations/Group/17a7c07e-dbeb-4235-9158-469e2ec32225
        public ActionResult Group(Guid? ID)
        {
            ActionResult result = null;

            if (result == null)
                result = RedirectToAction("Index");

            return result;
        }

        // GET: Locations/City/Geelong
        [ActionName("City")]
        public ActionResult FilterByCity(string ID)
        {
            return View("FilteredListing", Service.RetrieveLocationListingsByCity(ID));
        }

        // GET: Locations/State/Victoria
        [ActionName("State")]
        public ActionResult FilterByState(string ID)
        {
            return View("FilteredListing", Service.RetrieveListingsByState(ID));
        }

        // GET: Locations/Country/Australia
        [ActionName("Country")]
        public ActionResult FilterByCountry(string ID)
        {
            return View("FilteredListing", Service.RetrieveListingsByCountry(ID));
        }
    }
}