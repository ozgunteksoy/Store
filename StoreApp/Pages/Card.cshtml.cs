using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoraApp.Pages
{
    public class CardModel : PageModel
    {
        private readonly IServiceManager _manager;
        public Card? Card { get; set; } //IoC
        public string ReturnUrl { get; set; } = "/";

        public CardModel(IServiceManager manager, Card card)
        {
            _manager = manager;
            Card = card;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetOneProduct(productId,false);

            if (product is not null)
            {
                Card?.AddItem(product,1);
            }
            return Page();
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            Card?.RemoveLine(Card.Lines.First(c1=>c1.Product.ProductId.Equals(id)).Product);
            return Page();
        }
    }
}