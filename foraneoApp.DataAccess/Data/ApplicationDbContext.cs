using System.Net.Mime;
using foraneoApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace foraneoApp.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Slider> Slider { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<ApplicationUser> Users { get; set; } 
}