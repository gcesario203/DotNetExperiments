using Catalog.API.Data.Base;
using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : MongoContext<Product>
    {
        public CatalogContext(MongoDbUnitOfWork unitOfWork, IMongoContextSeeder<Product> seeder) : base(unitOfWork, seeder)
        {
        }
    }
}