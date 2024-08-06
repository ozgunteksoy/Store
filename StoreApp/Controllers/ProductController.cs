using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;

namespace StoraApp.Controllers
{
    public class ProductController : Controller
    {
        // DI (Dependency of Injection) çerçevesi
        private readonly IRepositoryManager _manager;

        public ProductController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        // DI (Dependency of Injection) çerçevesi

        public /*IEnumerable<Product>*/ IActionResult Index()
        {
            /* var context = new RepositoryContext(
                new DbContextOptionsBuilder<RepositoryContext>().UseSqlite("Data Source = C:\\Users\\ozgun\\source\\GitHub\\MVC\\Store\\ProductDb.db").Options // DI olmazsa bunu yazmak zorundayız 
             ); */
            var model = _manager.Product.GetAllProducts(false);
            return View(model);
        }

        public IActionResult Get(int id)
        {
           // Product product = _context.Products.First(p => p.ProductId.Equals(id));
            throw new NotImplementedException();
        }
    }
}