using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace foraneoApp.Models;

public class Event
{
    [Key]
    public int eventId { get; set; }

    [Required(ErrorMessage = "Please enter the name of the event")]
    [StringLength(100, ErrorMessage = "Event title cannot exceed 100 characters")]
    [Display(Name = "Event Title")]
    public string title { get; set; }

    [Required(ErrorMessage = "Please enter the description of the event")]
    [StringLength(600, ErrorMessage = "Event description cannot exceed 600 characters")]
    [Display(Name = "Event Description")]
    public string description { get; set; }
    
    [Required(ErrorMessage = "Please select a category")]
    public int categoryId { get; set; }

    [ForeignKey(nameof(categoryId))]
    [ValidateNever]
    public Category category { get; set; }

    [Required(ErrorMessage = "Please enter the location of the event")]
    [Display(Name = "Location")]
    public string location { get; set; }

    [DataType(dataType: DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
    [Display(Name = "Start Date")]
    [Required(ErrorMessage = "Please enter the start date of the event")]
    public DateTime startDate { get; set; }

    [DataType(DataType.DateTime)]
    [Display(Name = "Creation Date")]
    public DateTime creationDate { get; set; } = DateTime.Now;

}