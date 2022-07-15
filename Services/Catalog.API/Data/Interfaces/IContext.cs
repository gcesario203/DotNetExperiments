using Catalog.API.Entities.Interfaces;
using MongoDB.Driver;

namespace Catalog.API.Data.Interfaces
{
    public interface IContext<T> where T : IEntity
    {
        IMongoCollection<T> _collection {get;}
    }
}