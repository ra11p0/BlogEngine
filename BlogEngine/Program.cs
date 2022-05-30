using DatabaseAccess;
using DatabaseAccess.DbModels;
using Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogDbContext>(e =>
{
    e.UseSqlServer(builder.Configuration.GetConnectionString("BlogEngineConnectionString"),
        o => o.MigrationsAssembly("BlogEngine"));
});

builder.Services.AddDbContext<BlogIdentityDbContext>(e =>
{
    e.UseSqlServer(builder.Configuration.GetConnectionString("BlogEngineIdentityConnectionString"),
        o=>o.MigrationsAssembly("BlogEngine"));
});

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<BlogIdentityDbContext>();


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute("Blog", "Blog/{blogId:int}", new { Controller = "Blog", Action = "Index" });
app.MapControllerRoute("BlogCreate", "Blog/Create", new { Controller = "Blog", Action = "Create" });

app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
