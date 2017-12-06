using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using RecipeApi.Shared.Models;

namespace RecipeApi.Entities
{
    public class Recipe : EntityBase
    {
        public long Likes { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string shortDescription { get; set; }
        // [Required]
        //public Account Author { get; set; }
        [Required]
        public Category Type { get; set; }
        public string Components { get; set; }
       // public IList<Component> Components { get; set; } = new List<Component>();


    }
}
