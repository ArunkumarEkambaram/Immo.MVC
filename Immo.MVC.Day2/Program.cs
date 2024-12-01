using Immo.MVC.Day2.GlobalExceptions;
using Immo.MVC.Day2.Models;
using Immo.MVC.Day2.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Resolve ConnectionString 
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ImmoDBConn"));
});

//Resolve DI
builder.Services.AddScoped<IRepositoryWithCategory<Product>, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // app.UseExceptionHandler("/Home/Error");
    app.UseExceptionHandler(FileNotFoundExceptionHandler.CustomError);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseStatusCodePages();
//app.UseStatusCodePagesWithRedirects("/MyException/StatusCodeErrorPage?code={0}");
app.UseStatusCodePagesWithReExecute("/MyException/StatusCodeErrorPage", "?code={0}");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
