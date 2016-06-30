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
    public class PeopleService
    {
        private EntityRepository Repositiory;
        public PeopleService(EntityRepository repository)
        {
            Repositiory = repository;
        }

        public IEnumerable<PersonListing> RetrievePersonListings()
        {
            using (var context = new MusicDbContext())
            {
                var people = Repositiory.Query<Person>(context, EntityState.Active).ToList();
                var result = new List<PersonListing>();

                foreach(var person in people)
                {
                    var details = new PersonListing();
                    details.ID = person.ID;
                    details.Name = person.Name;
                    details.Psuedonym = person.Psuedonym;
                    details.EventsAttended = person.EventsAttended.Count(e => e is SingleDayEvent) + person.EventsAttended.OfType<MultiDayFestival>().Select(e => e.FestivalGroup).Distinct().Count();
                    details.GiftsGiven = person.GiftsGiven.Count;
                    result.Add(details);
                }

                return result;
            }
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
                }
            }

            return result;
        }
    }
}
