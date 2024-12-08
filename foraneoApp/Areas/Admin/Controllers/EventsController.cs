using foraneoApp.DataAccess.Data.Repository.IRepository;
using foraneoApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        
        
        #region APICalls

        [HttpGet]
        public ActionResult GetAllEvents()
        {
            var events = _workContainer.Event.GetAll(includeProperties:"category"); 

            var eventList = events.Select(c => new {
                eventId = c.eventId,
                title = c.title,
                description = c.description,
                location = c.location,
                startDate = c.startDate,
                creationDate = c.creationDate,
            }).ToList();

            return Json(new { data = eventList });
        }
        
        #endregion
    }
}
