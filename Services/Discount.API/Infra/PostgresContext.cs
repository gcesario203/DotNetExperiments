using Discount.API.Entities;
using Discount.API.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Infra
{
    public class PostgresContext : DbContext,IContext
    {
        public DbSet<Coupon> Coupons {get;set;}
        
        public PostgresContext(DbContextOptions configs) : base(configs)
        {
        }
    }
}