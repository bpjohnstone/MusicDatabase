using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Services.Queries.Locations
{
    public class RetrieveLocationListingCollection : BaseQuery
    {
        public RetrieveLocationListingCollection(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        private EntityState entityState = EntityState.Active;
        public EntityState EntityState
        {
            get { return entityState; }
            set { entityState = value; }
        }        

        public LocationListingCollection Execute()
        {
            var result = new LocationListingCollection();
            var query = Context.Set<Location>().AsQueryable();

            switch (EntityState)
            {
                case EntityState.All:
                    // Do nothing, return all results
                    break;
                case EntityState.Inactive:
                    // Return only inactive (deleted) entities
                    query = query.Where(e => !e.IsActive);
                    break;
                case EntityState.Active:
                default:
                    // Return only active entities
                    query = query.Where(e => e.IsActive);
                    break;
            }

            foreach(var location in query.ToList())
            {
                var listing = Mapper.Map<LocationListing>(location);

                var musicalEvents = Context.Entry(location).Collection(l => l.MusicalEvents).Query().Where(e => e.EventDate < DateTime.Now);
                listing.MusicalEvents = musicalEvents.Count(e => e is SingleDayEvent) + musicalEvents.OfType<MultiDayFestival>().Select(e => e.FestivalGroup).Distinct().Count();
                listing.Purchases = Context.Entry(location).Collection(l => l.Purchases).Query().Count();

                result.Locations.Add(listing);
            }

            return result;
        }
    }
}
