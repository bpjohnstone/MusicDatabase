using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicDatabase.Services.Interfaces;
using MusicDatabase.Services.Repositories;

namespace MusicDatabase.Services
{
    public abstract class BaseService
    {
        protected IRepository Repositiory;
        protected IMapper Mapper;

        public BaseService(IRepository repository, IMapper mapper)
        {
            Repositiory = repository;
            Mapper = mapper;
        }
    }
}
