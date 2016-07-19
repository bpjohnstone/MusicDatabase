using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Services.Queries.Locations
{
    public class RetrieveLocationGroupDetails : BaseQuery
    {
        public RetrieveLocationGroupDetails(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        public Guid ID { get; set; }
        public bool ReturnIfInactive { get; set; }

        public LocationGroupDetails Execute()
        {
            LocationGroupDetails result = null;

            if (ID != Guid.Empty)
            {
                var locationGroup = Context.Set<LocationGroup>()
                                        .Include("Locations")
                                        .Single(g => g.ID == ID);

                // If the entity is inactive, and returnIfInactive = false, return nothing
                if ((!locationGroup.IsActive) && (!ReturnIfInactive))
                    locationGroup = null;

                if (locationGroup != null)
                    result = Mapper.Map<LocationGroupDetails>(locationGroup);
            }

            return result;
        }
    }
}
