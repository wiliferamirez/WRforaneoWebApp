using foraneoApp.Models;

namespace foraneoApp.DataAccess.Data.Repository.IRepository;

public interface IEventRepository : IRepository<Event>
{
    void Update(Event eventToUpdate);
    
    Event Get(int id, string includeProperties = "");
    IEnumerable<Event> GetAll(string includeProperties = "");
    
}