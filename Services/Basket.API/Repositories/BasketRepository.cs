using System.Text.Json;
using Basket.API.Entities;
using Basket.API.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redis;

        public BasketRepository(IDistributedCache redisContext)
        {
            _redis = redisContext;
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redis.GetStringAsync(userName);

            if (string.IsNullOrEmpty(basket))
                return null;

            return JsonSerializer.Deserialize<ShoppingCart>(basket);
        }

        public async Task DeleteBasket(string userName)
        {
            var basket = await GetBasket(userName);

            if (basket == null)
                return;

            await _redis.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _redis.SetStringAsync(basket.UserName, JsonSerializer.Serialize<ShoppingCart>(basket));
            return await GetBasket(basket.UserName);
        }
    }
}