namespace Entities.Models
{
    public class Card // Seperitn içindeki işlemleri tanımlıyoruz
    {
        public List<CardLine> Lines { get; set; }
        public Card()
        {
            Lines = new List<CardLine>();
        }
        public void AddItem(Product product, int quantity)
        {
            CardLine? line = Lines.Where(l => l.Product.ProductId.Equals(product.ProductId)).FirstOrDefault();

            if (line is null)
            {
                Lines.Add(new CardLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity = quantity;
            }
        }

        public void RemoveLine(Product product) => Lines.RemoveAll(l => l.Product.ProductId.Equals(product.ProductId));

        public decimal ComputeTotalValue() => Lines.Sum(e => e.Product.Price * e.Quantity);

        public void Clear()=>Lines.Clear();
    }
}