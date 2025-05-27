using Application.Interfaces.Repositories;
using Application.Interfaces.UnitOfWorks;
using Domain.Common;
using Persistance.Context;
using Persistance.Repositories;

namespace Persistance.UnitOfWorks
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();

        public IReadRepository<T> GetReadRepository<T>() where T : class, IBaseEntity, new() => new ReadRepository<T>(dbContext);

        public IWriteRepository<T> GetWriteRepository<T>() where T : class, IBaseEntity, new() =>
            new WriteRepository<T>(dbContext);

        public Task<int> SaveChangesAsync() => dbContext.SaveChangesAsync();

        public int SaveChange() => dbContext.SaveChanges();
    }
}
