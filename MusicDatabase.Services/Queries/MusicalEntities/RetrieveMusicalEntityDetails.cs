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
                var musicalEntity = Context.Set<MusicalEntity>()
                                        .Include(e => e.Performances.Select(p => p.Event))
                                        .Include(e => e.Performances.Select(p => p.Performers))
                                        .Include(e => e.Discography.Select(d => d.Release.Copies))
                                        .Single(e => e.ID == ID);

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
