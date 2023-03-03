using Estudos.Application.DTOs.Request;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Estudos.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class EstudosDbController : Controller
    {
        private readonly IProductService _productService;

        public EstudosDbController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("product")]
        public async Task<ActionResult> InsertProduct(CreateProductRequest product)
        {
            // Aqui seria chamado o AppService, transformando o DTO na entidade

            ProductToDb productToDb = new(product.Code, product.Name, product.Qtd);
            EntityEntry<ProductToDb> response = await _productService.InsertAsync(productToDb);
            return Created($"/crud/get-by-code-rota/{response.CurrentValues}", product.Code);
        }

        //[HttpPost("crud/post-range")]
        //public IActionResult CRUDPostRange(List<CreateProductRequest> products)
        //{

        //    return Created($"/crud/get-all/", products.Select(product => product.Code).ToList());
        //}

        //[HttpGet("crud/get-all")]
        //public IActionResult CRUDGetAll()
        //{
        //    return Ok(ProductRepository.Products);
        //}

        //[HttpGet("crud/get-by-code-query")]
        //public IActionResult CRUDGetByCodeQuery(int code)
        //{
        //    Product product = ProductRepository.GetByCode(code);
        //    return product is null ? NotFound() : Ok(product);
        //}

        //[HttpGet("crud/get-by-code-rota/{code}")]
        //public IActionResult CRUDGetByCodeRota(int code)
        //{
        //    Product product = ProductRepository.GetByCode(code);
        //    return product is null ? NotFound() : Ok(product);
        //}
    }
}
