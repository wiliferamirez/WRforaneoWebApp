using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace foraneoApp.Models;

public class ApplicationUser : IdentityUser
{
    [Required(ErrorMessage = "Cedula is required")]
    [StringLength(10, ErrorMessage = "Céula Inavalid", MinimumLength = 10)]
    [Display(Name = "Cedula")]
    public string UserCedula { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Nome Invalid", MinimumLength = 3)]
    [Display(Name = "Name")]
    public string UserFirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, ErrorMessage = "Last name Invalid", MinimumLength = 3)]
    [Display(Name = "Last name")]
    public string UserLastName { get; set; }
    
    [Required(ErrorMessage = "Provice is required")]
    [Display(Name = "Provice")]
    public string UserProvince { get; set; }
    
    [Required(ErrorMessage = "Program is required")]
    [Display(Name = "Program")]
    public string UserProgram { get; set; }
    
    [Required(ErrorMessage = "Birthday is required")]
    [DataType(DataType.Date)]
    [Display(Name = "Birthday")]
    public DateOnly UserBirthDate { get; set; }
    
    [Display(Name = "Creation Date")]
    public DateTime UserCreatedAt { get; set; } = DateTime.Now;
}