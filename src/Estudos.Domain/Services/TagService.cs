using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Repositories;
using Estudos.Domain.Interfaces.Services;
using Estudos.Domain.Services.Base;

namespace Estudos.Domain.Services
{
    public class TagService : BaseService<Tag>, ITagService
    {
        private readonly ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository) : base(tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public virtual async Task<Tag> GetByNameAsync(string tagName) => await _tagRepository.GetByNameAsync(tagName);
    }
}
