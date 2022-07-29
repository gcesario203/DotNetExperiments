using AutoMapper;
using Basket.API.Data;
using Basket.API.Services.Interfaces;
using Discount.Grpc.Protos;

namespace Basket.API.Services
{
    public class DiscountGrpcService : IDiscountService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountClient;

        private readonly IMapper _mapper;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountClient, IMapper mapper)
        {
            _discountClient = discountClient;

            _mapper = mapper;
        }

        public async Task<CouponDTO> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = productName };

            var response =  await _discountClient.GetDiscountAsync(discountRequest);

            return _mapper.Map<CouponDTO>(response);
        }
    }
}