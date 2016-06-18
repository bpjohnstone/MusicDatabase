using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicDatabase.EntityFramework;
using MusicDatabase.Model;
using MusicDatabase.Services.Interfaces;

namespace MusicDatabase.Services.Repositories
{
    public class EntityRepository : IRepository
    {
        public TEntity Get<TEntity>(MusicDbContext context, Guid ID, bool returnIfInactive = false) where TEntity : Entity
        {
            TEntity result = context.Set<TEntity>().Find(ID);
            if(result != null)
            {
                // If the entity is inactive, and returnIfInactive = false, return nothing
                if ((!result.IsActive) && (!returnIfInactive))
                    result = null;
            }

            return result;
        }

        public IQueryable<TEntity> Query<TEntity>(MusicDbContext context, EntityState state) where TEntity : Entity
        {
            var results = context.Set<TEntity>().AsQueryable();

            switch (state)
            {
                case EntityState.All:
                    // Do nothing, return all results
                    break;
                case EntityState.Inactive:
                    // Return only inactive (deleted) entities
                    results = results.Where(e => !e.IsActive);
                    break;
                case EntityState.Active:
                default:
                    // Return only active entities
                    results = results.Where(e => e.IsActive);
                    break;
            }

            return results;
        }
    }
}
