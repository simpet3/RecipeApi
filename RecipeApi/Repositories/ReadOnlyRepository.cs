using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Data;
using RecipeApi.Repositories.Interfaces;
using RecipeApi.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace RecipeApi.Repositories
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly DbContext dbContext;
        public ReadOnlyRepository(DbContext  dbContext)
        {
            this.dbContext = dbContext;
        }

        public   IEnumerable<TEntity> GetAll()
        {
            return  dbContext.Set<TEntity>().ToList();
        }

        public  TEntity GetById(long id)
        {
            return  dbContext.Set<TEntity>().FirstOrDefault(e => e.Id == id);
        }
        public virtual IQueryable<TEntity> Query()
        {
            return dbContext.Set<TEntity>();
        }


    }
}
