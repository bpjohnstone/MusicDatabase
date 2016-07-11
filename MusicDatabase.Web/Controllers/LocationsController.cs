using System;
using System.Web.Mvc;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Services.Queries.Locations;

namespace MusicDatabase.Web.Controllers
{
    public class LocationsController : DataController
    {
        public LocationsController(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        // GET: Locations
        public ActionResult Index()
        {
            var query = new RetrieveLocationListingCollection(Context, Mapper);
            return View(query.Execute());
        }

        // GET: Locations/Details/16210421-de01-46a9-9aa6-fa10fba28bc9
        public ActionResult Details(Guid? ID)
        {
            ActionResult result = null;

            if (ID.HasValue)
            {
                var query = new RetrieveLocationDetails(Context, Mapper);
                query.ID = ID.Value;

                var location = query.Execute();
                if (location != null)
                    result = View(location);
            }

            if (result == null)
                result = RedirectToAction("Index");

            return result;
        }

        // GET: Locations/Group/17a7c07e-dbeb-4235-9158-469e2ec32225
        public ActionResult Group(Guid? ID)
        {
            ActionResult result = null;

            if (ID.HasValue)
            {
                var query = new RetrieveLocationGroupDetails(Context, Mapper);
                query.ID = ID.Value;

                var locationGroup = query.Execute();
                if(locationGroup != null)
                    result = View(locationGroup);
            }

            if (result == null)
                result = RedirectToAction("Index");

            return result;
        }

        // GET: Locations/City/Geelong
        [ActionName("City")]
        public ActionResult FilterByCity(string ID)
        {
            var query = new RetrieveFilteredLocationListingCollection(Context, Mapper);
            query.LocationFilter = ViewModel.FilterLocationBy.City;
            query.Filter = ID;

            return View("FilteredListing", query.Execute());
        }

        // GET: Locations/State/Victoria
        [ActionName("State")]
        public ActionResult FilterByState(string ID)
        {
            var query = new RetrieveFilteredLocationListingCollection(Context, Mapper);
            query.LocationFilter = ViewModel.FilterLocationBy.State;
            query.Filter = ID;

            return View("FilteredListing", query.Execute());
        }

        // GET: Locations/Country/Australia
        [ActionName("Country")]
        public ActionResult FilterByCountry(string ID)
        {
            var query = new RetrieveFilteredLocationListingCollection(Context, Mapper);
            query.LocationFilter = ViewModel.FilterLocationBy.Country;
            query.Filter = ID;

            return View("FilteredListing", query.Execute());
        }
    }
}