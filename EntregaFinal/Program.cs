using EntregaFinal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TrabajoFinalNetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Fix 1: Configure ASP.NET Core Identity services correctly
// You need to add Razor Pages services and use your custom ApplicationUser class
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TrabajoFinalNetContext>();

builder.Services.AddRazorPages(); // This is essential for the Identity UI to work

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

// Fix 2: Correct the order of Authentication and Authorization
// Authentication must come before Authorization.
app.UseAuthentication();
app.UseAuthorization();

// Fix 3: Remove the duplicate call
// app.UseAuthorization(); // This line is a duplicate and should be removed

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Fix 4: Map Razor Pages routes for Identity UI
// This maps the routes for the default Identity pages (like /Identity/Account/Login)
app.MapRazorPages();

app.Run();