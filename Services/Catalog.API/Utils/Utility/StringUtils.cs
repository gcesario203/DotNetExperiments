using Catalog.API.Entities.Interfaces;
using Catalog.API.Utils.Attributes;

namespace Catalog.API.Utils.Utility
{
    public static class StringUtils
    {
        public static string GetCollectionName<T>() where T : IEntity
        {
            return typeof(T).GetCustomAttributes(true).Select(x => x as CollectionName).FirstOrDefault(x => x != null)?.Name ?? "";
        }
    }
}