using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Repositories;
using Estudos.Domain.Interfaces.Repositories.Base;
using Estudos.Domain.Interfaces.Services;
using Estudos.Domain.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Domain.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository= categoryRepository;
        }

        public async Task<Category> GetByNameAsync(string categoryName) => await _categoryRepository.GetByNameAsync(categoryName);
    }
}
