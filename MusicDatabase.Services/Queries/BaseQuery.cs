using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;

namespace MusicDatabase.Services.Queries
{
    public abstract class BaseQuery
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
