using finalProject.Data;
using finalProject.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// -------------- IMPORTANT --------------
// During migration, we use the normal connection string.
// AFTER migration succeeds, we turn Key Vault back ON.
// ----------------------------------------

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(cs);
});

builder.Services.AddScoped<UserService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
