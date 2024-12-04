using foraneoApp.DataAccess.Data.Repository.IRepository;
using foraneoApp.Models;

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
        objectDB.urlImage = eventToUpdate.urlImage;
        objectDB.categoryId = eventToUpdate.categoryId;
        objectDB.location = eventToUpdate.location;
        objectDB.startDate = eventToUpdate.startDate;
        objectDB.creationDate = eventToUpdate.creationDate;
        
 //       _db.SaveChanges();
    }
    
}