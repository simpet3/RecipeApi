using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Entities;
using RecipeApi.Shared.Models;

namespace RecipeApi.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity recipe);
        Boolean Detele(long id);
        TEntity GetById(long id);
        TEntity Update(long id, TEntity recipe);
    }
}
