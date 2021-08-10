using AutoMapper;
using Microsoft.Extensions.Hosting;
using ShoppingCart.Models;
using ShoppingCart.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Startup : IHostedService
    {
        private readonly IInventoryService _inventoryService;
        private readonly ICheckoutService _checkOutService;
        private readonly IMapper _mapper;
        public Startup(IInventoryService inventoryService, ICheckoutService checkoutService, IMapper mapper)
        {
            _inventoryService = inventoryService;
            _checkOutService = checkoutService;
            _mapper = mapper;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Building Product catalog");
            await _inventoryService.BuildInventoryAsync();

            Console.WriteLine("Welcome to Online Shopping");

            Console.WriteLine("Following products are available today.");

            var products = await _inventoryService.GetProductsAsync();

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i].Description}");
            }

            string userWantstoExit;

            do
            {
                Console.WriteLine("Please enter product id to add into shopping cart : ");

                var enteredId = Console.ReadLine().ToString();

                Console.WriteLine("Enter quantity : ");

                var enteredQuantity = Console.ReadLine().ToString();

                int productId;
                int productQuantity;

                if (int.TryParse(enteredId, out productId) && int.TryParse(enteredQuantity, out productQuantity))
                {
                    var objProduct = await _inventoryService.GetProductAsync(productId, productQuantity);
                    if (objProduct != null)
                    {
                        var cartItem = _mapper.Map<CartItem>(objProduct);

                        cartItem.Quantity = productQuantity;
                        cartItem.Price = objProduct.ProductPrice * productQuantity;

                        objProduct.AvailableStock.AvailableQuantity = objProduct.AvailableStock.AvailableQuantity - productQuantity;

                        await _checkOutService.AddProductToCartAsync(cartItem);

                        await _checkOutService.ApplyDiscounts();

                        Console.WriteLine($"Product {objProduct.Name} added to the cart");
                    }
                    else
                        Console.WriteLine("You have entered invalid ProductId or not enough quantity is available for selected product");

                }

                Console.WriteLine("Do you like to add another product Y or N ??");
                userWantstoExit = Console.ReadLine();

            } while (userWantstoExit.ToLower() != "n");

            Console.WriteLine("You have added following items to shopping cart :");

            Console.WriteLine($"{await _checkOutService.RetriveCartAsync()}");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Exiting from application");
        }
    }
}
