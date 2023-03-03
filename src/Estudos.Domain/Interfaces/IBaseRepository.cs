using Estudos.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<EntityEntry<T>> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
    }
}