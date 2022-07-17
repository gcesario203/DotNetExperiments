using Basket.UnitTests.Utils;
using Basket.UnitTests.Utils.Mocks.Entities;
using Basket.UnitTests.Utils.Mocks.Implementations;

namespace Basket.UnitTests;

public class ShoppingCartEntityTests
{
    [Fact]
    public void ShouldGetReadJsonFile()
    {
        var products = new JsonFileMockReader<ProductMock>().Read().GetAwaiter().GetResult();

        Assert.NotEqual(0M, products.Count());
    }

    [Fact]
    public void ShouldCreateShoppingCart()
    {
        var shoppingCart = Constants.GenerateShoppingCarts().FirstOrDefault();

        var compare = Constants.GetShoppingCartTotal(shoppingCart.Items);
        var shouldBe = shoppingCart.TotalPrice;
        Assert.Equal(compare, shouldBe);
    }
}