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

namespace MusicDatabase.Services.Queries.Locations
{
    public class RetrieveLocationDetails : BaseQuery
    {
        public RetrieveLocationDetails(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        public Guid ID { get; set; }
        public bool ReturnIfInactive { get; set; }
        
        public LocationDetails Execute()
        {
            LocationDetails result = null;

            if(ID != Guid.Empty)
            {
                var location = Context.Set<Location>()
                                    .Include(e => e.MusicalEvents.Select(l => l.Lineup.Select(p => p.Performers)))
                                    .Include("Purchases")
                                    .Single(l => l.ID == ID);

                // If the entity is inactive, and returnIfInactive = false, return nothing
                if ((!location.IsActive) && (!ReturnIfInactive))
                    location = null;

                if (location != null)
                    result = Mapper.Map<LocationDetails>(location);
            }

            return result;
        }
    }
}
