using System;
using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public class Product
    {
        public Guid ProductId => Guid.NewGuid();

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Stock AvailableStock { get; private set; }
        public ProductType Type { get; private set; }

        public float ProductPrice { get; private set; }

        public List<Offer> Offers { get; set; } = new List<Offer>();
        public Product(string description, int totalQuantity, ProductType productType, float price)
        {
            AvailableStock = new Stock(ProductId, totalQuantity);
            Name = Description = description;
            Type = productType;
            ProductPrice = price;
        }
    }
}
