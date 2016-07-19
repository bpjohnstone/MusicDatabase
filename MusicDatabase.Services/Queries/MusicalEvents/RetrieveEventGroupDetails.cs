using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Services.Queries.MusicalEvents
{
    public class RetrieveEventGroupDetails : BaseQuery
    {
        public RetrieveEventGroupDetails(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        public Guid ID { get; set; }
        public bool ReturnIfInactive { get; set; }

        public EventGroupDetails Execute()
        {
            EventGroupDetails result = null;

            if (ID != Guid.Empty)
            {
                var eventGroup = Context.Set<EventGroup>()
                                        .Include(g => g.MusicalEvents.Select(e => e.Lineup.Select(l => l.Performers.Select(p => p.MusicalEntity))))
                                        .Single(g => g.ID == ID);

                // If the entity is inactive, and returnIfInactive = false, return nothing
                if ((!eventGroup.IsActive) && (!ReturnIfInactive))
                    eventGroup = null;

                if (eventGroup != null)
                    result = Mapper.Map<EventGroupDetails>(eventGroup);
            }

            return result;
        }
    }
}
