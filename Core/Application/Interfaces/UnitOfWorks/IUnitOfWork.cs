using Application.Interfaces.Repositories;
using Domain.Common;

namespace Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IBaseEntity , new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IBaseEntity, new();

        Task<int> SaveChangesAsync();
        int SaveChange();
    }
}
