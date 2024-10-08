using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly Card _card;

        public OrderController(IServiceManager manager, Card card)
        {
            _manager = manager;
            _card = card;
        }
        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Order order)
        {
            if (_card.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your card is empty");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _card.Lines.ToArray();
                _manager.OrderService.SaveOrder(order);
                _card.Clear();
                return RedirectToPage("/Complete", new { OrderId = order.OrderId });
            }
            else
            {
                return View();
            }
        }
    }
}