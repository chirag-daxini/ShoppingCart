using System;

namespace ShoppingCart.Models
{
    public class Stock
    {
        public Guid StockId { get; private set; } = Guid.NewGuid();

        public Guid ProductId { get; private set; }

        public int TotalQuantity { get; set; }

        public int AvailableQuantity { get; set; }
        public Stock(Guid productId, int totalQuantity)
        {
            ProductId = productId;
            TotalQuantity = AvailableQuantity = totalQuantity;
        }
    }
}
