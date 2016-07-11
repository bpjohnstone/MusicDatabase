using System;
using System.Web.Mvc;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Services.Queries.People;

namespace MusicDatabase.Web.Controllers
{
    public class PeopleController : DataController
    {
        public PeopleController(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        // GET: People
        public ActionResult Index()
        {
            var query = new RetrievePersonListings(Context, Mapper);
            return View(query.Execute());
        }

        // GET: Details
        public ActionResult Details(Guid? ID)
        {
            ActionResult result = null;

            if (ID.HasValue)
            {
                var query = new RetrievePersonDetails(Context, Mapper);
                query.ID = ID.Value;

                var person = query.Execute();
                if (person != null)
                    result = View(person);
            }

            if (result == null)
                result = RedirectToAction("Index");

            return result;
        }
    }
}