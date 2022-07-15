using MongoDB.Driver;

namespace Catalog.API.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IMongoClient Client { get; }

        IMongoDatabase Database {get;}
    }
}