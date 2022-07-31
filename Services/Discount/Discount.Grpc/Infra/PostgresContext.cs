using Discount.Grpc.Entities;
using Discount.Grpc.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Infra
{
    public class PostgresContext : DbContext,IContext
    {
        public DbSet<Coupon> Coupons {get;set;}
        
        public PostgresContext(DbContextOptions configs) : base(configs)
        {
        }
    }
}