using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Services.Queries.People
{
    public class RetrievePersonListings : BaseQuery
    {
        public RetrievePersonListings(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        private EntityState entityState = EntityState.Active;
        public EntityState EntityState
        {
            get { return entityState; }
            set { entityState = value; }
        }

        public IEnumerable<PersonListing> Execute()
        {
            var result = new List<PersonListing>();
            var query = Context.Set<Person>().AsQueryable();

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

            foreach(var person in query.ToList())
            {
                var listing = Mapper.Map<PersonListing>(person);

                var musicalEvents = Context.Entry(person).Collection(l => l.EventsAttended).Query().Where(e => e.EventDate < DateTime.Now);
                listing.EventsAttended = musicalEvents.Count(e => e is SingleDayEvent) + musicalEvents.OfType<MultiDayFestival>().Select(e => e.FestivalGroup).Distinct().Count();
                listing.GiftsGiven = Context.Entry(person).Collection(l => l.GiftsGiven).Query().Count();

                result.Add(listing);
            }
            
            return result;
        }
    }
}
