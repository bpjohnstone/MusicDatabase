using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Services.Queries.People
{
    public class RetrievePersonDetails : BaseQuery
    {
        public RetrievePersonDetails(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        public Guid ID { get; set; }
        public bool ReturnIfInactive { get; set; }

        public PersonDetails Execute()
        {
            PersonDetails result = null;
            var query = Context.Set<Person>().AsQueryable();

            if (ID != Guid.Empty)
            {
                var person = Context.Set<Person>()
                                .Include(p => p.EventsAttended.Select(e => e.Lineup.Select(l => l.Performers.Select(pe => pe.MusicalEntity))))
                                .Single(p => p.ID == ID);

                // If the entity is inactive, and returnIfInactive = false, return nothing
                if ((!person.IsActive) && (!ReturnIfInactive))
                    person = null;

                if (person != null)
                    result = Mapper.Map<PersonDetails>(person);
            }

            return result;
        }

    }
}
