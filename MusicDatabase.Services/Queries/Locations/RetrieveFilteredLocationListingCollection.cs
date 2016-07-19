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
    public class RetrieveFilteredLocationListingCollection : BaseQuery
    {
        public RetrieveFilteredLocationListingCollection(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        private EntityState entityState = EntityState.Active;
        public EntityState EntityState
        {
            get { return entityState; }
            set { entityState = value; }
        }

        public string Filter { get; set; }

        private FilterLocationBy locationFilter = FilterLocationBy.City;
        public FilterLocationBy LocationFilter
        {
            get { return locationFilter; }
            set { locationFilter = value; }
        }

        public FilteredLocationListingCollection Execute ()
        {
            var result = new FilteredLocationListingCollection();
            result.FilterType = LocationFilter;
            result.Filter = Filter;

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

            switch (LocationFilter)
            {
                case FilterLocationBy.City:
                    query = query.Where(l => l.City.ToLower() == Filter.ToLower());
                    break;
                case FilterLocationBy.State:
                    query = query.Where(l => l.State.ToLower() == Filter.ToLower());
                    break;
                case FilterLocationBy.Country:
                    query = query.Where(l => l.Country.ToLower() == Filter.ToLower());
                    break;
            }

            foreach (var location in query.ToList())
            {
                var listing = Mapper.Map<LocationListing>(location);

                var musicalEvents = Context.Entry(location).Collection(l => l.MusicalEvents).Query();
                listing.MusicalEvents = musicalEvents.Count(e => e is SingleDayEvent) + musicalEvents.OfType<MultiDayFestival>().Select(e => e.FestivalGroup).Distinct().Count();
                listing.Purchases = Context.Entry(location).Collection(l => l.Purchases).Query().Count();

                result.Locations.Add(listing);
            }

            return result;
        }
    }
}
