using Microsoft.AspNetCore.Mvc;

namespace StoraApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}