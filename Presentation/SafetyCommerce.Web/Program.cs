using Microsoft.EntityFrameworkCore;
using SafetyCommerce.Application;
using SafetyCommerce.Infrastructure;
using SafetyCommerce.Persistence;
using SafetyCommerce.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//var conString = builder.Configuration.GetConnectionString("SqlConnection");
//builder.Services.AddDbContext<SafetyCommerceDbContext>(options => options.UseSqlServer(conString));
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService();
builder.Services.AddPersistenceServices();

 var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
