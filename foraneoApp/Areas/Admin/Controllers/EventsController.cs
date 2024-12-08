using foraneoApp.DataAccess.Data.Repository.IRepository;
using foraneoApp.Models;
using foraneoApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace foraneoApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventsController : Controller
    {
        private readonly IWorkContainer _workContainer;
        
        public EventsController(IWorkContainer workContainer)
        {
            _workContainer = workContainer;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            EventVM eventVM = new EventVM()
            {
                Event = new foraneoApp.Models.Event(),
                CategoryList = _workContainer.Category.GetCategoriesList()
            };
            return View(eventVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventVM model)
        {
            if (ModelState.IsValid)
            {
                _workContainer.Event.Add(model.Event); 
                _workContainer.Save();
            }
            return RedirectToAction("Index");  
        }
        
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            EventVM eventVm = new EventVM()
            {
                Event = new foraneoApp.Models.Event(),
                CategoryList = _workContainer.Category.GetCategoriesList() 
            };
            if(id != null)
            {
                eventVm.Event = _workContainer.Event.Get(id.Value);
            }
            return View(eventVm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EventVM model)
        {
            if (ModelState.IsValid)
            {
                _workContainer.Event.Update(model.Event); 
                _workContainer.Save();
            }
            return RedirectToAction("Index");  
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objfromDB = _workContainer.Event.Get(id);
            if (objfromDB == null)
            {
                return Json(new { success = false, message = "Event not found" });
            }
            _workContainer.Event.Remove(objfromDB);
            _workContainer.Save();
            return Json(new { success = true, message = "Event deleted successfully" });
        }
        
        
        
        #region APICalls

        [HttpGet]
        public ActionResult GetAllEvents()
        {
            var events = _workContainer.Event.GetAll(includeProperties: "category")
                .Select(e => new
                {
                    e.eventId,
                    e.title,
                    e.description,
                    e.location,
                    e.startDate,
                    e.creationDate,
                    categoryName = e.category.categoryName 
                });

            return Json(new { data = events });
        }

        #endregion
    }
}
