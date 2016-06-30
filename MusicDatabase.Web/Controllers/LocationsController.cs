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
            return View(Service.RetrievePeopleListingDetails());
        }
    }
}