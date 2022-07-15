
using Catalog.API.Data.Interfaces;
using Catalog.API.Entities.Interfaces;
using MongoDB.Driver;

namespace Catalog.API.Data.Base
{
    public abstract class MongoContext<T> : IMongoContext<T> where T : IEntity
    {
        private readonly MongoDbUnitOfWork _unitOfWork;
        public IMongoCollection<T> Collection { get; }

        public MongoContext(MongoDbUnitOfWork unitOfWork, IMongoContextSeeder<T> seeder)
        {
            _unitOfWork = unitOfWork;

            Collection = unitOfWork.GetCollection<T>();

            seeder.SeedData(Collection);
        }

        public FilterDefinitionBuilder<T> FilterBuilder()
        {
            return Builders<T>.Filter;
        }

        public UpdateDefinitionBuilder<T> UpdateBuilder()
        {
            return Builders<T>.Update;
        }

        public ProjectionDefinitionBuilder<T> ProjectionBuilder()
        {
            return Builders<T>.Projection;
        }
    }
}