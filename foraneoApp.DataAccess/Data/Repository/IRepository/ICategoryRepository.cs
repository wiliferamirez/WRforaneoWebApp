using Microsoft.AspNetCore.Mvc.Rendering;
using foraneoApp.Models;

namespace foraneoApp.DataAccess.Data.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category category);
    IEnumerable<SelectListItem> GetCategoriesList();
}