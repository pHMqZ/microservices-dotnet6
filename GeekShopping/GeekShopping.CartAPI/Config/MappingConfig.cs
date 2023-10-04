using AutoMapper;
using GeekShopping.OrderAPI.Data.ValueObjects;
using GeekShopping.OrderAPI.Model;

namespace GeekShopping.OrderAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig =  new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductVO>().ReverseMap();
                config.CreateMap<CartHeader, CartHeaderVO>().ReverseMap();
                config.CreateMap<CartDetail, CartDetailVO>().ReverseMap();
                config.CreateMap<Cart, CartVO>().ReverseMap();
            });



            return mappingConfig;
        }
    }
}
