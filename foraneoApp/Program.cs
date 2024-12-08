using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using foraneoApp.DataAccess.Data;
using foraneoApp.DataAccess.Data.Repository;
using foraneoApp.DataAccess.Data.Repository.IRepository;
using foraneoApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Updated Identity configuration
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => 
    {
        options.User.RequireUniqueEmail = true;
        // Add additional Identity options as needed
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

// Add MVC and Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Additional service registrations
builder.Services.AddScoped<IWorkContainer, WorkContainer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Add this line
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=client}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();