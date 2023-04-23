using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Repositories;
using Estudos.Infra.Data.Context;
using Estudos.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Infra.Data.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(EstudosDbContext context) : base(context)
        {
        }

        public async Task<Tag> GetByNameAsync(string tagName) => await _DbSet.FirstOrDefaultAsync(tag => tag.Name == tagName);
    }
}