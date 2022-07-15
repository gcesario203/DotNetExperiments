using Catalog.API.Entities.Interfaces;

namespace Catalog.API.Repositories.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetItems();

        Task<T> GetItem(string id);

        Task CreateItem(T item);

        Task<bool> UpdateItem(T item);

        Task<bool> DeleteItem(string id);
    }
}