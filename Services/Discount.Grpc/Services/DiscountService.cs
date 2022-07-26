using Discount.Grpc.Repositories.Interfaces;
using Discount.Grpc.Protos;
using Grpc.Core;
using AutoMapper;
using Discount.Grpc.Data;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repo;
        private readonly ILogger<DiscountService> _logger;

        private readonly IMapper _mapper;
        public DiscountService(IDiscountRepository repository, ILogger<DiscountService> logger, IMapper mapper)
        {
            _repo = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<CouponRpcModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repo.GetDiscount(request.ProductName);

            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with product name: {request.ProductName} not found"));
            }

            return _mapper.Map<CouponRpcModel>(coupon);
        }

        public override async Task<CouponRpcModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var result = await _repo.CreateDiscount(_mapper.Map<CouponDTO>(request.Coupon));

            if (result == true)
            {
                _logger.LogInformation($"Discount sucessfully created");

                return request.Coupon;
            }

            _logger.LogInformation($"Error creating coupon");

            return request.Coupon;
        }
        public override async Task<CouponRpcModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var result = await _repo.UpdateDiscount(_mapper.Map<CouponDTO>(request.Coupon));

            if (result == true)
            {
                _logger.LogInformation($"Discount sucessfully updated");

                return request.Coupon;
            }

            _logger.LogInformation($"Error updating coupon");

            return request.Coupon;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var result = await _repo.DeleteDiscount(request.ProductName);

            var response = new DeleteDiscountResponse{
                Success = result
            };

            if (result == true)
            {
                _logger.LogInformation($"Discount sucessfully deleted");

                return response;
            }

            _logger.LogInformation($"Error deleting coupon");

            return response;
        }
    }
}