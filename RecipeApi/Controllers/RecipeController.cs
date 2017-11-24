using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Entities;
using RecipeApi.Services.Interfaces;
using RecipeApi.ControllerBase;

namespace RecipeApi.Controllers
{
    [Produces("application/json")]
    [Route("api/category/{categoryId}/recipes/Recipe")]
    public class RecipeController : ControllerBase<Recipe>
    {
        public RecipeController(IBaseService<Recipe> baseService):base(baseService)
        {            
        }
    }
}
