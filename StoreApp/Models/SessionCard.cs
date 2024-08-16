using System.Text.Json.Serialization;
using Entities.Models;
using StoreApp.InfraStructure.Extensions;

namespace StoreApp.Models
{
    public class SessionCard : Card
    {
        [JsonIgnore] //session kendini tekrar yazmasın istiyoruz
        public ISession? Session { get; set; }

        public static Card GetCard(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
            SessionCard card = session?.GetJson<SessionCard>("card")??new SessionCard();
            card.Session = session;
            return card;
        }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson<SessionCard>("card",this);
        }
        public override void Clear()
        {
            base.Clear();
            Session?.Remove("card");
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session?.SetJson<SessionCard>("card",this);
        }
    }
}