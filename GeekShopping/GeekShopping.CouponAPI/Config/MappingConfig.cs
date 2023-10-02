using AutoMapper;

namespace GeekShopping.CouponAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<Product, ProductVO>().ReverseMap();
            });
                
            return mappingConfig;
        }
    }
}
