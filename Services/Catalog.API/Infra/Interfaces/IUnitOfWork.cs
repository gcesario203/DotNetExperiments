using MongoDB.Driver;

namespace Catalog.API.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClientSessionHandle Session { get; set; }

        void CreateSession();
        void Commit();
        void Rollback();
    }
}