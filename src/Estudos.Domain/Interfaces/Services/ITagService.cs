using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Services.Base;

namespace Estudos.Domain.Interfaces.Services
{
    public interface ITagService : IBaseService<Tag>
    {
        Task<Tag> GetByNameAsync(string tagName);
    }
}
