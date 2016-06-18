using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicDatabase.Services;

namespace MusicDatabase.Web.Controllers
{
    public class ReleasesController : Controller
    {
        public ReleasesService Service;
        public ReleasesController(ReleasesService service)
        {
            Service = service;
        }

        // GET: Releases
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("Year")]
        public ActionResult ListByYear(int? ID)
        {
            int year = DateTime.Now.Year;

            if (ID.HasValue)
                year = ID.Value;

            return View("ByYearListing", Service.RetrieveReleasesByYear(year));
        }

        [ActionName("Format")]
        public ActionResult ListByFormat(Guid? ID)
        {
            ActionResult result = View();


            return result;
        }
    }
}