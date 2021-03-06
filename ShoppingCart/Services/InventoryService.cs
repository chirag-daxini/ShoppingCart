using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface IInventoryService
    {
        Task BuildInventoryAsync();
        Task<IList<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(int productId, int quantity);

        Task<Product> GetProductAsync(Guid productId);
    }
    public class InventoryService : IInventoryService
    {
        private readonly IProductOfferService _productOfferService;
        private readonly Inventory _inventory;
        public InventoryService(IProductOfferService productOfferService, Inventory inventory)
        {
            _productOfferService = productOfferService;
            _inventory = inventory;
        }
        public async Task BuildInventoryAsync()
        {
            Product appleProduct = new Product("Apple", 100, ProductType.Vegetables, 0.20m);
            appleProduct.Offer = new Offer() { Description = "Buy1Get1Free", OfferStratergy = OfferType.QuantityDiscount };
            _inventory.Products.Add(appleProduct);

            var bananaProduct = new Product("Banana", 150, ProductType.Vegetables, 0.50m);
            bananaProduct.Offer = new Offer() { Description = "Buy1Get1Free", OfferStratergy = OfferType.QuantityDiscount };
            _inventory.Products.Add(bananaProduct);

            var mangoProduct = new Product("Mangoes", 200, ProductType.Vegetables, 1.50m);
            mangoProduct.Offer = new Offer() { Description = "Buy2AtDiscountedRate", OfferStratergy = OfferType.PriceDiscount, DiscountedPercentage = 33 };
            _inventory.Products.Add(mangoProduct);
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            return _inventory.Products;
        }

        public async Task<Product> GetProductAsync(int productId, int quantity)
        {
            var enteredProduct = _inventory[productId - 1];

            return (enteredProduct != null && enteredProduct.AvailableStock.AvailableQuantity > quantity) ? enteredProduct : null;
        }

        public async Task<Product> GetProductAsync(Guid productId)
        {
            var product = _inventory[productId];
            return product;
        }
    }
}
