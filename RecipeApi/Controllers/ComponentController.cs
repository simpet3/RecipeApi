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
    [Route("api/Component")]
    public class ComponentController : ControllerBase<Component>
    {
        public ComponentController(IBaseService<Component> baseService) : base(baseService)
        {
            
        }
    }
}
