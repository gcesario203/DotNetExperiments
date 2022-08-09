using AutoMapper;
using Basket.API.Data;
using Basket.API.Entities;
using Discount.Grpc.Protos;
using EventBus.Messages.Events;

namespace Basket.API.Config
{

    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, CouponRpcModel>().ReverseMap();
                config.CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}