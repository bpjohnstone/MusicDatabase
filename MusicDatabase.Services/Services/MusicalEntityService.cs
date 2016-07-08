using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.Services.Interfaces;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Services
{
    public class MusicalEntityService : BaseService
    {
        public MusicalEntityService(IRepository repository, IMapper mapper)
            :base(repository, mapper) { }

        public IEnumerable<MusicalEntityListing> RetrieveMusicalEntityListings()
        {
            var result = new List<MusicalEntityListing>();

            using (var context = new MusicDbContext())
            {
                var musicalEntities = Repositiory.Query<MusicalEntity>(context, EntityState.Active).ToList();
                musicalEntities.ForEach(p => result.Add(Mapper.Map<MusicalEntityListing>(p)));
            }

            return result;
        }

        public MusicalEntityDetails RetrieveMusicalEntityDetails(Guid ID)
        {
            MusicalEntityDetails result = null;

            using (var context = new MusicDbContext())
            {
                var musicalEntity = Repositiory.Get<MusicalEntity>(context, ID);
                if (musicalEntity != null)
                    result = Mapper.Map<MusicalEntityDetails>(musicalEntity);
            }

            return result;
        }
    }
}
