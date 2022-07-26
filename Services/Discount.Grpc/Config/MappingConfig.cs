using AutoMapper;
using Discount.Grpc.Data;
using Discount.Grpc.Entities;

namespace Discount.Grpc.Config
{

    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}