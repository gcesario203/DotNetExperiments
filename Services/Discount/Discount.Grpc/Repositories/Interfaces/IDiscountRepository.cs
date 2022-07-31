using Discount.Grpc.Data;

namespace Discount.Grpc.Repositories.Interfaces
{
    public interface IDiscountRepository
    {
        Task<CouponDTO> GetDiscount(string productName);
        Task<IEnumerable<CouponDTO>> GetDiscounts();

        Task<bool> CreateDiscount(CouponDTO coupon);
        Task<bool> UpdateDiscount(CouponDTO coupon);
        Task<bool> DeleteDiscount(string productName);
    }
}