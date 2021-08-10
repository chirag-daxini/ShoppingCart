using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Models
{
    public class Cart
    {
        public IList<CartItem> Items { get; set; } = new List<CartItem>();

        public CartItem this[Guid i] => Items.Single(p => p.ProductId == i);

        public override string ToString()
        {
            if (Items.Any())
            {
                var products = string.Join(",", Items.Select(item => item.ProductName));
                var totalPrice = Items.Sum(item => item.Price);
                return $"[{products} => {totalPrice:C}]";
            }
            return string.Empty;
        }
    }
}
