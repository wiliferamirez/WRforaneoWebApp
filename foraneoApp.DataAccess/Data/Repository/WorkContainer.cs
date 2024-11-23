using foraneoApp.DataAccess.Data.Repository.IRepository;

namespace foraneoApp.DataAccess.Data.Repository;

public class WorkContainer : IWorkContainer
{
    private readonly ApplicationDbContext _db;

    public WorkContainer(ApplicationDbContext db)
    {
        _db = db;
        Category = new CategoryRepository(_db);
        
    }

    public ICategoryRepository Category { get; private set; }

    public void Save()
    {
        _db.SaveChanges();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
    
}