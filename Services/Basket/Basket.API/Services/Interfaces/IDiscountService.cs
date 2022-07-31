using Basket.API.Data;

namespace Basket.API.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<CouponDTO> GetDiscount(string productName);
    }
}