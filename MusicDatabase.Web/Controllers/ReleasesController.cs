using System;
using System.Web.Mvc;
using MusicDatabase.Services;

namespace MusicDatabase.Web.Controllers
{
    public class ReleasesController : Controller
    {
        public ReleaseService Service;
        public ReleasesController(ReleaseService service)
        {
            Service = service;
        }

        // GET: Releases
        public ActionResult Index()
        {
            return View("ByYearListing", Service.RetrieveReleasesByYear(DateTime.Now.Year));
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