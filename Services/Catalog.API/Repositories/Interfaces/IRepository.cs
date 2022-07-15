using Catalog.API.Entities.Interfaces;

namespace Catalog.API.Repositories.Interfaces
{
    public interface IProductRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetItems();

        Task<T> GetItem(string id);

        Task CreateItem(T item);

        Task<bool> UpdateItem(T item);

        Task<bool> DeleteItem(string id);

        Task<IEnumerable<T>> GetItemByName(string name);

        Task<IEnumerable<T>> GetItemByCategory(string categoryName);
    }
}