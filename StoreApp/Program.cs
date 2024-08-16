using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("StoreApp"));
});

builder.Services.AddDistributedMemoryCache(); //sunucu tarafında ön bellek sağlar
builder.Services.AddSession(o =>
{
    o.Cookie.Name = "StoreApp.Session";
    o.IdleTimeout = TimeSpan.FromMinutes(10);
}); //session'ların hafızada kaç dakika tutulacağını gösteriyor

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Repositories kayıtları
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
//Repositories kayıtları

//Services kayıtları
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<Card>(SessionCard.GetCard);
//Services kayıtları

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(e =>
{
    e.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    e.MapControllerRoute(
    "default",
    "{Controller=Home}/{action=Index}/{id?}"
    );
    e.MapRazorPages();
});

app.Run();
