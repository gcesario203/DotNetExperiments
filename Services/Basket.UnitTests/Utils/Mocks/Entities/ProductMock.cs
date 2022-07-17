using Basket.UnitTests.Utils.Mocks.Interfaces;

namespace Basket.UnitTests.Utils.Mocks.Entities
{
    public class ProductMock : IMock
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}