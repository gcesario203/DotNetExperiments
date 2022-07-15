using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : IContext<Product>
    {
        private readonly MongoDbUnitOfWork _unitOfWork;
        public IMongoCollection<Product> _collection {get;}

        public CatalogContext(MongoDbUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _collection = unitOfWork.GetCollection<Product>();
        }
    }
}