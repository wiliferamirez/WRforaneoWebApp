using foraneoApp.DataAccess.Data.Repository.IRepository;
using foraneoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace foraneoApp.DataAccess.Data.Repository;

public class EventRepository : Repository<Event>, IEventRepository
{
    private readonly ApplicationDbContext _db;

    public EventRepository(ApplicationDbContext db) : base(db)
    
    {
        _db = db;
    }
    public void Update(Event eventToUpdate)
    { 
        var objectDB = _db.Events.FirstOrDefault(s => s.eventId == eventToUpdate.eventId);
        objectDB.title = eventToUpdate.title;
        objectDB.description = eventToUpdate.description;
        objectDB.categoryId = eventToUpdate.categoryId;
        objectDB.location = eventToUpdate.location;
        objectDB.startDate = eventToUpdate.startDate;
        objectDB.creationDate = eventToUpdate.creationDate;
        
 //       _db.SaveChanges();
    }
    
    public Event Get(int id, string includeProperties = "")
    {
        IQueryable<Event> query = _db.Set<Event>();

        // Apply eager loading if there are any navigation properties
        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        return query.FirstOrDefault(e => e.eventId == id);
    }
    public IEnumerable<Event> GetAll(string includeProperties = "")
    {
        IQueryable<Event> query = _db.Set<Event>();

        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        return query.ToList();
    }
}