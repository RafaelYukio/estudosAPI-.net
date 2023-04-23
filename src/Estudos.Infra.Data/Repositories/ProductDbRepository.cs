using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Repositories;
using Estudos.Infra.Data.Context;
using Estudos.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Infra.Data.Repositories
{
    // Não pode herda interface antes de classe
    public class ProductDbRepository : BaseRepository<ProductToDb>, IProductDbRepository
    {
        public ProductDbRepository(EstudosDbContext context) : base(context)
        {
        }

        // Como estou colocando referências em todas as classes, temos um loop de referências
        // https://stackoverflow.com/questions/60197270/jsonexception-a-possible-object-cycle-was-detected-which-is-not-supported-this
        // Solução é adicionar serviço para tratar essas referências

        public override async Task<ProductToDb> GetByIdAsync(Guid id) => await _DbSet
            .AsNoTracking()
            .Include(product => product.Description)
            .Include(product => product.Category)
            .Include(product => product.Tags)
            .FirstOrDefaultAsync(product => product.Id == id);

        public override async Task<List<ProductToDb>> GetAllAsync() => await _DbSet
            .Include(product => product.Description)
            .Include(product => product.Category)
            .Include(product => product.Tags)
            .AsNoTracking().ToListAsync();
    }
}
