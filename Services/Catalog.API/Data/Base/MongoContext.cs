
using Catalog.API.Data.Interfaces;
using Catalog.API.Entities.Interfaces;
using MongoDB.Driver;

namespace Catalog.API.Data.Base
{
    public abstract class MongoContext<T> : IContext<T> where T : IEntity
    {
        private readonly MongoDbUnitOfWork _unitOfWork;
        public IMongoCollection<T> _collection { get; }

        public MongoContext(MongoDbUnitOfWork unitOfWork, IMongoContextSeeder<T> seeder)
        {
            _unitOfWork = unitOfWork;

            _collection = unitOfWork.GetCollection<T>();

            seeder.SeedData(_collection);
        }
    }
}