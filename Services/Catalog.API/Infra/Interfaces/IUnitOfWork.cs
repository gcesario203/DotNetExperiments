using MongoDB.Driver;

namespace Catalog.API.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMongoClient Client { get; }

        IMongoDatabase Database { get; }
        IClientSessionHandle Session { get; set; }

        void CreateSession();
        void Commit();
        void Rollback();
    }
}