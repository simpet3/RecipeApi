using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Entities;
using RecipeApi.Repositories.Interfaces;
using RecipeApi.Services.Interfaces;

namespace RecipeApi.Services
{
    public class CategoryService : IBaseService<Category>
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Boolean Detele(long id)
        {
            var recipe = categoryRepository.GetById(id);
            if (recipe != null)
            {
                categoryRepository.Delete(recipe);
                categoryRepository.SaveChanges();
                return true;
            }
            return false;
        }


        public Category GetById(long id)
        {
            categoryRepository.SaveChanges();
            return categoryRepository.GetById(id);

        }

        public IEnumerable<Category> GetAll()
        {
            // recipesRepository.SaveChanges();
            return categoryRepository.Query().ToList();
            //return recipesRepository.GetAll();
        }

        public Category Update(long id, Category category)
        {
            var categoryFromDb = GetById(id);

            if (categoryFromDb != null && category != null)
            {
                categoryFromDb.typeName = category.typeName;
                categoryRepository.SaveChanges();
                return categoryFromDb;
            }
            return null;

        }

        public Category Add(Category category)
        {
            if (category != null && !categoryExists(category))
            {
                if (false)
                {
                  //  atachRecipeDb(recipe);
                }
                else
                {

                    categoryRepository.Add(category);
                }


                categoryRepository.SaveChanges();
                return categoryRepository.GetAll().Last();

            }
            return null;
        }

        private Boolean categoryExists(Category category)
        {
            return categoryRepository.getDbContext().Set<Category>().FirstOrDefault(x => x.Id == category.Id) != null;
        }
    }
}
