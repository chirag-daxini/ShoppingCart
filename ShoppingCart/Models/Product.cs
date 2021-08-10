using System;

namespace ShoppingCart.Models
{
    public class Product
    {
        public Guid ProductId { get; private set; } = Guid.NewGuid();

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Stock AvailableStock { get; private set; }
        public ProductType Type { get; private set; }

        public decimal ProductPrice { get; set; }

        public Offer Offer { get; set; }
        public Product(string description, int totalQuantity, ProductType productType, decimal price)
        {
            AvailableStock = new Stock(ProductId, totalQuantity);
            Name = Description = description;
            Type = productType;
            ProductPrice = price;
        }
    }
}
