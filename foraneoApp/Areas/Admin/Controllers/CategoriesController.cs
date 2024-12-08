using foraneoApp.DataAccess.Data.Repository.IRepository;
using foraneoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace foraneoApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IWorkContainer _workContainer;

        public CategoriesController(IWorkContainer workContainer)
        {
            _workContainer = workContainer;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _workContainer.Category.Add(category);
                _workContainer.Save();
                return RedirectToAction("Index");
            }
            return View(category); 
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
             Category category = _workContainer.Category.Get(id);
             if (category == null)
             {
                 return NotFound();
             }
             return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _workContainer.Category.Update(category);
                _workContainer.Save();
                return RedirectToAction("Index");
            }
            return View(category); 
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objfromDB = _workContainer.Category.Get(id);
            if (objfromDB == null)
            {
                return Json(new { success = false, message = "Category not found" });
            }
            _workContainer.Category.Remove(objfromDB);
            _workContainer.Save();
            return Json(new { success = true, message = "Category deleted successfully" });
        }
        #region APICalls

        [HttpGet]
        public ActionResult GetAllCategories()
        {
            var categories = _workContainer.Category.GetAll(); 

            var categoryList = categories.Select(c => new {
                categoryId = c.categoryId,    
                categoryName = c.categoryName, 
                order = c.Order  
            }).ToList();

            return Json(new { data = categoryList });
        }
        
        #endregion

    }
}



