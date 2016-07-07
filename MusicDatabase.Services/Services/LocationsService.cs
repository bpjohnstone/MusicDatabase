using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.Services.Interfaces;
using MusicDatabase.Services.Repositories;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Services
{
    public class LocationsService : BaseService
    {
        public LocationsService(IRepository repository, IMapper mapper)
            :base(repository, mapper) { }

        public IEnumerable<LocationListing> RetrieveLocationListings()
        {
            var result = new List<LocationListing>();

            using (var context = new MusicDbContext())
            {
                var locations = Repositiory.Query<Location>(context, EntityState.Active).ToList();
                locations.ForEach(l => result.Add(Mapper.Map<LocationListing>(l)));
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

        // The following three functions could probably be compressed down to something nicer
        public FilteredLocationListings RetrieveLocationListingsByCity(string city)
        {
            var result = new FilteredLocationListings();
            result.Filter = city;

            city = city.ToLower();

            using (var context = new MusicDbContext())
            {
                var locations = Repositiory.Query<Location>(context, EntityState.Active)
                    .Where(l => l.City.ToLower() == city)
                    .ToList();

                locations.ForEach(l => result.Locations.Add(Mapper.Map<LocationListing>(l)));
            }

            return result;
        }

        public FilteredLocationListings RetrieveListingsByState(string state)
        {
            var result = new FilteredLocationListings();
            result.Filter = state;

            state = state.ToLower();

            using (var context = new MusicDbContext())
            {
                var locations = Repositiory.Query<Location>(context, EntityState.Active)
                    .Where(l => l.State.ToLower() == state)
                    .ToList();

                locations.ForEach(l => result.Locations.Add(Mapper.Map<LocationListing>(l)));
            }

            return result;
        }

        public FilteredLocationListings RetrieveListingsByCountry(string country)
        {
            var result = new FilteredLocationListings();
            result.Filter = country;

            country = country.ToLower();

            using (var context = new MusicDbContext())
            {
                var locations = Repositiory.Query<Location>(context, EntityState.Active)
                    .Where(l => l.Country.ToLower() == country)
                    .ToList();

                locations.ForEach(l => result.Locations.Add(Mapper.Map<LocationListing>(l)));
            }

            return result;
        }
    }
}
