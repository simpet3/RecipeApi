using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Shared.Models;

namespace RecipeApi.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity entity);
        TEntity Edit(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
        DbContext getDbContext();

    }
}
