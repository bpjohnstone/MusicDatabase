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
    }
}
