using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Shared.Models;

namespace RecipeApi.Repositories.Interfaces
{
    public interface IReadOnlyRepository<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
    }
}
