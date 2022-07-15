using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly IMongoContext<Product> _context;

        public ProductRepository(IMongoContext<Product> context)
        {
            _context = context;
        }

        public async Task CreateItem(Product item)
        {
            await _context.Collection.InsertOneAsync(item);
        }

        public async Task<bool> DeleteItem(string id)
        {
            var deleteResult = await _context
                .Collection
                .DeleteOneAsync(x => x.Id == id);

            return deleteResult.IsAcknowledged
                    && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            return await _context.Collection.Find(x => true).ToListAsync();
        }

        public async Task<Product> GetItem(string id)
        {
            return await _context.Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateItem(Product item)
        {
            var updateResult = await _context
                            .Collection
                            .ReplaceOneAsync(filter: g => g.Id == item.Id, replacement: item);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<IEnumerable<Product>> GetItemByName(string name)
        {
            var filter = _context.FilterBuilder().Regex(p => p.Name, $"/{name}/i");

            return await _context
                            .Collection
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetItemByCategory(string categoryName)
        {
            var filter = _context.FilterBuilder().Regex(p => p.Category, $"/{categoryName}/i");

            return await _context
                            .Collection
                            .Find(filter)
                            .ToListAsync();
        }
    }
}