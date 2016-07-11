using System;
using System.Web.Mvc;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Services.Queries.MusicalEvents;

namespace MusicDatabase.Web.Controllers
{
    public class MusicalEventsController : DataController
    {
        public MusicalEventsController(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        // GET: MusicalEvents
        public ActionResult Index()
        {
            var query = new RetrieveMusicalEventListings(Context, Mapper);
            return View(query.Execute());
        }

        // GET: MusicalEvents/Details/e0424a11-fc69-4047-b543-e9967b044fad
        public ActionResult Details(Guid? ID)
        {
            ActionResult result = null;

            if (ID.HasValue)
            {
                var query = new RetrieveMusicalEventDetails(Context, Mapper);
                query.ID = ID.Value;

                var musicalEvent = query.Execute();
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
                var query = new RetrieveEventGroupDetails(Context, Mapper);
                query.ID = ID.Value;

                var eventGroup = query.Execute();
                if (eventGroup != null)
                    result = View(eventGroup);
            }

            if (result == null)
                result = RedirectToAction("Index");

            return result;
        }
    }
}