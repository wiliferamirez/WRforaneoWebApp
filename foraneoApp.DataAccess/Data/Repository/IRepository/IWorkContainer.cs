namespace foraneoApp.DataAccess.Data.Repository.IRepository;

public interface IWorkContainer : IDisposable
{
    ICategoryRepository Category { get; }
    IEventRepository Event { get; }
    ISliderRepository Slider { get; }
    void Save();
    
}