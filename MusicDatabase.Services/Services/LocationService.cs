using System;
using System.Linq;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.Services.Interfaces;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Services
{
    public class LocationService : BaseService
    {
        public LocationService(IRepository repository, IMapper mapper)
            :base(repository, mapper) { }

        public LocationListingCollection RetrieveLocationListings()
        {
            var result = new LocationListingCollection();

            using (var context = new MusicDbContext())
            {
                var locations = Repositiory.Query<Location>(context, EntityState.Active).ToList();
                locations.ForEach(l => result.Locations.Add(Mapper.Map<LocationListing>(l)));
            }

            return result;
        }

        public LocationDetails RetrieveLocationDetails(Guid ID)
        {
            LocationDetails result = null;

            using (var context = new MusicDbContext())
            {
                var location = Repositiory.Get<Location>(context, ID);
                if(location != null)
                    result = Mapper.Map<LocationDetails>(location);
            }

            return result;
        }

        public LocationGroupDetails RetrieveLocationGroupDetails(Guid ID)
        {
            LocationGroupDetails result = null;

            using (var context = new MusicDbContext())
            {
                var locationGroup = Repositiory.Get<LocationGroup>(context, ID);
                if (locationGroup != null)
                    result = Mapper.Map<LocationGroupDetails>(locationGroup);
            }

            return result;
        }

        public FilteredLocationListingCollection RetrieveLocationListingsByCity(string city)
        {
            return FilterLocationListings(FilterLocationBy.City, city);
        }

        public FilteredLocationListingCollection RetrieveLocationListingsByState(string state)
        {
            return FilterLocationListings(FilterLocationBy.State, state);
        }

        public FilteredLocationListingCollection RetrieveLocationListingsByCountry(string country)
        {
            return FilterLocationListings(FilterLocationBy.Country, country);
        }

        private FilteredLocationListingCollection FilterLocationListings(FilterLocationBy filterType, string filter)
        {
            var result = new FilteredLocationListingCollection();
            result.Filter = filter;
            result.FilterType = filterType;

            filter = filter.ToLower();

            using (var context = new MusicDbContext())
            {
                var locations = Repositiory.Query<Location>(context, EntityState.Active);

                switch (filterType)
                {
                    case FilterLocationBy.City:
                        locations = locations.Where(l => l.City.ToLower() == filter);
                        break;
                    case FilterLocationBy.State:
                        locations = locations.Where(l => l.State.ToLower() == filter);
                        break;
                    case FilterLocationBy.Country:
                        locations = locations.Where(l => l.Country.ToLower() == filter);
                        break;
                }

                locations.ToList().ForEach(l => result.Locations.Add(Mapper.Map<LocationListing>(l)));
            }

            return result;
        }
    }
}
