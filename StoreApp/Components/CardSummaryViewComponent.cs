using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace StoraApp.Components
{
    public class CardSummaryViewComponent : ViewComponent
    {
        private readonly Card _card;

        public CardSummaryViewComponent(Card cardService)
        {
            _card = cardService;
        }

        public string InVoke()
        {
            
            return _card.Lines.Count().ToString();
        }
    }
}