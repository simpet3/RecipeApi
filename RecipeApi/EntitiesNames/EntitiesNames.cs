using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.EntitiesNames
{
    public static class EntitiesNames
    {
        public const string Recipe = "Recipe";
        public const string Ingredient = "Ingredient";
        public const string Component = "Component";
        public const string Category = "Category";
        public const string Account = "Account";
        public const string Default = "default";

        public static string[] names = {"Recipe", "Ingredient", "Component", "Category", "Account"};

        public static string getName(Type type)
        {
            if (type.Name.Equals(Recipe))
            {
                return Recipe;
            }
            return "";
        }

    }
}
