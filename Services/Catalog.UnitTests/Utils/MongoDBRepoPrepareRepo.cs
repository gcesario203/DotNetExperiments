using Catalog.API.Data;
using Catalog.API.Repositories;
using MongoDB.Driver;

namespace Catalog.UnitTests.Utils
{
    public static class MongoDBRepoPrepareRepo
    {

        public static ProductRepository PrepareRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");

            var mongoDataBase = mongoClient.GetDatabase("CatalogDb");

            var unitOfWork =  new MongoDbUnitOfWork(mongoClient, mongoDataBase);

            var context = new CatalogContext(unitOfWork, null);

            var repo = new ProductRepository(context);

            return repo;
        }
    }
}