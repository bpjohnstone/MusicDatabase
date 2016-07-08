using AutoMapper;
using MusicDatabase.Services.Interfaces;

namespace MusicDatabase.Services.Services
{
    public class WebsiteService : BaseService
    {
        public WebsiteService(IRepository repository, IMapper mapper)
            :base(repository, mapper) { }
    }
}
