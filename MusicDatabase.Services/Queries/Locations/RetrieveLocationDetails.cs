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
                var location = Context.Set<Location>().Find(ID);

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
