using Microsoft.EntityFrameworkCore;
using RepoPatternAsgn.Models;
using RepoPatternAsgn.Repository;
using RepoPatternAsgn.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HotelDbContext>(options => options.UseSqlServer("data source=PTSQLTESTDB01;database=MVCPrathikHotel;integrated security=true;TrustServerCertificate=True;"));
builder.Services.AddScoped<IHotel, HotelService>();
builder.Services.AddScoped<IRoom, RoomService>();
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
