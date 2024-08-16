using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.InfraStructure.Extensions;

namespace StoraApp.Pages
{
  public class CardModel : PageModel
  {
    private readonly IServiceManager _manager;
    public Card Card { get; set; } //IoC
    public string ReturnUrl { get; set; } = "/";

    public CardModel(IServiceManager manager, Card cartService)
    {
      _manager = manager;
      Card = cartService;
    }

    public void OnGet(string returnUrl)
    {
      ReturnUrl = returnUrl ?? "/";
      //  Card = HttpContext.Session.GetJson<Card>("card") ?? new Card();
    }

    public IActionResult OnPost(int productId, string returnUrl)
    {
      Product? product = _manager.ProductService.GetOneProduct(productId, false);

      if (product is not null)
      {
        //  Card = HttpContext.Session.GetJson<Card>("card") ?? new Card();
        Card?.AddItem(product, 1);
        //  HttpContext.Session.SetJson<Card>("card", Card);
      }
      return RedirectToPage(new { returnUrl = returnUrl }); //returnUrl
    }

    public IActionResult OnPostRemove(int id, string returnUrl)
    {
      //  Card = HttpContext.Session.GetJson<Card>("card") ?? new Card();
      Card?.RemoveLine(Card.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
      //  HttpContext.Session.SetJson<Card>("card", Card);
      return Page();
    }
  }
}