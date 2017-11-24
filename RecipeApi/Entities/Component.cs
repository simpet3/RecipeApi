using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Shared.Models;

namespace RecipeApi.Entities
{
    public class Component : EntityBase
    {
        public Ingredient ingredient { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }
}
