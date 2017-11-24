using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using RecipeApi.Entities;
using RecipeApi.Services;
using RecipeApi.Services.Interfaces;

namespace RecipeApi.DI
{
    public class RecipeModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RecipesService>().As<IBaseService<Recipe>>();
            builder.RegisterType<ComponentsService>().As<IBaseService<Component>>();
        }
    }
}
