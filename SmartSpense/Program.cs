using Microsoft.EntityFrameworkCore;
using SmartSpense.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SmartSpenseDbContext>(options =>
options.UseSqlServer("Server=DESKTOP-RD02GVG;Database=SmartSpense;TrustServerCertificate=True;MultipleActiveResultSets=true;integrated security=True;",
sqlServerOptions => sqlServerOptions.EnableRetryOnFailure())

    );/*
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<SmartSpenseDbContext>(options =>
    options.UseSqlServer(connectionString));

  "ConnectionStrings": {
    "DefaultConnection": "Server=ANONYMOUST;Database=ZHotelMenuAndOrder;TrustServerCertificate=True;MultipleActiveResultSets=true;integrated security=True;"
  },
*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
