using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Models
{
    public class Inventory
    {
        public Guid InventoryId { get; private set; } = Guid.NewGuid();
        public List<Product> Products { get; set; } = new List<Product>();

        public Product this[int i] => Products[i];

        public Product this[Guid i] => Products.Single(p => p.ProductId == i);
    }
}
