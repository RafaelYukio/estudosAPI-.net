using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Estudos.Infra.Data.Context;
using Estudos.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Infra.Data.Repositories
{
    // Não pode herda interface antes de classe
    public class ProductDbRepository : BaseRepository<ProductToDb>, IProductDbRepository
    {
        public ProductDbRepository(EstudosDbContext context) : base(context)
        {
        }
    }
}
