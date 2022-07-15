using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IMongoClient _client;
        public IMongoClient Client { get => this._client; }
        private IMongoDatabase _database;
        public IMongoDatabase Database { get => this._database; }

        public UnitOfWork(IMongoClient client, IMongoDatabase database)
        {
            _client = client;
            _database = database;
        }
    }
}