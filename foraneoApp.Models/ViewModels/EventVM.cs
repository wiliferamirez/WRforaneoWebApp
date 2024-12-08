using Microsoft.AspNetCore.Mvc.Rendering;
namespace foraneoApp.Models.ViewModels;

public class EventVM
{
    public Event Event { get; set; }

    public IEnumerable<SelectListItem> CategoryList { get; set; }
}