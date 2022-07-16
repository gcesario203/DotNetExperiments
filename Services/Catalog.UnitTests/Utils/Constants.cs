using Catalog.API.Entities;
using Catalog.API.Repositories;

namespace Catalog.UnitTests.Utils
{
    public static class Constants
    {
        public const string MockId = "62d217f7675a2f60068df234";

        public static ProductRepository ProductRepository = MongoDBRepoPrepareRepo.PrepareRepository();

        public static Product GetMockProduct()
        {
            return new Product
            {
                Id = MockId,
                Category = "Luxo",
                Description = "Muito lindo",
                Name = "Tecladinho lindinho 2009",
                ImageFile = "img.jpeg",
                Price = 22.50M,
                Summary = "sei la"
            };
        }

        public static Product GetChangedProduct()
        {
            var productTobeUpdated = GetMockProduct();

            productTobeUpdated.Category = "Lixo";
            productTobeUpdated.Name = "Luiza Sonza";
            productTobeUpdated.Price = 0M;

            return productTobeUpdated;
        }
    }
}