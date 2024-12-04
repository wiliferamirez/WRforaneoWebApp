using foraneoApp.DataAccess.Data.Repository.IRepository;
using foraneoApp.Models;

namespace foraneoApp.DataAccess.Data.Repository;

public class SlideryRepository : Repository<Slider>, ISliderRepository
{
    private readonly ApplicationDbContext _db;

    public SlideryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(Slider slider)
    { 
        var objectDB = _db.Slider.FirstOrDefault(s => s.Id == slider.Id);
        objectDB.sliderName = slider.sliderName;
        objectDB.status = slider.status;
        objectDB.urlImage = slider.urlImage;
        
        _db.SaveChanges();
    }
    
}