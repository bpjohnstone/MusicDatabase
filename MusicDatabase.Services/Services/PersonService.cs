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
    public class PersonService : BaseService
    {
        public PersonService(IRepository repository, IMapper mapper)
            :base(repository, mapper) { }

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
