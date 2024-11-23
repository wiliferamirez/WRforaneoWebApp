using foraneoApp.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace foraneoApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Categories : Controller
    {
        private readonly IWorkContainer _workContainer;

        public Categories(IWorkContainer workContainer)
        {
            _workContainer = workContainer;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #region APICalls

        [HttpGet]
        public ActionResult GetAllCategories()
        {
            return Json(new {data = _workContainer.Category.GetAll()});
        }
        
        #endregion

    }
}
