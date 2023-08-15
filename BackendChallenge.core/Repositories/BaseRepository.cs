using BackendChallenge.core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.core.Repositories
{
    public interface BaseRepository<T> where T : BaseEntity
    {
        Task<T> FindAllAsync();
        Task<T> FindByIdAsync(Guid id);

        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteByIdAsync(Guid id);
    }
}
