using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.Services.Interfaces;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Services
{
    public class MusicalEventsService : BaseService
    {
        public MusicalEventsService(IRepository repository, IMapper mapper)
            :base(repository, mapper) { }

        public IEnumerable<MusicalEventListing> RetrieveMusicalEventListings()
        {
            var result = new List<MusicalEventListing>();

            using (var context = new MusicDbContext())
            {
                var musicalEvents = Repositiory.Query<MusicalEvent>(context, EntityState.Active).ToList();
                musicalEvents.ForEach(e => result.Add(Mapper.Map<MusicalEventListing>(e)));
            }

            return result;
        }
    }
}
