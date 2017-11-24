using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Shared.Models;

namespace RecipeApi.Entities
{
    public class Recipe : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Account Author { get; set; }
        public Category Type { get; set; }
        public IList<Component> Components { get; set; } = new List<Component>();


    }
}
