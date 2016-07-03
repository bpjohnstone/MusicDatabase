using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicDatabase.Services;

namespace MusicDatabase.Web.Controllers
{
    public class PeopleController : Controller
    {
        private PeopleService Service;
        public PeopleController(PeopleService service)
        {
            Service = service;
        }

        // GET: People
        public ActionResult Index()
        {
            return View(Service.RetrievePersonListings());
        }

        // GET: Details
        public ActionResult Details(Guid? ID)
        {
            ActionResult result = null;

            if (ID.HasValue)
            {
                var person = Service.RetrievePersonDetails(ID.Value);
                if (person != null)
                    result = View(person);
            }

            if (result == null)
                result = RedirectToAction("Index");

            return result;
        }
    }
}