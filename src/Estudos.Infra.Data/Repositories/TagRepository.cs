using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Repositories;
using Estudos.Infra.Data.Context;
using Estudos.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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