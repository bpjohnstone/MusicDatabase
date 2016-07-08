using AutoMapper;
using MusicDatabase.Services.Interfaces;

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
