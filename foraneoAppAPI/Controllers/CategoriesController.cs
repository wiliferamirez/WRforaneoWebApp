using foraneoApp.DataAccess.Data.Repository.IRepository;
using foraneoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace foraneoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IWorkContainer _workContainer;

        public CategoriesController(IWorkContainer workContainer)
        {
            _workContainer = workContainer;
        }

        // GET: api/categories
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            var categories = _workContainer.Category.GetAll();
            var categoryList = categories.Select(c => new
            {
                categoryId = c.categoryId,
                categoryName = c.categoryName,
                order = c.Order
            }).ToList();

            return Ok(new { data = categoryList });
        }

        // GET: api/categories/{id}
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _workContainer.Category.Get(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/categories
        [HttpPost]
        public ActionResult<Category> CreateCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            _workContainer.Category.Add(category);
            _workContainer.Save();
            return CreatedAtAction(nameof(GetCategory), new { id = category.categoryId }, category);
        }

        // PUT: api/categories/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category category)
        {
            if (id != category.categoryId)
            {
                return BadRequest();
            }

            _workContainer.Category.Update(category);
            _workContainer.Save();
            return NoContent(); // 204 No Content on successful update
        }

        // DELETE: api/categories/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _workContainer.Category.Get(id);
            if (category == null)
            {
                return NotFound();
            }

            _workContainer.Category.Remove(category);
            _workContainer.Save();
            return NoContent(); // 204 No Content on successful deletion
        }
    }
}

