using Estudos.Domain.Entities.Base;
using Estudos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Domain.Services.Base
{
    public abstract class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() =>
        await _baseRepository.GetAllAsync();

        public virtual async Task<T?> GetByIdAsync(Guid id) =>
        await _baseRepository.GetByIdAsync(id);

        public virtual async Task<EntityEntry<T>> InsertAsync(T entity) =>
        await _baseRepository.InsertAsync(entity);

        public virtual async Task UpdateAsync(T entity) =>
        await _baseRepository.UpdateAsync(entity);

    }
}
