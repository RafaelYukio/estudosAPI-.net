using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Repositories;
using Estudos.Domain.Interfaces.Repositories.Base;
using Estudos.Infra.Data.Context;
using Estudos.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Infra.Data.Repositories
{
    public class DescriptionRepository : BaseRepository<Description>, IDescriptionRepository
    {

        public DescriptionRepository(EstudosDbContext context) : base(context)
        {
        }
    }
}
