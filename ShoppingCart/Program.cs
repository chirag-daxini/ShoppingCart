using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingCart.Models;
using ShoppingCart.Services;
using System.Threading.Tasks;

namespace ShoppingCart
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Startup>();
                    services.AddScoped<IProductOfferService, ProductOfferService>();
                    services.AddScoped<IInventoryService, InventoryService>();
                    services.AddScoped<ICheckoutService, CheckoutService>();
                    services.AddSingleton(typeof(Inventory));
                    services.AddSingleton(typeof(Cart));
                    services.AddAutoMapper(typeof(Program).Assembly);
                });
        }
    }
}
