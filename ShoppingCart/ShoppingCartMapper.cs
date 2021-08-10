using AutoMapper;
using ShoppingCart.Models;

namespace ShoppingCart
{
    public class ShoppingCartMapper : Profile
    {
        public ShoppingCartMapper()
        {
            CreateMap<Product, CartItem>()
                .ForMember(dest => dest.Price, src => src.MapFrom(s => s.ProductPrice))
                .ForMember(dest => dest.ProductName, src => src.MapFrom(s => s.Name));
        }
    }
}
