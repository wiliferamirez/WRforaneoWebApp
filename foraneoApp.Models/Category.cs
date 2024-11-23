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
    public int? Order { get; set; }
}