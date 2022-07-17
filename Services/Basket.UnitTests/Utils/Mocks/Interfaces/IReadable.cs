namespace Basket.UnitTests.Utils.Mocks.Interfaces
{
    public interface IReadable<TMock> where TMock: IMock
    {
        Task<IEnumerable<TMock>> Read();
    }
}