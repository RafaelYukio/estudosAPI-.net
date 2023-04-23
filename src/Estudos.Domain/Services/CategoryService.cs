using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Repositories;
using Estudos.Domain.Interfaces.Services;
using Estudos.Domain.Services.Base;

namespace Estudos.Domain.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> GetByNameAsync(string categoryName) => await _categoryRepository.GetByNameAsync(categoryName);
    }
}
