using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Entities;
using RecipeApi.Services.Interfaces;
using RecipeApi.ControllerBase;

namespace RecipeApi.Controllers
{
    [Produces("application/json")]
    [Route("api/category/{categoryId}/recipes/Recipe")]
    public class RecipeByCategoryController : Controller
    {
        private readonly IBaseService<Recipe> _baseService;

        public RecipeByCategoryController(IBaseService<Recipe> baseService)
        {
            this._baseService = baseService;

            //_baseService.Add(new Recipe
            //{
            //    Title = "betkas",
            //    Type = new RecipeType(),
            //    Author = new Account(),
            //    Description = "aprasymas",
            //    Components = new List<Component>()
            //});
        }

        // GET: api/Recipe
        [HttpGet]
        public IEnumerable<Recipe> GetAll([FromRoute] long categoryId)
        {
            var list = _baseService.GetAll().Where(x => x.Type.Id  == categoryId);
            
            return list;
        }

        [HttpGet("{id}", Name = "GetRecipe")]
        public IActionResult GetById(long id)
        {
            Console.WriteLine(" category of request" );

            var rec = _baseService.GetById(id);
            if (rec == null)
            {
                return NotFound();
            }
            return Ok(rec);
        }

        // GET: api/Recipe/5

        // POST: api/Recipe
        [HttpPost]
        public IActionResult Create([FromBody]Recipe recipe)
        {
            Console.WriteLine("route turinys" );
            var _recipe = _baseService.Add(recipe);
            if (_recipe == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetRecipe", new { id = _recipe.Id }, recipe);
        }

        // PUT: api/Recipe/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Recipe recipe)
        {

            var _recipe = _baseService.Update(id, recipe);
            if (_recipe == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var succeded = _baseService.Detele(id);
            if (succeded)
            {
                return new NoContentResult();
            }
            return NotFound();
        }
    }
}

