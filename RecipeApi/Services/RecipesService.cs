using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Entities;
using RecipeApi.Repositories.Interfaces;
using RecipeApi.Services.Interfaces;

namespace RecipeApi.Services
{
    public class RecipesService : IBaseService<Recipe>
    {
        private readonly IRepository<Recipe> recipesRepository;

        public RecipesService(IRepository<Recipe> recipesRepository)
        {
            this.recipesRepository = recipesRepository;
        }

        public Boolean Detele(long id)
        {
            var recipe = recipesRepository.GetById(id);
            if (recipe != null)
            {
                recipesRepository.Delete(recipe);
                recipesRepository.SaveChanges();
                return true;
            }
            return false;
        }


        public Recipe GetById(long id)
        {
            recipesRepository.SaveChanges();
            return recipesRepository.GetById(id);
  
        }

        public IEnumerable<Recipe> GetAll()
        {
            recipesRepository.SaveChanges();
            
            return recipesRepository.GetAll();
        }

        public Recipe Update(long id, Recipe recipe)
        {
            var recipeFromDb = GetById(id);
            
            if (recipeFromDb != null && recipe != null)
            {
                recipeFromDb.Components = recipe.Components;
                recipeFromDb.Title = recipe.Title;
                recipeFromDb.Author = recipe.Author;
                recipeFromDb.Description = recipe.Description;
                recipeFromDb.Type = recipe.Type;
                recipesRepository.SaveChanges();
                return recipeFromDb;
            }
            return null;

        }

        public Recipe Add(Recipe recipe)
        {
            if (recipe != null)
            {
                 recipesRepository.Add(recipe);
                recipesRepository.SaveChanges();
                return recipesRepository.GetAll().Last();

            }
            return null;
        }
    }
}
