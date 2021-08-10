using ShoppingCart.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface ICheckoutService
    {
        Task<bool> AddProductToCartAsync(CartItem product);
        Task<Cart> RetriveCartAsync();
        Task ApplyDiscounts();
    }
    public class CheckoutService : ICheckoutService
    {
        private readonly Cart _cart;
        private readonly IInventoryService _inventoryService;
        public CheckoutService(Cart cart, IInventoryService inventoryService)
        {
            _cart = cart;
            _inventoryService = inventoryService;
        }
        public async Task<bool> AddProductToCartAsync(CartItem product)
        {
            _cart.Items.Add(product);
            return true;
        }

        public async Task<Cart> RetriveCartAsync()
        {
            return _cart;
        }

        public async Task ApplyDiscounts()
        {
            foreach (var item in _cart.Items)
            {
                var product = await _inventoryService.GetProductAsync(item.ProductId);

                var cartItem = _cart[item.ProductId];

                if (product.Offer != null)
                {
                    switch (product.Offer.OfferStratergy)
                    {
                        case OfferType.PriceDiscount:
                            {
                                cartItem.Price = cartItem.Price - (cartItem.Price * product.Offer.DiscountedPercentage / 100);
                                break;
                            }
                        case OfferType.QuantityDiscount:
                            {
                                if (product.AvailableStock.AvailableQuantity > cartItem.Quantity + 1)
                                {
                                    cartItem.Quantity += 1;
                                    product.AvailableStock.AvailableQuantity -= 1;
                                }
                                break;
                            }
                    }
                }
            }
        }
    }
}
