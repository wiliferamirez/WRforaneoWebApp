namespace foraneoApp.DataAccess.Data.Repository.IRepository;

public interface IWorkContainer : IDisposable
{
    ICategoryRepository Category { get; }
    ISliderRepository Slider { get; }
    void Save();
    
}