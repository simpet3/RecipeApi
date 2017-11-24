using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Entities;
using RecipeApi.Services.Interfaces;
using RecipeApi.Repositories.Interfaces;

namespace RecipeApi.Services
{
    public class ComponentsService : IBaseService<Component>
    {
        private readonly IRepository<Component> componentsRepository;

        public ComponentsService(IRepository<Component> componentsRepository)
        {
            this.componentsRepository = componentsRepository;
        }

        public Boolean Detele(long id)
        {
            var component = componentsRepository.GetById(id);
            if (component != null)
            {
                componentsRepository.Delete(component);
                componentsRepository.SaveChanges();
                return true;
            }
            return false;
        }


        public Component GetById(long id)
        {
            componentsRepository.SaveChanges();
            return componentsRepository.GetById(id);

        }

        public IEnumerable<Component> GetAll()
        {
            componentsRepository.SaveChanges();

            return componentsRepository.GetAll();
        }

        public Component Update(long id, Component component)
        {
            var componentFromDb = GetById(id);

            if (componentFromDb != null && component != null)
            {
                componentFromDb.ingredient = component.ingredient;
                componentFromDb.quantity = component.quantity;
                componentFromDb.unit = component.unit;

                componentsRepository.SaveChanges();
                return componentFromDb;
            }
            return null;

        }

        public Component Add(Component component)
        {
            if (component != null)
            {
                componentsRepository.Add(component);
                componentsRepository.SaveChanges();
                return componentsRepository.GetAll().Last();

            }
            return null;
        }
    }
}
