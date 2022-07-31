using Basket.UnitTests.Utils.Mocks.Interfaces;

namespace Basket.UnitTests.Utils.Mocks.Implementations
{
    public abstract class MockReader<TMock> : IReadable<TMock> where TMock : IMock
    {
        public abstract Task<IEnumerable<TMock>> Read();
    }
}