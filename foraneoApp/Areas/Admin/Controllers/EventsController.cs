using foraneoApp.DataAccess.Data.Repository.IRepository;
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
            // Log categoryId
            Console.WriteLine($"Submitted categoryId: {model.Event.categoryId}");

            if (!ModelState.IsValid)
            {

                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Error: {error.ErrorMessage}");
                }

                model.CategoryList = _workContainer.Category.GetCategoriesList(); 
                return View(model);  
            }


            _workContainer.Event.Add(model.Event); 
            _workContainer.Save();


            return RedirectToAction("Index");  
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
