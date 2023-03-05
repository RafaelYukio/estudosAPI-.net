using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Repositories;
using Estudos.Domain.Interfaces.Services;
using Estudos.Domain.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Domain.Services
{
    public class ProductService : BaseService<ProductToDb>, IProductService
    {
        // Do modo passando o IBaseRepository com o tipo, que é a mesma coisa do IProductDbRepository, porém preciso injetar a dependência do ProdutoService com IBaseRepository
        //public ProductService(IBaseRepository<ProductToDb> baseRepository) : base(baseRepository)
        public ProductService(IProductDbRepository productDbRepository) : base(productDbRepository)
        {
        }
    }
}
