using System;
using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public class Inventory
    {
        public Guid InventoryId => Guid.NewGuid();
        public List<Product> Products { get; set; } = new List<Product>();

        public Product this[int i] => Products[i];
    }
}
