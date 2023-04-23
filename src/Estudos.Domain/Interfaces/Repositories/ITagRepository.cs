using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Repositories.Base;

namespace Estudos.Domain.Interfaces.Repositories
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        Task<Tag> GetByNameAsync(string tagName);
    }
}
