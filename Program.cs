using Microsoft.Build.Framework;
using System.Security.Policy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
//app.MapControllerRoute(
//    name: "course",
//    pattern: "{controller=Course}/{id?}");

app.MapControllerRoute(
    name: "course",
    pattern: "{controller=Course}/{action=index}/{id?}");
//app.MapControllerRoute(
//    name: "Course",
//    pattern: "{controller=Course}/{action=Index}");

app.Run();
