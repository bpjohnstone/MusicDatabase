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
    public class RetrieveMusicalEventListings : BaseQuery
    {
        public RetrieveMusicalEventListings(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        private EntityState entityState = EntityState.Active;
        public EntityState EntityState
        {
            get { return entityState; }
            set { entityState = value; }
        }

        public IEnumerable<MusicalEventListing> Execute()
        {
            var result = new List<MusicalEventListing>();
            var query = Context.Set<MusicalEvent>().AsQueryable();

            switch (EntityState)
            {
                case EntityState.All:
                    // Do nothing, return all results
                    break;
                case EntityState.Inactive:
                    // Return only inactive (deleted) entities
                    query = query.Where(e => !e.IsActive);
                    break;
                case EntityState.Active:
                default:
                    // Return only active entities
                    query = query.Where(e => e.IsActive);
                    break;
            }

            query.ToList().ForEach(e => result.Add(Mapper.Map<MusicalEventListing>(e)));

            return result;
        }
    }
}
