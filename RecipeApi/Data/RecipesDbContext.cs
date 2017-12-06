using RecipeApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecipeApi.Data
{

    public class RecipesDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
       // public DbSet<Component> Components { get; set; }
        public DbSet<Category> RecipeTypes { get; set; }
       // public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public RecipesDbContext(DbContextOptions<RecipesDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Recipe>().HasOne(recipe => recipe.Author);
            modelBuilder.Entity<Recipe>().HasOne(recipe => recipe.Type);

            
        }
    }
}
