using AutoMapper;
using Discount.API.Data;
using Discount.API.Entities;
using Discount.API.Infra;
using Discount.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly PostgresContext _context;

        private readonly IMapper _mapper;

        public DiscountRepository(PostgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponDTO> GetDiscount(string productName)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.ProductName == productName);

            if (coupon == null)
                return new CouponDTO { ProductName = "No discount", Amount = 0, Description = "", Id = 0 };

            return _mapper.Map<CouponDTO>(coupon);
        }
        public async Task<bool> CreateDiscount(CouponDTO coupon)
        {
            var existingCoupon = await GetDiscount(coupon.ProductName);

            if (existingCoupon.Id != 0)
                return false;

            await _context.Coupons.AddAsync(_mapper.Map<Coupon>(coupon));

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateDiscount(CouponDTO coupon)
        {
            var existingCoupon = await GetDiscount(coupon.ProductName);

            if (existingCoupon.Id == 0)
                return false;

            _context.Coupons.Update(_mapper.Map<Coupon>(coupon));

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            try
            {
                var existingCoupon = await _context.Coupons.FirstOrDefaultAsync(x => x.ProductName == productName);

                if (existingCoupon == null) return false;

                _context.Coupons.Remove(existingCoupon);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}