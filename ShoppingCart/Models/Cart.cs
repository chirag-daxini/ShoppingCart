using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Models
{
    public class Cart
    {
        public IList<CartItem> Items { get; set; } = new List<CartItem>();

        public override string ToString()
        {
            var products = string.Join(",", Items.Select(item => item.ProductName));
            var totalPrice = Items.Sum(item => item.Price);
            return $"[{products} => {totalPrice}]";
        }
    }
}
