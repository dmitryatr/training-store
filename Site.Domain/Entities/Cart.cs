using System.Collections.Generic;
using System.Linq;

namespace Site.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Vinyl vinyl, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Vinyl.VinylId == vinyl.VinylId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Vinyl = vinyl,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Vinyl vinyl)
        {
            lineCollection.RemoveAll(l => l.Vinyl.VinylId == vinyl.VinylId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Vinyl.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Vinyl Vinyl { get; set; }
        public int Quantity { get; set; }
    }
}