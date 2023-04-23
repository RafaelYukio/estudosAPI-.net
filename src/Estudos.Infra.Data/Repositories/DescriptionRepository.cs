using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Repositories;
using Estudos.Infra.Data.Context;
using Estudos.Infra.Data.Repositories.Base;

namespace Estudos.Infra.Data.Repositories
{
    public class DescriptionRepository : BaseRepository<Description>, IDescriptionRepository
    {

        public DescriptionRepository(EstudosDbContext context) : base(context)
        {
        }
    }
}
