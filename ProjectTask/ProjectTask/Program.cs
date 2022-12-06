using ProjectTask.DAL.Interface;
using ProjectTask.Domain.Entity;
using ProjectTask.Service.Implementation;
using ProjectTask.DAL.Repositories;
using ProjectTask.Service.Interfaces;
using ProjectTask.DAL;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IBaseRepository<Mission>, MissionRepository>();
builder.Services.AddScoped<IBaseRepository<Project>, ProjectRepository>();

builder.Services.AddScoped<IMissionService, MissionService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddControllers();

// set connection to MS SQL Server
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connection));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthorization();

app.MapRazorPages();

app.Run();
