using Catalog.API.Entities.Interfaces;
using MongoDB.Driver;

namespace Catalog.API.Data.Interfaces
{
    public interface IMongoContext<T> where T : IEntity
    {
        IMongoCollection<T> _collection {get;}
    }
}