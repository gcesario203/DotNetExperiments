using AutoMapper;
using Discount.Grpc.Data;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Config
{

    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>().ReverseMap();
                config.CreateMap<CouponDTO, CouponRpcModel>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}