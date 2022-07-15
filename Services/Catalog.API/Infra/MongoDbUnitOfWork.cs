using Catalog.API.Data.Interfaces;
using Catalog.API.Entities.Interfaces;
using Catalog.API.Utils.Utility;
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

        public IMongoCollection<T> GetCollection<T>() where T : IEntity
        {
            var collectionName = StringUtils.GetCollectionName<T>();

            return _database.GetCollection<T>(collectionName);
        }

        public async void CreateSessionAsync()
        {
            Session = await _client.StartSessionAsync();

            Session.StartTransaction();
        }

        public async void CommitAsync()
        {
            if (Session == null || !Session.IsInTransaction)
                return;

            await Session.CommitTransactionAsync();
        }

        public async void RollbackAsync()
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

        public void CreateSession()
        {
            Session = _client.StartSession();

            Session.StartTransaction();
        }

        public void Commit()
        {
            if (Session == null || !Session.IsInTransaction)
                return;

            Session.CommitTransaction();
        }

        public void Rollback()
        {
            if (Session == null || !Session.IsInTransaction)
                return;

            Session.AbortTransaction();
        }
    }
}