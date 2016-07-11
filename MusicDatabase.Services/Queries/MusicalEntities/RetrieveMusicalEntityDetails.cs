using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Services.Queries.MusicalEntities
{
    public class RetrieveMusicalEntityDetails : BaseQuery
    {
        public RetrieveMusicalEntityDetails(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        public Guid ID { get; set; }
        public bool ReturnIfInactive { get; set; }

        public MusicalEntityDetails Execute()
        {
            MusicalEntityDetails result = null;

            if (ID != Guid.Empty)
            {
                var musicalEntity = Context.Set<MusicalEntity>().Find(ID);

                // If the entity is inactive, and returnIfInactive = false, return nothing
                if ((!musicalEntity.IsActive) && (!ReturnIfInactive))
                    musicalEntity = null;

                if (musicalEntity != null)
                    result = Mapper.Map<MusicalEntityDetails>(musicalEntity);
            }

            return result;
        }
    }
}
