using System;
using System.Web.Mvc;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Services.Queries.MusicalEntities;

namespace MusicDatabase.Web.Controllers
{
    public class MusicalEntitiesController : DataController
    {
        public MusicalEntitiesController(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        // GET: MusicalEntities
        public ActionResult Index()
        {
            var query = new RetrieveMusicalEntityListings(Context, Mapper);
            return View(query.Execute());
        }

        // GET: MusicalEntities/Details/e0424a11-fc69-4047-b543-e9967b044fad
        public ActionResult Details(Guid? ID)
        {
            ActionResult result = null;

            if (ID.HasValue)
            {
                var query = new RetrieveMusicalEntityDetails(Context, Mapper);
                query.ID = ID.Value;

                var musicalEntity = query.Execute();
                if (musicalEntity != null)
                    result = View(musicalEntity);
            }

            if (result == null)
                result = RedirectToAction("Index");

            return result;
        }

        //// GET: MusicalEntities/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: MusicalEntities/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Name,SortName,DateCreated,LastUpdated,IsActive")] MusicalEntity musicalEntity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        musicalEntity.ID = Guid.NewGuid();
        //        db.Set<MusicalEntity>().Add(musicalEntity);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(musicalEntity);
        //}

        //// GET: MusicalEntities/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MusicalEntity musicalEntity = db.Set<MusicalEntity>().Find(id);
        //    if (musicalEntity == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(musicalEntity);
        //}

        //// POST: MusicalEntities/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Name,SortName,DateCreated,LastUpdated,IsActive")] MusicalEntity musicalEntity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(musicalEntity).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(musicalEntity);
        //}

        //// GET: MusicalEntities/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MusicalEntity musicalEntity = db.Set<MusicalEntity>().Find(id);
        //    if (musicalEntity == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(musicalEntity);
        //}

        //// POST: MusicalEntities/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    MusicalEntity musicalEntity = db.Set<MusicalEntity>().Find(id);
        //    db.Set<MusicalEntity>().Remove(musicalEntity);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
