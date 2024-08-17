using StoreApp.InfraStructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

/* ServiceExtension dosyasına taşındı
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("StoreApp"));
});  Bu ifade yerine 20. satırdaki ifadeyi yazacağız */


//this ile belirtilen ifadelerdeilk parametre verilmez
builder.Services.ConfigureDbContext(builder.Configuration);

/* ServiceExtension dosyasına taşındı
builder.Services.AddDistributedMemoryCache(); //sunucu tarafında ön bellek sağlar
builder.Services.AddSession(o =>
{
    o.Cookie.Name = "StoreApp.Session";
    o.IdleTimeout = TimeSpan.FromMinutes(10);
}); //session'ların hafızada kaç dakika tutulacağını gösteriyor 
Bu ifadeler yerine 32. satırdaki ifadeyi yazacağız
*/

builder.Services.ConfigureSession();

/* ServiceExtension dosyasına taşındı
//Repositories kayıtları
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
//Repositories kayıtları
Bu ifadeler yerine 45. satırdaki ifadeyi yazacağız */

builder.Services.ConfigureRepositoryRegistration();

/* ServiceExtension dosyasına taşındı
//Services kayıtları
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();
//Services kayıtları
Bu ifadeler yerine 56. satırdaki ifadeyi yazacağız */

/* ServiceExtension dosyasına taşındı
builder.Services.AddScoped<Card>(SessionCard.GetCard); */

builder.Services.ConfigureServiceRegistration();

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
