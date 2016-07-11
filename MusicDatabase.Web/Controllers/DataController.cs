using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MusicDatabase.EntityFramework;

namespace MusicDatabase.Web.Controllers
{
    public class DataController : Controller
    {
        protected MusicDbContext Context;
        protected IMapper Mapper;

        public DataController(MusicDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
    }
}