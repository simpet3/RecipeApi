using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using RecipeApi.Repositories;
using RecipeApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using Autofac;

namespace RecipeApi.DI
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(ReadOnlyRepository<>))
                .As(typeof(IReadOnlyRepository<>));

            builder
                .RegisterGeneric(typeof(BaseRepository<>))
                .As(typeof(IRepository<>));

            builder
                .RegisterType(typeof(RecipesDbContext))
                .As(typeof(DbContext));
        }
    }
}
