using Catalog.API.Entities.Interfaces;
using MongoDB.Driver;

namespace Catalog.API.Data.Interfaces
{
    public interface IMongoContextSeeder<T> where T: IEntity
    {
        void SeedData(IMongoCollection<T> collection);
    }
}