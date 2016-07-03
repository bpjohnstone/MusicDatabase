using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;

namespace MusicDatabase.Services.Interfaces
{
    public interface IRepository
    {
        IQueryable<TEntity> Query<TEntity>(MusicDbContext context, EntityState state) where TEntity : Entity;
        TEntity Get<TEntity>(MusicDbContext context, Guid ID, bool returnIfInactive = false) where TEntity : Entity;
    }
}
