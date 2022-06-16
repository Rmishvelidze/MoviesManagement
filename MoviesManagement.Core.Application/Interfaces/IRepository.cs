using MoviesManagement.Core.Domain.Basics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesManagement.Core.Application.Interfaces
{
    public interface IRepository<TKey, TEntity> where TEntity : BaseEntity
    {
        Task<int> CreateAsync(TEntity entity);

        Task<TEntity> ReadAsync(TKey id);
        Task<IEnumerable<TEntity>> ReadAsync();

        Task<int> UpdateAsync(TEntity entity);
        Task<int> UpdateAsync(TKey id, TEntity entity);

        Task<int> DeleteAsync(TKey id);
        Task<int> DeleteAsync(TEntity entity);
    }
}
