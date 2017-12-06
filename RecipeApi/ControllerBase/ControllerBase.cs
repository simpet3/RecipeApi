using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Entities;
using RecipeApi.Services.Interfaces;
using RecipeApi.Shared.Models;

namespace RecipeApi.ControllerBase
{
    public class ControllerBase<TEntity> : Controller where TEntity : EntityBase
    {
              private readonly IBaseService<TEntity> _baseService;

        public ControllerBase(IBaseService<TEntity> baseService)
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
        public IEnumerable<TEntity> GetAll()
        {
            return _baseService.GetAll();
        }

        [HttpGet("{id}", Name = "GetRecipe")]
        public IActionResult GetById(long id)
        {
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
        public IActionResult Create([FromBody]TEntity entity, [FromRoute] long categoryId)
        {
            Console.WriteLine("route turinys" + categoryId);
            var _entity = _baseService.Add(entity);
            if (_entity == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetRecipe", new { id = _entity.Id }, entity);
        }

        // PUT: api/Recipe/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TEntity entity, [FromRoute] long categoryId)
        {

            var _entity = _baseService.Update(id, entity);
            if (_entity == null)
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
