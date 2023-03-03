using Estudos.Domain.Entities.Base;
using Estudos.Domain.Interfaces;
using Estudos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Infra.Data.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public readonly DbSet<T> _DbSet;
        public readonly EstudosDbContext _context;

        // Preciso passar o context no construtor?
        // Se eu não passar eu não preciso ficar passando dos repositórios filhos
        public BaseRepository(EstudosDbContext context)
        {
            _DbSet = context.Set<T>();
            _context = context;
        }

        // Querying data via the DbSet
        // https://www.learnentityframeworkcore.com/dbset/querying-data

        // Exemplo de uso de predicate (que é a função que passamo no where, por exemplo)
        // https://stackoverflow.com/questions/38205592/how-to-use-predicates-for-customer-where-linq-query-in-entity-framework-extensi
        //Expression<Func<Entity, bool>> predicate = (Entity entity) => Entity.Field == "TEST";
        //var query = context.Entities;

        //if (predicate != null)
        //query = query.Where(predicate);
        //mesmas coisa que query.Where(entity => entity.Field == "TEST")

        //// expand to get the results.
        //var results = query.ToList();

        // A virtual method is a method that can be overridden in a derived class

        // Tracked entities (EntityEntry):
        // https://learn.microsoft.com/en-us/ef/core/change-tracking/entity-entries
        public virtual async Task<EntityEntry<T>> InsertAsync(T entity)
        {
            EntityEntry<T> response = _DbSet.Add(entity);
            await _context.SaveChangesAsync();

            return response;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _DbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id) => await _DbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
        // Diferença entre IEnumerable e List:
        // https://stackoverflow.com/questions/3628425/ienumerable-vs-list-what-to-use-how-do-they-work
        // Imagem com explicação entre IEnumerable, ICollection, IList e List:
        //https://i.stack.imgur.com/4dKYm.png

        // Async stream:
        // https://stackoverflow.com/questions/56176176/difference-between-tolistasync-and-asasyncenumerable-tolist

        // Ver sobre Query variables:
        // https://learn.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics
        public virtual async Task<List<T>> GetAllAsync() => await _DbSet.AsNoTracking().ToListAsync();
    }
}
