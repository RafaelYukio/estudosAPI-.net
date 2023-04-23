using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Services.Base;

namespace Estudos.Domain.Interfaces.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
        Task<Category> GetByNameAsync(string categoryName);
    }
}
