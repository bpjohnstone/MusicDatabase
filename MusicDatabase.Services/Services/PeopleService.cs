using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.Services.Repositories;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Services
{
    public class PeopleService
    {
        private EntityRepository Repositiory;
        private IMapper Mapper;

        public PeopleService(EntityRepository repository, IMapper mapper)
        {
            Repositiory = repository;
            Mapper = mapper;
        }

        public IEnumerable<PersonListing> RetrievePersonListings()
        {
            var result = new List<PersonListing>();

            using (var context = new MusicDbContext())
            {
                var people = Repositiory.Query<Person>(context, EntityState.Active).ToList();
                people.ForEach(p => result.Add(Mapper.Map<PersonListing>(p)));
            }

            return result;
        }

        public PersonDetails RetrievePersonDetails(Guid ID)
        {
            PersonDetails result = null;

            using (var context = new MusicDbContext())
            {
                var person = Repositiory.Get<Person>(context, ID);
                if(person != null)
                    result = Mapper.Map<PersonDetails>(person);                                      
            }

            return result;
        }
    }
}
