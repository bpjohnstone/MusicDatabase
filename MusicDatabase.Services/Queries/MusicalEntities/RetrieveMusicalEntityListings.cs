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
    public class RetrieveMusicalEntityListings : BaseQuery
    {
        public RetrieveMusicalEntityListings(MusicDbContext context, IMapper mapper)
            : base(context, mapper) { }

        private EntityState entityState = EntityState.Active;
        public EntityState EntityState
        {
            get { return entityState; }
            set { entityState = value; }
        }

        public IEnumerable<MusicalEntityListing> Execute()
        {
            var result = new List<MusicalEntityListing>();
            var query = Context.Set<MusicalEntity>().AsQueryable();

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

            foreach (var musicalEntity in query.ToList())
            {
                var listing = Mapper.Map<MusicalEntityListing>(musicalEntity);

                var musicalEvents = Context.Entry(musicalEntity).Collection(l => l.Performances).Query().Select(p => p.Event).Where(e => e.EventDate < DateTime.Now);
                listing.Performances = musicalEvents.Count(e => e is SingleDayEvent) + musicalEvents.OfType<MultiDayFestival>().Select(e => e.FestivalGroup).Distinct().Count();
                listing.Releases = Context.Entry(musicalEntity).Collection(l => l.Discography).Query().Count();

                result.Add(listing);
            }

            return result;
        }

    }
}
