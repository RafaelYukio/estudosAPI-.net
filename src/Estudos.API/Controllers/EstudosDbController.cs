using Estudos.Application.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class EstudosDbController : Controller
    {
        [HttpPost("products")]
        public IActionResult CRUDPost(CreateProductRequest product)
        {

            return Created($"/crud/get-by-code-rota/{product.Code}", product.Code);
        }

        //[HttpPost("crud/post-range")]
        //public IActionResult CRUDPostRange(List<Product> products)
        //{
        //    ProductRepository.AddRange(products);
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
