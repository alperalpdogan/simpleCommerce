using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimCom.Core.DomainModels.Users;
using SimCom.Data;
using SimCom.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.SetUpDatabase();
builder.RegisterGenericRepository();
builder.RegisterServices();
builder.RegisterFactories();
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
await app.CreateProductDummyData();
await app.CreateDummyUsers();
app.UseAuthorization();
app.EnsureMigrationOfContext<SimComDbContext>();
app.MapControllerRoute(
name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

