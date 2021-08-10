using ShoppingCart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface IInventoryService
    {
        Task BuildInventoryAsync();
        Task<IList<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(int productId, int quantity);
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
            Product appleProduct = new Product("Apple", 20, ProductType.Vegetables, 0.20f);
            var appleOffers = await _productOfferService.RetriveProductOfferAsync(appleProduct.ProductId);
            appleProduct.Offers.AddRange(appleOffers);
            _inventory.Products.Add(appleProduct);

            var bananaProduct = new Product("Banana", 10, ProductType.Vegetables, 0.50f);
            var bananaOffers = await _productOfferService.RetriveProductOfferAsync(bananaProduct.ProductId);
            bananaProduct.Offers.AddRange(bananaOffers);
            _inventory.Products.Add(bananaProduct);
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
    }
}
