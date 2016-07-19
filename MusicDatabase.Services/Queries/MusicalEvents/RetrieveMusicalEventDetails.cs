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

namespace MusicDatabase.Services.Queries.MusicalEvents
{
    public class RetrieveMusicalEventDetails : BaseQuery
    {
        public RetrieveMusicalEventDetails(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        public Guid ID { get; set; }
        public bool ReturnIfInactive { get; set; }

        public MusicalEventDetails Execute()
        {
            MusicalEventDetails result = null;

            if (ID != Guid.Empty)
            {
                var musicalEvent = Context.Set<MusicalEvent>()
                                        .Include(e => e.Lineup.Select(l => l.Performers.Select(p => p.MusicalEntity)))
                                        .Include(e => e.OtherAttendees)
                                        .Single(e => e.ID == ID);

                // If the entity is inactive, and returnIfInactive = false, return nothing
                if ((!musicalEvent.IsActive) && (!ReturnIfInactive))
                    musicalEvent = null;

                if (musicalEvent != null)
                    result = Mapper.Map<MusicalEventDetails>(musicalEvent);
            }

            return result;
        }
    }
}
