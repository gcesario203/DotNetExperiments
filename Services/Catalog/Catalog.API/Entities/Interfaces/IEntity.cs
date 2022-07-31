using MongoDB.Bson;

namespace Catalog.API.Entities.Interfaces
{
    public interface IEntity
    {
        public string Id { get; set; }

        public BsonDocument ExtraElements { get; set; }
    }
}