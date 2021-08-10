using ShoppingCart.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface ICheckoutService
    {
        Task<bool> AddProductToCartAsync(CartItem product);
        Task<Cart> RetriveCartAsync();
    }
    public class CheckoutService : ICheckoutService
    {
        private readonly Cart _cart;
        public CheckoutService(Cart cart)
        {
            _cart = cart;
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
    }
}
