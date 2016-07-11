using System;
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
                var musicalEvent = Context.Set<MusicalEvent>().Find(ID);

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
