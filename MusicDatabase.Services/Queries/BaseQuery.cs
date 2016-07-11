using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicDatabase.EntityFramework;

namespace MusicDatabase.Services.Queries
{
    public class BaseQuery
    {
        protected MusicDbContext Context;
        protected IMapper Mapper;

        public BaseQuery(MusicDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
    }
}
