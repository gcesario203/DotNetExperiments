using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (orderContext.Orders.Any())
                return;

            orderContext.Orders.AddRange(GetPreconfiguredOrders());

            await orderContext.SaveChangesAsync();
            
            logger.LogInformation($"Seed database associated with context {typeof(OrderContext).Name}");
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {
                            UserName = "swn",
                            FirstName = "Mehmet",
                            LastName = "Ozkaya",
                            EmailAddress = "ezozkme@gmail.com",
                            AddressLine = "Bahcelievler",
                            Country = "Turkey",
                            TotalPrice = 350,
                            CardName = "Nome",
                            CardNumber = "777",
                            CVV = "dbd",
                            Expiration= "Amanha",
                            LastModifiedBy = "swn",
                            LastModifiedDate = DateTime.Now,
                            State = "RJ",
                            ZipCode ="12345" }
            };
        }
    }
}