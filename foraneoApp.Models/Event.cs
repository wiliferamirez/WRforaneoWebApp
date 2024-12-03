using System.ComponentModel.DataAnnotations;
namespace foraneoApp.Models;

public class Event
{
    [Key]
    public int eventId { get; set; }
    
    [Required(ErrorMessage = "Please enter the name of the event")]
    public string title { get; set; }
    [Required(ErrorMessage = "Please enter the description of the event")]
    public string description { get; set; }
    
    [Required(ErrorMessage = "Please select a category")]
    public string category { get; set; }
    
    [Required(ErrorMessage = "Please enter the location of the event")]
    [DataType(DataType.Time)]
    public string location { get; set; }
    
    [DataType(dataType: DataType.Date)]
    public DateTime startDate { get; set; }
    
    
    public string host { get; set; }
    
    
}