using Basket.API.Entities;
using Basket.API.Entities.DataObject;
using Basket.UnitTests.Utils.Mocks.Entities;
using Basket.UnitTests.Utils.Mocks.Implementations;

namespace Basket.UnitTests.Utils
{
    public static class Constants
    {
        public static IEnumerable<ShoppingCartItem> GenerateShoppingCartItems()
        {
            var products = new JsonFileMockReader<ProductMock>().Read().GetAwaiter().GetResult();

            return products.Select(x => new ShoppingCartItem( new Random().Next(1, 99), new Product{ Id = x.Id, Name = x.Name, Price = x.Price})).ToList();
        }

        public static IEnumerable<ShoppingCart> GenerateShoppingCarts()
        {
            var userNames = new[]{ "Zezinho", "Luizinho", "Pedrinho", "Maria Fernanda", "Julia Bueno", "Sim"};

            return userNames.Select(x => new ShoppingCart(x, GenerateShoppingCartItems())).ToList();
        }

        public static decimal GetShoppingCartTotal(IEnumerable<ShoppingCartItem> products)
        {
            return products.Sum(x => x.GetProductValue());
        }
    }
}