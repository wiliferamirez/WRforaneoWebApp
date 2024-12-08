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
        var categories = _db.Categories.Select(i => new SelectListItem
        {
            Text = i.categoryName,
            Value = i.categoryId.ToString()
        }).ToList();

        Console.WriteLine("Categories for dropdown:");
        foreach (var category in categories)
        {
            Console.WriteLine($"Text: {category.Text}, Value: {category.Value}");
        }

        return categories;
    }
}