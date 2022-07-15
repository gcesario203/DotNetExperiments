using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class MongoDbUnitOfWork : IUnitOfWork
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        public IClientSessionHandle Session { get; set; }

        public MongoDbUnitOfWork(IMongoClient client, IMongoDatabase database)
        {

            _client = client;
            _database = database;
        }

        public async void CreateSession()
        {
            Session = await _client.StartSessionAsync();

            Session.StartTransaction();
        }

        public async void Commit()
        {
            if (Session == null || !Session.IsInTransaction)
                return;

            await Session.CommitTransactionAsync();
        }

        public async void Rollback()
        {
            if (Session == null || !Session.IsInTransaction)
                return;

            await Session.AbortTransactionAsync();
        }

        public void Dispose()
        {
            while (Session != null && Session.IsInTransaction)
                Thread.Sleep(TimeSpan.FromMilliseconds(100));

            GC.SuppressFinalize(this);
        }
    }
}