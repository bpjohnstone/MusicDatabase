using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicDatabase.Services.Repositories;

namespace MusicDatabase.Services
{
    public class MusicalEntitiesService
    {
        private EntityRepository Repositiory;
        private IMapper Mapper;

        public MusicalEntitiesService(EntityRepository repository, IMapper mapper)
        {
            Repositiory = repository;
            Mapper = mapper;
        }

    }
}
