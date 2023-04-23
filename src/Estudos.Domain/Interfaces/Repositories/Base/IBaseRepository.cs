using Estudos.Domain.Entities.Base;

namespace Estudos.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task RemoveAsync(Guid id);
    }
}