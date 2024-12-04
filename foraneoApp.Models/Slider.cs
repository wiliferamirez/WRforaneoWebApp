using System.ComponentModel.DataAnnotations;

namespace foraneoApp.Models;

public class Slider
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Enter a slider name")]
    [Display(Name = "Slider Name")]
    public string sliderName { get; set; }
    
    [Required]
    public string status { get; set; }
    
    [DataType(DataType.ImageUrl)]
    [Display(Name = "Image")]
    public string urlImage { get; set; }
    
}