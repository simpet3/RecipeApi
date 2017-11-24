using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Shared.Models;

namespace RecipeApi.Entities
{
    public class Account : EntityBase
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

    }
}
