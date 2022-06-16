using Microsoft.EntityFrameworkCore;
using MoviesManagement.Core.Application.Interfaces;
using MoviesManagement.Core.Domain.Basics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesManagement.Infrastructure.Persistence.Implementations
{
    internal abstract class Repository<TEntity> : IRepository<int, TEntity> where TEntity : BaseEntity
    {
        protected readonly DataContext _context;
        public Repository(DataContext context) => _context = context;

        //create
        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        //delete
        public virtual async Task<int> DeleteAsync(int id)
        {
            var item = await ReadAsync(id);
            _context.Set<TEntity>().Remove(item);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        //read
        public virtual async Task<TEntity> ReadAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> ReadAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        //update
        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync();
        }
        public virtual async Task<int> UpdateAsync(int id, TEntity entity)
        {
            var existing = _context.Set<TEntity>().Find(id);
            _context.Entry(existing).CurrentValues.SetValues(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
