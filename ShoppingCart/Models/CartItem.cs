using System;

namespace ShoppingCart.Models
{
    public class CartItem
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public string ProductName { get; set; }
    }
}
