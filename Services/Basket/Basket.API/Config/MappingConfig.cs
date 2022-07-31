using AutoMapper;
using Basket.API.Data;
using Discount.Grpc.Protos;

namespace Basket.API.Config
{

    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, CouponRpcModel>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}