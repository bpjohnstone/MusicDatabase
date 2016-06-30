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

        public IEnumerable<LocationListing> RetrieveLocationListings()
        {
            var result = new List<LocationListing>();

            using (var context = new MusicDbContext())
            {
                var locations = Repositiory.Query<Location>(context, EntityState.Active).ToList();                

                foreach (var location in locations)
                {
                    var details = new LocationListing();
                    PopulateLocationBase(location, details);
                    details.MusicalEvents = location.MusicalEvents.Count(e => e is SingleDayEvent) + location.MusicalEvents.OfType<MultiDayFestival>().Select(e => e.FestivalGroup).Distinct().Count();
                    details.Purchases = location.Purchases.Count();

                    result.Add(details);
                }
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
                {
                    result = new LocationDetails();
                    PopulateLocationBase(location, result);

                    result.Address = location.Address;
                    result.Suburb = location.Suburb;
                    result.Postcode = location.Postcode;

                    result.Notes = location.Notes;

                    foreach (var otherName in location.OtherNames.OrderBy(n => n.Position))
                        result.OtherNames.Add(otherName.Position, otherName.Name);


                    foreach (var musicalEvent in location.MusicalEvents)
                    {
                        var eventListing = new MusicalEventListing();
                        eventListing.EventDate = musicalEvent.EventDate.Value;

                        if(musicalEvent.EventGroup != null)
                        {
                            eventListing.EventGroup = musicalEvent.EventGroup.Name;
                            eventListing.EventGroupID = musicalEvent.EventGroup.ID;
                        }

                        eventListing.EventName = musicalEvent.EventName;

                        // Headliners...
                        foreach(var headliner in musicalEvent.Lineup.OfType<Headliner>().OrderBy(h => h.Position))
                        {
                            var headlinerDetails = new PerformanceListing();
                            headlinerDetails.Position = headliner.Position.Value;

                            // Performers...
                            foreach(var performer in headliner.Performers)
                            {
                                var performerDetails = new PerformerDetails();
                                performerDetails.Position = performer.Position;
                                performerDetails.MusicalEntity = performer.MusicalEntity.Name;
                                performerDetails.MusicalEntityID = performer.MusicalEntity.ID;
                                headlinerDetails.Performers.Add(performerDetails);
                            }

                            headlinerDetails.PerformingAs = headliner.PerformingAs;

                            eventListing.Headliners.Add(headlinerDetails);
                        }

                        result.MusicalEvents.Add(eventListing);
                    }

                }
            }

            return result;
        }

        private void PopulateLocationBase(Location location, LocationBase locationBase)
        {
            if(locationBase != null)
            {
                locationBase.ID = location.ID;
                locationBase.Name = location.Name;

                if (location.LocationGroup != null)
                {
                    locationBase.LocationGroup = location.LocationGroup.Name;
                    locationBase.LocationGroupID = location.LocationGroup.ID;
                }

                locationBase.SortName = location.SearchName;

                locationBase.City = location.City;
                locationBase.State = location.State;
                locationBase.Country = location.Country;

                locationBase.IsClosed = location.IsClosed;
            }
        }
    }
}
