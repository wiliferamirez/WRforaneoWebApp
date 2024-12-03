using System.ComponentModel.DataAnnotations;
namespace foraneoApp.Models;

public class User
{
    [Key]
    [Required (ErrorMessage="cedula is required")]
    [Display(Name ="Cedula")]
    public string cedulaUser { get; set; }
    
    [Required (ErrorMessage="Name is required")]
    [Display(Name ="User name")]
    public string userName { get; set; }
    
    [Required (ErrorMessage="Surname is required")]
    [Display(Name ="User surname")]
    public string surnameUser { get; set; }
    
    [Required (ErrorMessage="Email is required")]
    [EmailAddress(ErrorMessage="Email is invalid")]
    public string userEmail { get; set; }
    
    [Required (ErrorMessage="Program is required")]
    public string userProgram { get; set; }
    
    [Required (ErrorMessage="BirthDay is required")]
    [Display(Name ="BirthDay")]
    public DateOnly dateOfBirth { get; set; }
    
    public DateTime signupDate { get; set; }
    
    [Required (ErrorMessage="Password is required")]
    public string password { get; set; }
    
    
}