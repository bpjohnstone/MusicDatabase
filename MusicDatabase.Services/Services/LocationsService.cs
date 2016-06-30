using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.Services.Repositories;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Services.Services
{
    public class LocationsService
    {
        private EntityRepository Repositiory;
        public LocationsService(EntityRepository repository)
        {
            Repositiory = repository;
        }


        public IEnumerable<LocationListing> RetrievePeopleListingDetails()
        {
            using (var context = new MusicDbContext())
            {
                var locations = Repositiory.Query<Location>(context, EntityState.Active).ToList();
                var result = new List<LocationListing>();

                foreach (var location in locations)
                {
                    var details = new LocationListing();
                    details.ID = location.ID;
                    details.Name = location.Name;

                    if (location.LocationGroup != null)
                    {
                        details.LocationGroup = location.LocationGroup.Name;
                        details.LocationGroupID = location.LocationGroup.ID;
                    }

                    details.SortName = location.SearchName;

                    details.City = location.City;
                    details.State = location.State;
                    details.Country = location.Country;

                    details.MusicalEvents = location.MusicalEvents.Count(e => e is SingleDayEvent) + location.MusicalEvents.OfType<MultiDayFestival>().Select(e => e.FestivalGroup).Distinct().Count();
                    details.Purchases = location.Purchases.Count();

                    details.IsClosed = location.IsClosed;

                    result.Add(details);
                }

                return result;
            }
        }

    }
}
