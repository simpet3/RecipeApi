using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Repositories.Interfaces;
using RecipeApi.Shared.Models;

namespace RecipeApi.Repositories
{
    public class BaseRepository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity> where TEntity : EntityBase
    {
        public BaseRepository(DbContext dbContext) : base(dbContext)
        {
        }


        public void Add(TEntity entity)
        {
            //dbContext.Set<TEntity>().Add(entity);
            var entry = dbContext.Entry(entity);
             dbContext.Set<TEntity>().AddAsync(entity);
            
        }


        public void Delete(TEntity entity)
        {
            var entry = dbContext.Entry(entity);
            entry.State = EntityState.Deleted;

        }


        public TEntity Edit(TEntity entity)
        {
            var entry = dbContext.Entry(entity);
            entry.State = EntityState.Modified;
            return entry.Entity;

        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
