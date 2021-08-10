using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface IProductOfferService
    {
        Task<List<Offer>> RetriveProductOfferAsync(Guid productId);
    }
    public class ProductOfferService : IProductOfferService
    {
        public async Task<List<Offer>> RetriveProductOfferAsync(Guid productId)
        {
            return new List<Offer>();
        }
    }
}
