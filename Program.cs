using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("StudentPortal"),
    new MySqlServerVersion(new Version(8, 0, 25)))); // Adjust the MySQL version if needed

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
//app.MapRazorPages();
//app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
app.UseRouting();
app.UseEndpoints(endpoints => {  endpoints.MapControllers(); endpoints.MapRazorPages(); });
    

