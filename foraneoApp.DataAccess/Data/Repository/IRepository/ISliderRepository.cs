using foraneoApp.Models;

namespace foraneoApp.DataAccess.Data.Repository.IRepository;

public interface ISliderRepository : IRepository<Slider>
{
    void Update(Slider slider);
}