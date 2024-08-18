using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;

namespace StoraApp.Controllers
{
    public class ProductController : Controller
    {
        // DI (Dependency of Injection) çerçevesi
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        // DI (Dependency of Injection) çerçevesi

        public /*IEnumerable<Product>*/ IActionResult Index(ProductRequestParameters p)
        {
            /* var context = new RepositoryContext(
                new DbContextOptionsBuilder<RepositoryContext>().UseSqlite("Data Source = C:\\Users\\ozgun\\source\\GitHub\\MVC\\Store\\ProductDb.db").Options // DI olmazsa bunu yazmak zorundayız 
             ); */
            var model = _manager.ProductService.GetAllProductsWithDetails(p);
            return View(model);
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            // Product product = _context.Products.First(p => p.ProductId.Equals(id));
            return View(model);
        }
    }
}