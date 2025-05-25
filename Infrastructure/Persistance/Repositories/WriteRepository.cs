using Application.Interfaces.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class WriteRepository<T>:IWriteRepository<T> where T : class, IBaseEntity , new()
    {
        private readonly DbContext _context;
        public WriteRepository(DbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }
        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }
        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }
        public async Task HardDeleteRangeAsync(IList<T> entities)
        {
            await Task.Run(() => Table.RemoveRange(entities));
        }
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
    }
    
}
