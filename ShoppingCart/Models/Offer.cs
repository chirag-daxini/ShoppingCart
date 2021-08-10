using System;

namespace ShoppingCart.Models
{
    public class Offer
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Description { get; set; }

        public OfferType OfferStratergy { get; set; }
        public decimal DiscountedPercentage { get; set; }
    }
}
