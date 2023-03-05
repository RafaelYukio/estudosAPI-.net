using Estudos.Application.DTOs.Request;
using Estudos.Application.DTOs.Response;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static Estudos.API.Controllers.EstudosController;

namespace Estudos.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class EstudosDbController : Controller
    {
        private readonly IProductService _productService;
        private readonly IDescriptionService _descriptionService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;

        public EstudosDbController(IProductService productService, IDescriptionService descriptionService, ICategoryService categoryService, ITagService tagService)
        {
            _productService = productService;
            _descriptionService = descriptionService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        // Precisa adicionar camada de Application para que toda a lógica feita dentro de cada método do controller fique lá

        [HttpPost("product")]
        public async Task<ActionResult> InsertProduct(CreateProductRequest productRequest)
        {
            Description description = new(productRequest.DescriptionDetails);

            // Não posso inserir a Description antes, pois o ID faz parte do par com o ID do ProductToDb
            //await _descriptionService.InsertAsync(description);

            Category existingCategoty = await _categoryService.GetByNameAsync(productRequest.CategoryName);
            if(existingCategoty == null)
            {
                return BadRequest();
            }

            List<Tag> tags = new();

            // Neste caso não é possível usar o Array.ForEach:
            // https://stackoverflow.com/questions/18667633/how-can-i-use-async-with-foreach

            foreach (string tagNames in productRequest.TagNames)
            {
                // Aqui um exemplo de quando não usar o AsNoTracking, pois o EF não faz o track da entidade resposta, criando uma nova
                // https://stackoverflow.com/questions/70585544/ef-core-many-to-many-problem-when-adding-new-data-duplicate-key-error?noredirect=1
                Tag existingTag = await _tagService.GetByNameAsync(tagNames);

                if (existingTag == null)
                {
                    Tag tag = new(tagNames);
                    existingTag = await _tagService.InsertAsync(tag);
                }
                tags.Add(existingTag);
            }

            ProductToDb productToDb = new(productRequest.Code, productRequest.Name, productRequest.Qtd);
            productToDb.Description = description;
            productToDb.Category = existingCategoty;
            productToDb.Tags = tags;

            ProductToDb response = await _productService.InsertAsync(productToDb);

            return Created($"/product/{response.Id}", response.Id);
        }

        [HttpPost("category")]
        public async Task<ActionResult> InsertCategory(CreateCategoryRequest categoryRequest)
        {
            Category category = new(categoryRequest.Name);
            Category response = await _categoryService.InsertAsync(category);

            return Created($"/categories", response.Id);
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            IEnumerable<ProductResponse> response = (await _productService.GetAllAsync()).Select(product => {
                IEnumerable<string> tags = product.Tags.Select(tag => tag.Name).ToList();
                return new ProductResponse(product.Id, product.Code, product.Name, product.Qtd, product.Description.Details, product.Category.Name, tags);
            }).ToList();

            return Ok(response);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            ProductToDb product = await _productService.GetByIdAsync(id);

            IEnumerable<string> tags = product.Tags.Select(tag => tag.Name).ToList();
            ProductResponse response = new(product.Id, product.Code, product.Name, product.Qtd, product.Description.Details, product.Category.Name, tags);

            return Ok(response);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            IEnumerable<CategoryResponse> response = (await _categoryService.GetAllAsync()).Select(category => new CategoryResponse(category.Id, category.Name)).ToArray();

            return Ok(response);
        }

        [HttpGet("tags")]
        public async Task<IActionResult> GetAllTags()
        {
            IEnumerable<TagResponse> response = (await _tagService.GetAllAsync()).Select(tag => new TagResponse(tag.Id, tag.Name)).ToArray();

            return Ok(response);
        }

    }
}
