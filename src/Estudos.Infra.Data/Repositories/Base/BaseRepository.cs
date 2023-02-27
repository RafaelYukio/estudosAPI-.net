using Estudos.Domain.Entities.Base;
using Estudos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Infra.Data.Repositories.Base
{
    public class BaseRepository<T> where T : BaseEntity
    {
        public readonly DbSet<T> _DbSet;
        public readonly EstudosDbContext _context;

        public BaseRepository(EstudosDbContext context)
        {
            _DbSet = context.Set<T>();
            _context = context;
        }
    }
}
