using System.ComponentModel.DataAnnotations;

namespace foraneoApp.Models;

public class Category
{
    [Key]
    public int categoryId { get; set; }
    [Required(ErrorMessage = "Category Name is required")]
    [Display(Name = "Category Name")]
    public string categoryName { get; set; }
    [Display(Name = "Visualization sort")]
    [Range(1, 10, ErrorMessage = "Visualization sort must be between 1 and 10")]
    public int? Order { get; set; }
}