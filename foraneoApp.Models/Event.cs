using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace foraneoApp.Models;

public class Event
{
    [Key]
    public int eventId { get; set; }
    
    [Required(ErrorMessage = "Please enter the name of the event")]
    [StringLength(100, ErrorMessage = "Event title cannot exceed 100 characters")]
    public string title { get; set; }
    
    [Required(ErrorMessage = "Please enter the description of the event")]
    [StringLength(600, ErrorMessage = "Event description cannot exceed 600 characters")]
    public string description { get; set; }
    
    [DataType(DataType.ImageUrl)]
    [Display(Name = "Event Image")]
    [Url(ErrorMessage = "Please enter a valid image url")]
    public string urlImage { get; set; }
    
    [Required(ErrorMessage = "Please select a category")]
    public int categoryId { get; set; }
    
    [ForeignKey(nameof(categoryId))]
    public Category category { get; set; }
    
    [Required(ErrorMessage = "Please enter the location of the event")]
    public string location { get; set; }
    
    [DataType(dataType: DataType.Date)]
    public DateTime startDate { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime creationDate { get; set; } = DateTime.Now;
    
}