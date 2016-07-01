using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.Services.Repositories;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Services.Services
{
    public class PeopleService
    {
        private EntityRepository Repositiory;
        private IMapper Mapper;

        public PeopleService(EntityRepository repository, IMapper mapper)
        {
            Repositiory = repository;
            Mapper = mapper;
        }

        public IEnumerable<PersonListing> RetrievePersonListings()
        {
            var result = new List<PersonListing>();

            using (var context = new MusicDbContext())
            {
                var people = Repositiory.Query<Person>(context, EntityState.Active).ToList();
                people.ForEach(p => result.Add(Mapper.Map<PersonListing>(p)));
            }

            return result;
        }

        public PersonDetails RetrievePersonDetails(Guid ID)
        {
            PersonDetails result = null;

            using (var context = new MusicDbContext())
            {
                var person = Repositiory.Get<Person>(context, ID);
                if(person != null)
                {
                    result = new PersonDetails();
                    result.ID = ID;
                    result.Name = person.Name;
                    result.Psuedonym = person.Psuedonym;

                    foreach (var musicalEvent in person.EventsAttended)
                    {
                        var eventListing = new MusicalEventListing();
                        eventListing.EventDate = musicalEvent.EventDate.Value;

                        // Event Group
                        if (musicalEvent.EventGroup != null)
                        {
                            eventListing.EventGroup = musicalEvent.EventGroup.Name;
                            eventListing.EventGroupID = musicalEvent.EventGroup.ID;
                        }

                        eventListing.EventName = musicalEvent.EventName;

                        //Location
                        if (musicalEvent.Venue != null)
                        {
                            eventListing.VenueID = musicalEvent.Venue.ID;

                            if (!string.IsNullOrWhiteSpace(musicalEvent.AlternateVenueName))
                            { 
                                eventListing.VenueName = musicalEvent.AlternateVenueName;
                            }
                            else if(musicalEvent.Venue.LocationGroup != null)
                            {
                                eventListing.VenueName = string.Format("{0} - {1}", musicalEvent.Venue.LocationGroup.Name, musicalEvent.Venue.Name);
                            }
                            else
                            {
                                eventListing.VenueName = musicalEvent.Venue.Name;
                            }
                        }

                        // Headliners...
                        foreach (var headliner in musicalEvent.Lineup.OfType<Headliner>().OrderBy(h => h.Position))
                        {
                            var headlinerDetails = new PerformanceListing();
                            headlinerDetails.Position = headliner.Position.Value;
                            headlinerDetails.Attended = headliner.Attended;

                            // Performers...
                            foreach (var performer in headliner.Performers)
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

                        result.EventsAttended.Add(eventListing);
                    }
                }
            }

            return result;
        }
    }
}
