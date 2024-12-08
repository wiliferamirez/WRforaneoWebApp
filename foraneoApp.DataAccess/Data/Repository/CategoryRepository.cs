using foraneoApp.DataAccess.Data.Repository.IRepository;
using foraneoApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace foraneoApp.DataAccess.Data.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(Category category)
    { 
        var objectDB = _db.Categories.FirstOrDefault(s => s.categoryId == category.categoryId);
        objectDB.categoryName = category.categoryName;
        objectDB.Order = category.Order;
        
        _db.SaveChanges();
    }

    public IEnumerable<SelectListItem> GetCategoriesList()
    {
        throw new NotImplementedException();
    }
}